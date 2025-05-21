using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPokémon
{
    internal class Jugador
    {
        private List<Pokemon> pokemonJugador { get; set; }
        private string nombre;

        public Jugador(string nombre)
        {
            pokemonJugador = new List<Pokemon>();
            this.nombre = nombre;
        }

        public void aniadirPokemon(Pokemon pokemon)
        {
            pokemonJugador.Add(pokemon);
        }

        public List<Pokemon>Pokemon{get{ return this.pokemonJugador; } }
    }
}
