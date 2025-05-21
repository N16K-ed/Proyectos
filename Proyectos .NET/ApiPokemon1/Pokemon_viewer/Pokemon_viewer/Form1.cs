using Newtonsoft.Json;
using Pokemon_viewer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Pokemon_viewer
{
    public partial class Form1 : Form
    {
        private bool esShiny = false;
        private bool mostrandoFrontal = true;  // true = frontal, false = espalda

        private string rutaSpriteBackNormal = "";
        private string rutaSpriteBackShiny = "";
        private string rutaSpriteNormal = "";
        private string rutaSpriteShiny = "";
        private Image iconShiny;
        private Image iconShiny2;
        private ImageList imageListTipos = new ImageList();

        // Cache de movimientos y sus tipos
        private Dictionary<string, string> movimientosTipos = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, Image> tiposImagenes = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

        public Form1()
        {
            InitializeComponent();

            // Cargar imágenes de tipos a diccionario y imageList al inicio
            CargarTiposImagenes();

            imageListTipos.ImageSize = new Size(75, 15);
            lstMovimientos.LargeImageList = imageListTipos;
            lstMovimientos.View = View.LargeIcon;

            string iconPath = Path.Combine(Application.StartupPath, "sprites", "icons");
            iconShiny = Image.FromFile(Path.Combine(iconPath, "shiny.png"));
            iconShiny2 = Image.FromFile(Path.Combine(iconPath, "shiny2.png"));

            button1.Image = iconShiny;
            button1.ImageAlign = ContentAlignment.MiddleCenter;
            button1.FlatStyle = FlatStyle.Standard;
            button1.Enabled = false;
            button2.Text = "";
            button2.Enabled = false;
            // Mostrar "Cargando..." y ocultar todo menos lblCargando
            MostrarCargando(true);

            // Cargar todos los movimientos con sus tipos en segundo plano
            _ = CargarTodosLosMovimientosAsync();
        }

        private void MostrarLabelsDatos(bool visible)
        {
            lblTipos.Visible = visible;
            lblMovimientos.Visible = visible;
            lblHabilidades.Visible = visible;
            lblEstadisticas.Visible = visible;
        }
        private void MostrarCargando(bool cargando)
        {
            lblCargando.Visible = cargando;

            bool otrosVisibles = !cargando;
            lblDatos.Visible = otrosVisibles;
            picSprite.Visible = otrosVisibles;
            lstHabilidades.Visible = otrosVisibles;
            lstEstadisticas.Visible = otrosVisibles;
            lstMovimientos.Visible = otrosVisibles;
            picTipo1.Visible = otrosVisibles && picTipo1.Image != null;
            picTipo2.Visible = otrosVisibles && picTipo2.Image != null;
            button1.Visible = otrosVisibles;
            button2.Visible = otrosVisibles;
            MostrarLabelsDatos(otrosVisibles);
        }

        private void CargarTiposImagenes()
        {
            string typesPath = Path.Combine(Application.StartupPath, "sprites", "icons", "types");
            if (!Directory.Exists(typesPath))
                return;

            foreach (var file in Directory.GetFiles(typesPath, "*.png"))
            {
                string tipoNombre = Path.GetFileNameWithoutExtension(file).ToLower();
                if (!tiposImagenes.ContainsKey(tipoNombre))
                {
                    Image tipoImg = Image.FromFile(file);
                    tiposImagenes[tipoNombre] = tipoImg;

                    if (!imageListTipos.Images.ContainsKey(tipoNombre))
                    {
                        imageListTipos.Images.Add(tipoNombre, tipoImg);
                    }
                }
            }
        }

        private async Task CargarTodosLosMovimientosAsync()
        {
            string url = "https://pokeapi.co/api/v2/move?limit=10000";
            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetStringAsync(url);
                var movimientosList = JsonConvert.DeserializeObject<MovimientosList>(response);

                var tareas = new List<Task>();

                foreach (var mov in movimientosList.results)
                {
                    tareas.Add(Task.Run(async () =>
                    {
                        try
                        {
                            string detalleJson = await client.GetStringAsync(mov.url);
                            var detalle = JsonConvert.DeserializeObject<MoveDetail>(detalleJson);

                            lock (movimientosDatos)
                            {
                                movimientosDatos[mov.name] = (detalle.type.name.ToLower(), detalle.pp);
                            }
                        }
                        catch
                        {
                            // Ignorar errores individuales
                        }
                    }));
                }

                await Task.WhenAll(tareas);
            }
            catch
            {
                // Ignorar fallos generales
            }
            finally
            {
                this.Invoke(new Action(() =>
                {
                    MostrarCargando(false);
                }));
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {            
            MostrarCargando(true);
            button1.Enabled = true;
            button2.Enabled = true;
            button2.Text = "Front";
            string nombre = txtNombre.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(nombre))
            {
                MostrarCargando(false);
                MessageBox.Show("Por favor ingresa un nombre de Pokémon.");
                return;
            }

            string url = $"https://pokeapi.co/api/v2/pokemon/{nombre}";
            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<Pokemon>(json);

                double alturaMetros = pokemon.height / 10.0;
                double pesoKg = pokemon.weight / 10.0;

                string datos = $"{pokemon.name.ToUpper()}   |   Nº Dex Nacional: {pokemon.id}\n" +
                               $"Altura: {alturaMetros} m   |   Peso: {pesoKg} kg\n" +
                               $"Exp. Base: {pokemon.base_experience}";

                var evLines = new List<string>();
                foreach (var stat in pokemon.stats)
                {
                    if (stat.effort > 0)
                    {
                        string[] parts = stat.stat.name.Split('-');
                        for (int i = 0; i < parts.Length; i++)
                            parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();

                        string formattedName = string.Join(" ", parts);
                        evLines.Add($"EV al derrotar: {stat.effort} ({formattedName})");
                    }
                }

                if (evLines.Count > 0)
                    datos += "\n" + string.Join("\n", evLines);

                lblDatos.Text = datos;

                MostrarTipos(pokemon.types);

                lstHabilidades.Items.Clear();
                foreach (var hab in pokemon.abilities)
                {
                    string[] parts = hab.ability.name.Split('-');
                    for (int i = 0; i < parts.Length; i++)
                        parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();

                    string formatted = string.Join(" ", parts);
                    lstHabilidades.Items.Add(formatted);
                }

                lstEstadisticas.Items.Clear();
                foreach (var stat in pokemon.stats)
                {
                    string[] parts = stat.stat.name.Split('-');
                    for (int i = 0; i < parts.Length; i++)
                        parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();

                    string formattedName = string.Join(" ", parts);
                    lstEstadisticas.Items.Add($"{formattedName}: {stat.base_stat}");
                }

                MostrarMovimientosDelPokemon(pokemon.moves);

                int id = pokemon.id;

                // === Rutas de sprites ===
                string frontFolderPath = Path.Combine(Application.StartupPath, "sprites", "front");
                string[] normalFiles = Directory.GetFiles(frontFolderPath, $"{id}*.png");
                rutaSpriteNormal = normalFiles
                    .OrderBy(path => path)
                    .FirstOrDefault(file =>
                        Path.GetFileName(file).Equals($"{id}.png", StringComparison.OrdinalIgnoreCase) ||
                        Path.GetFileName(file).StartsWith($"{id}-", StringComparison.OrdinalIgnoreCase));

                string shinyFolderPath = Path.Combine(Application.StartupPath, "sprites", "front_s");
                string shinyFile = Path.Combine(shinyFolderPath, $"{id}.png");
                rutaSpriteShiny = File.Exists(shinyFile) ? shinyFile : "";

                // NUEVO: Rutas de espalda
                string backFolderPath = Path.Combine(Application.StartupPath, "sprites", "back");
                string backShinyFolderPath = Path.Combine(Application.StartupPath, "sprites", "back_s");

                string backNormalFile = Path.Combine(backFolderPath, $"{id}.png");
                string backShinyFile = Path.Combine(backShinyFolderPath, $"{id}.png");

                rutaSpriteBackNormal = File.Exists(backNormalFile) ? backNormalFile : "";
                rutaSpriteBackShiny = File.Exists(backShinyFile) ? backShinyFile : "";

                // Reiniciar estado visual
                esShiny = false;
                mostrandoFrontal = true;

                if (!string.IsNullOrEmpty(rutaSpriteNormal) && File.Exists(rutaSpriteNormal))
                {
                    picSprite.Image?.Dispose();
                    picSprite.Image = Image.FromFile(rutaSpriteNormal);
                }
                else
                {
                    picSprite.Image?.Dispose();
                    picSprite.Image = null;
                }

                button1.Image = iconShiny;

                MostrarCargando(false);
            }
            catch (HttpRequestException)
            {
                MostrarCargando(false);
                button1.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("No se pudo obtener información del Pokémon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MostrarCargando(false);
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private Dictionary<string, (string tipo, int pp)> movimientosDatos = new Dictionary<string, (string tipo, int pp)>(StringComparer.OrdinalIgnoreCase);
        private void MostrarMovimientosDelPokemon(List<Move> movimientos)
        {
            lstMovimientos.BeginUpdate();
            lstMovimientos.Items.Clear();

            foreach (var mov in movimientos)
            {
                string nombre = mov.move.name;

                string tipo = "normal";
                int pp = 0;

                if (movimientosDatos.ContainsKey(nombre))
                {
                    tipo = movimientosDatos[nombre].tipo;
                    pp = movimientosDatos[nombre].pp;
                }

                // Capitalizar cada palabra del nombre
                string[] parts = nombre.Split('-');
                for (int i = 0; i < parts.Length; i++)
                {
                    if (!string.IsNullOrEmpty(parts[i]))
                        parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1).ToLower();
                }
                string formattedName = string.Join(" ", parts);

                var item = new ListViewItem($"{formattedName}\nPP: {pp}");

                if (imageListTipos.Images.ContainsKey(tipo))
                    item.ImageKey = tipo;

                lstMovimientos.Items.Add(item);
            }

            lstMovimientos.EndUpdate();
            lstMovimientos.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            esShiny = !esShiny;

            string rutaSprite = "";

            if (mostrandoFrontal)
            {
                rutaSprite = esShiny ? rutaSpriteShiny : rutaSpriteNormal;
            }
            else
            {
                rutaSprite = esShiny ? rutaSpriteBackShiny : rutaSpriteBackNormal;
            }

            if (!string.IsNullOrEmpty(rutaSprite) && File.Exists(rutaSprite))
            {
                picSprite.Image?.Dispose();
                picSprite.Image = Image.FromFile(rutaSprite);
            }
            else
            {
                picSprite.Image?.Dispose();
                picSprite.Image = null;
            }

            // Actualiza el icono del botón si quieres que cambie visualmente
            button1.Image = esShiny ? iconShiny2 : iconShiny;
        }


        private void MostrarTipos(List<Types> tipos)
        {
            string typesPath = Path.Combine(Application.StartupPath, "sprites", "icons", "types");

            picTipo1.Image?.Dispose();
            picTipo2.Image?.Dispose();
            picTipo1.Image = null;
            picTipo2.Image = null;

            for (int i = 0; i < tipos.Count && i < 2; i++)
            {
                string typeName = tipos[i].type.name.ToLower();
                string imagePath = Path.Combine(typesPath, $"{typeName}.png");

                if (File.Exists(imagePath))
                {
                    Image tipoImg = Image.FromFile(imagePath);
                    if (i == 0)
                        picTipo1.Image = tipoImg;
                    else
                        picTipo2.Image = tipoImg;
                }
            }

            picTipo1.Visible = picTipo1.Image != null;
            picTipo2.Visible = picTipo2.Image != null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrandoFrontal = !mostrandoFrontal;

            string rutaSprite = "";

            if (mostrandoFrontal)
            {
                button2.Text = "Front";
                rutaSprite = esShiny ? rutaSpriteShiny : rutaSpriteNormal;
            }
            else
            {
                button2.Text = "Back";
                rutaSprite = esShiny ? rutaSpriteBackShiny : rutaSpriteBackNormal;
            }

            if (!string.IsNullOrEmpty(rutaSprite) && File.Exists(rutaSprite))
            {
                picSprite.Image?.Dispose();
                picSprite.Image = Image.FromFile(rutaSprite);
            }
            else
            {
                picSprite.Image?.Dispose();
                picSprite.Image = null;
            }
        }  
    }
}
