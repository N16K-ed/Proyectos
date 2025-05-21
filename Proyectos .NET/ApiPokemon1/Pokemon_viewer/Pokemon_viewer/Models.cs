using System.Collections.Generic;

namespace Pokemon_viewer.Models
{
    // Lista general de movimientos
    public class MovimientosList
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<MoveResult> results { get; set; }
    }

    public class MoveResult
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    // Detalle de un movimiento
    public class MoveDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public NamedAPIResource type { get; set; }
        public int pp { get; set; }
        // Puedes agregar más propiedades si lo necesitas
    }

    // Modelo para Pokémon
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }   // en decímetros
        public int weight { get; set; }   // en hectogramos
        public int base_experience { get; set; }

        public List<AbilityInfo> abilities { get; set; }
        public List<StatInfo> stats { get; set; }
        public List<Types> types { get; set; }
        public List<Move> moves { get; set; }
    }

    public class AbilityInfo
    {
        public bool is_hidden { get; set; }
        public int slot { get; set; }
        public NamedAPIResource ability { get; set; }
    }

    public class StatInfo
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public NamedAPIResource stat { get; set; }
    }

    public class Types
    {
        public int slot { get; set; }
        public NamedAPIResource type { get; set; }
    }

    // Modelo para movimientos del Pokémon
    public class Move
    {
        public NamedAPIResource move { get; set; }
        public List<VersionGroupDetail> version_group_details { get; set; }
    }

    public class VersionGroupDetail
    {
        public int level_learned_at { get; set; }
        public NamedAPIResource version_group { get; set; }
        public NamedAPIResource move_learn_method { get; set; }
        // pp NO viene aquí, se obtiene en MoveDetail
    }

    // Clase auxiliar para recursos nombrados
    public class NamedAPIResource
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class TypeInfo
    {
        public string name { get; set; }
    }

}
