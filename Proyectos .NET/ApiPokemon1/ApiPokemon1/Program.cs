using Newtonsoft.Json;

namespace PokemonApiClient
{
    public class NamedApiResource
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Ability
    {
        public NamedApiResource ability { get; set; }
    }

    public class Move
    {
        public NamedApiResource move { get; set; }
    }

    public class Sprite
    {
        public string front_default { get; set; }
    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public NamedApiResource stat { get; set; }
    }

    public class Type
    {
        public NamedApiResource type { get; set; }
    }

    public class Pokemon
    {
        public List<Ability> abilities { get; set; }
        public int base_experience { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public List<Move> moves { get; set; }
        public string name { get; set; }
        public Sprite sprites { get; set; }
        public List<Stat> stats { get; set; }
        public List<Type> types { get; set; }
        public int weight { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Introduce el nombre de un Pokémon: ");
            string nombrePokemon = Console.ReadLine()?.ToLower();

            string url = $"https://pokeapi.co/api/v2/pokemon/{nombrePokemon}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(json);

                    Console.WriteLine($"{pokemon.name.ToUpper()} (ID: {pokemon.id})");
                    Console.WriteLine($"Altura: {pokemon.height}  |  Peso: {pokemon.weight}");
                    Console.WriteLine($"Base XP: {pokemon.base_experience}");

                    Console.WriteLine("\nTipos:");
                    foreach (var tipo in pokemon.types)
                        Console.WriteLine($" - {tipo.type.name}");

                    Console.WriteLine("\nHabilidades:");
                    foreach (var ability in pokemon.abilities)
                        Console.WriteLine($" - {ability.ability.name}");

                    Console.WriteLine("\nEstadísticas:");
                    foreach (var stat in pokemon.stats)
                        Console.WriteLine($" - {stat.stat.name}: Base: {stat.base_stat}, Esfuerzo: {stat.effort}");

                    Console.WriteLine("\nMovimientos:");
                    foreach (var move in pokemon.moves)
                    {
                        Console.WriteLine($" - {move.move.name}");
                    }

                    Console.WriteLine("\nSprite:");
                    Console.WriteLine($" - {pokemon.sprites.front_default}");
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine("No se pudo obtener información del Pokémon.");
                }
            }Console.ReadLine();
        }        
    }
}
