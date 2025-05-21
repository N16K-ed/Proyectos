using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPokémon
{
    
    internal class Charmander : Pokemon
    {
        public Charmander(string nombre)
            : base(ps: 39, ataque: 52, defensa: 43, ataqueEspecial: 60, defensaEspecial: 50, tipo1: Tipos.Tipo.FUEGO, nombre: nombre)
        {
            Ataque ruedaFuego = new Ataque(200, false, Tipos.Tipo.FUEGO, "Rueda Fuego");
            ataques.Add(ruedaFuego);

            Ataque ascuas = new Ataque(40,true, Tipos.Tipo.FUEGO, "Ascuas");
            ataques.Add(ascuas);

            Ataque planta = new Ataque(40, true, Tipos.Tipo.PLANTA, "Ascuas");
            ataques.Add(planta);
        }

        
        
    }
}
