using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = comboBox1.SelectedItem.ToString();

            switch (seleccion)
            {
                case "Axel Blaze":
                    pictureBox1.Image = Properties.Resources.axel_blaze;
                    pictureBox2.Image = Properties.Resources.afinidad_FUEGO;
                    pictureBox3.Image = Properties.Resources.DL_icon;
                    textBox1.Lines = ["Nuevo y carismático estudiante. Le llaman 'el punta legendario'."];
                    break;
                case "Mark Evans":
                    pictureBox1.Image = Properties.Resources.mark_evans;
                    pictureBox2.Image = Properties.Resources.afinidad_MONTANA;
                    pictureBox3.Image = Properties.Resources.PR_icon;
                    textBox1.Lines = ["Enérgico capitán del Raimon. Nadie vive el fútbol como él."];
                    break;
                case "Jude Sharp":
                    pictureBox1.Image = Properties.Resources.jude_sharp;
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = ["De sus botas sale fútbol de muchos quilates. El mejor en su posición."];
                    break;
                case "Kevin Dragonfly":
                    pictureBox1.Image = Properties.Resources.kevin_dragonfly;
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DL_icon;
                    textBox1.Lines = ["Goleador del Raimon. Algo arisco, pero se deja la piel por el equipo."];
                    break;
                case "Nathan Swift":
                    pictureBox1.Image = Properties.Resources.nathan_swift;
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = ["Defensa veloz como un torbellino. Conoce a Mark desde hace tiempo."];
                    break;
                case "Jack Wallside":
                    pictureBox1.Image = Properties.Resources.jack_wallside;
                    pictureBox2.Image = Properties.Resources.afinidad_MONTANA;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = ["Su gran cuerpo es como una pared que utiliza para que nadie pase."];
                    break;
                case "Tod Ironside":
                    pictureBox1.Image = Properties.Resources.tod_ironside;
                    pictureBox2.Image = Properties.Resources.afinidad_FUEGO;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = ["Su cuerpo es pequeño, pero su coraje enorme. Da vidilla al equipo."];
                    break;
                case "Tim Saunders":
                    pictureBox1.Image = Properties.Resources.tim;
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = ["Sus gráciles movimientos y dominio del balón son fruto del kung-fu."];
                    break;
                case "Jim Wraith":
                    pictureBox1.Image = Properties.Resources.jim;
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = ["Nadie ha podido ver jamás la mirada que esconde detrás de su flequillo."];
                    break;
                case "Sam Kincaid":
                    pictureBox1.Image = Properties.Resources.sam;
                    pictureBox2.Image = Properties.Resources.afinidad_FUEGO;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = ["Va siempre a su ritmo, aunque los demás le chinchen por ello."];
                    break;
                case "Maxwell Carson":
                    pictureBox1.Image = Properties.Resources.max;
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.DL_icon;
                    textBox1.Lines = ["Por su pinta, nunca dirías que es un as de los deportes."];
                    break;
                case "William Glass":
                    pictureBox1.Image = Properties.Resources.willy_glass;
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DL_icon;
                    textBox1.Lines = ["﻿Un triunfador al que le quedan bien las gafas. O eso dice él..."];
                    break;
                case "Steve Grim":
                    pictureBox1.Image = Properties.Resources.steve;
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = ["No destaca en nada, pero sus habilidades están bien equilibradas."];
                    break;
                case "Bobby Shearer":
                    pictureBox1.Image = Properties.Resources.bobby_shearer;
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = ["Es despreocupado, pero pasional. Vivió un tiempo en Estados Unidos."];
                    break;
                case "Erik Eagle":
                    pictureBox1.Image = Properties.Resources.erik_eagle;
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = ["Centrocampista excepcional. Le llaman 'El mago del campo'."];
                    break;
                case "Joseph King":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._King;
                    pictureBox2.Image = Properties.Resources.afinidad_FUEGO;
                    pictureBox3.Image = Properties.Resources.PR_icon;
                    textBox1.Lines = new string[] { "Portero - Joseph King" };
                    break;
                case "Drent":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Drent; 
                    pictureBox2.Image = Properties.Resources.afinidad_MONTANA;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = new string[] { "Defensa - Drent" };
                    break;

                case "Ben Simmons":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Simmons; 
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = new string[] { "Defensa - Ben Simmons" };
                    break;

                case "Alan Master":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Master; 
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = new string[] { "Centrocampista - Alan Master" };
                    break;

                case "Gus Martin":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Martin; 
                    pictureBox2.Image = null;
                    pictureBox3.Image = Properties.Resources.DF_icon;
                    textBox1.Lines = new string[] { "Defensa - Gus Martin" };
                    break;

                case "Herman Waldon":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Waldon;  
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = new string[] { "Centrocampista - Herman Waldon" };
                    break;

                case "John Bloom":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Bloom;  
                    pictureBox2.Image = Properties.Resources.afinidad_FUEGO;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = new string[] { "Centrocampista - John Bloom" };
                    break;

                case "Derek Swing":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Swing;  
                    pictureBox2.Image = Properties.Resources.afinidad_AIRE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = new string[] { "Centrocampista - Derek Swing" };
                    break;

                case "Daniel Hatch":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Hatch;  
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DL_icon;
                    textBox1.Lines = new string[] { "Delantero - Daniel Hatch" };
                    break;

                case "Jude Sharp (2)":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Jude;  
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.MD_icon;
                    textBox1.Lines = new string[] { "Centrocampista - Jude Sharp" };
                    break;

                case "David Samford":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources._Samford;  
                    pictureBox2.Image = Properties.Resources.afinidad_BOSQUE;
                    pictureBox3.Image = Properties.Resources.DL_icon;
                    textBox1.Lines = new string[] { "Centrocampista - David Samford" };
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = comboBox2.SelectedItem.ToString();

            switch (seleccion)
            {
                case "Raimon":
                    pictureBox1.BackColor = Color.FromArgb(253, 152, 0);
                    pictureBox1.Image = Properties.Resources.logo_raimon;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    textBox1.Lines = ["EQUIPO DEL RAIMON"];
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(["Axel Blaze","Bobby Shearer","Erik Eagle","Jack Wallside","Jim Wraith","Jude Sharp",
                        "Kevin Dragonfly","Mark Evans","Maxwell Carson","Nathan Swift","Sam Kincaid","Steve Grim","Tim Saunders",
                        "Tod Ironside","William Glass"]);
                    break;
                case "Royal Academy":
                    pictureBox1.BackColor = Color.FromArgb(4, 46, 4);
                    pictureBox1.Image = Properties.Resources.logo_royal;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    textBox1.Lines = ["ROYAL ACADEMY"];
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(new string[]
                    {
                        "Joseph King",      // Portero
                        "Drent",            // Defensa
                        "Ben Simmons",      // Defensa
                        "Alan Master",      // Centrocampista
                        "Gus Martin",       // Defensa
                        "Herman Waldon",    // Centrocampista
                        "John Bloom",       // Centrocampista
                        "Derek Swing",      // Centrocampista
                        "Daniel Hatch",     // Delantero
                        "Jude Sharp (2)",       // Centrocampista
                        "David Samford"     // Dl
                    });
                    break;
                case "Zeus":
                    pictureBox1.BackColor = Color.FromArgb(255, 255, 255);
                    pictureBox1.Image = Properties.Resources.logo_royal;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    textBox1.Lines = ["INSTITUTO ZEUS"];
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(new string[]
                    {
                        "Poseidon",      // Portero, Masculino, Montaña, Tercer curso, Japón, Apollo
                        "Paul Siddon",   // Defensa, Masculino, Bosque, Segundo curso, Japón, Hephestus
                        "Jeff Iron",     // Defensa, Masculino, Fuego, Tercer curso, Japón, Ares
                        "Lane War",      // Defensa, Masculino, Montaña, Segundo curso, Japón, Dionysus
                        "Danny Wood",    // Defensa, Masculino, Aire, Primer curso, Japón, Artemis
                        "Artie Mishman", // Centrocampista, Masculino, Aire, Segundo curso, Japón, Artemis
                        "Arion Matlock", // Centrocampista, Masculino, Bosque, Segundo curso, Japón, Hermes
                        "Wesley Knox",   // Centrocampista, Masculino, Bosque, Primer curso, Japón, Athena
                        "Jonas Demetrius", // Delantero, Masculino, Fuego, Segundo curso, Japón, Demeter
                        "Byron Love",    // Centrocampista, Masculino, Bosque, Segundo curso, Japón, Aphrodite
                        "Henry House"    // Centrocampista, Masculino, Bosque, Segundo curso, Japón, Hera
                    });
                    break;
            }            
        }
    }
}
