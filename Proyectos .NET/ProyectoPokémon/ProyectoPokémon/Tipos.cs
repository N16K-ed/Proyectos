using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPokémon
{
    public static class Tipos
    {
        public enum Tipo
        {
            NINGUNO,
            AGUA,
            PLANTA,
            FUEGO
        }

        public static readonly Dictionary<(Tipo, Tipo), float> Efectividades = new()
        {
            { (Tipo.FUEGO, Tipo.PLANTA), 2.0f },
            { (Tipo.PLANTA, Tipo.AGUA), 2.0f },
            { (Tipo.AGUA, Tipo.FUEGO), 2.0f },

            { (Tipo.FUEGO, Tipo.AGUA), 0.5f },
            { (Tipo.PLANTA, Tipo.FUEGO), 0.5f },
            { (Tipo.AGUA, Tipo.PLANTA), 0.5f }
        };
    }
}
