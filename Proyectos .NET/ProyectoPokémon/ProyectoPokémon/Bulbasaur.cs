using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPokémon
{
    internal class Bulbasaur : Pokemon { 


    public Bulbasaur(string nombre)
                : base(ps: 45, ataque: 49, defensa: 49, ataqueEspecial: 65, defensaEspecial: 65, tipo1: Tipos.Tipo.PLANTA, nombre: nombre)
        {
            Ataque latigoCepa = new Ataque(45, false, Tipos.Tipo.PLANTA, "Látigo Cepa");
            ataques.Add(latigoCepa);

            Ataque energibola = new Ataque(80, true, Tipos.Tipo.PLANTA, "Energibola");
            ataques.Add(energibola);
        }

    }
}
