using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPokémon
{
    public class Ataque
    {
        public string Nombre { get; }
        public int Poder { get; }
        public bool Especial { get; }
        public Tipos.Tipo TipoAtaque { get; } 

        public Ataque(int poder, bool especial, Tipos.Tipo tipo, string nombre)
        {
            Nombre = nombre;
            Poder = poder;
            Especial = especial;
            TipoAtaque = tipo;
        }
    }
}
