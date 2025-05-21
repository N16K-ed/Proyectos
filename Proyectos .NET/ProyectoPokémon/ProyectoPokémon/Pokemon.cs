using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPokémon
{
    internal class Pokemon
    {
        static Random random = new Random();

        string nombre { get; set; }
        int ps { get; set; }
        int ataque { get; set; }
        int defensa { get; set; }
        int ataqueEspecial { get; set; }
        int defensaEspecial { get; set; }
        int psActual { get; set; }

        Tipos.Tipo tipo1 { get; set; }
        Tipos.Tipo tipo2 { get; set; }

        protected List<Ataque> ataques { get; set; }

        public Pokemon(int ps, int ataque, int defensa, int ataqueEspecial, int defensaEspecial, Tipos.Tipo tipo1, string nombre)
        {
            this.nombre = nombre;
            this.ps = ps;
            this.ataque = ataque;
            this.defensa = defensa;
            this.ataqueEspecial = ataqueEspecial;
            this.defensaEspecial = defensaEspecial;
            this.tipo1 = tipo1;
            this.tipo2 = Tipos.Tipo.NINGUNO; // por defecto
            psActual = ps;
            ataques = new List<Ataque>();
        }

        public Pokemon(int ps, int ataque, int defensa, int ataqueEspecial, int defensaEspecial, Tipos.Tipo tipo1, Tipos.Tipo tipo2, string nombre)
        {
            this.nombre = nombre;
            this.ps = ps;
            this.ataque = ataque;
            this.defensa = defensa;
            this.ataqueEspecial = ataqueEspecial;
            this.defensaEspecial = defensaEspecial;
            this.tipo1 = tipo1;
            this.tipo2 = tipo2;
            psActual = ps;
            ataques = new List<Ataque>();
        }

        public string Nombre => nombre;
        public int PsActual => psActual;
        public int Ps => ps;
        public int Ataque => ataque;
        public int Defensa => defensa;
        public int AtaqueEsp => ataqueEspecial;
        public int DefensaEsp => defensaEspecial;
        public Tipos.Tipo Tipo1 => tipo1;
        public Tipos.Tipo Tipo2 => tipo2;
        public List<Ataque> Ataques => ataques;

        public void Atacar(Pokemon agresor, Ataque ataque, Pokemon defensor)
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine($"{agresor.Nombre} ha atacado a {defensor.Nombre} con {ataque.Nombre}");

            float danobase;

            if (ataque.Especial)
            {
                danobase = (ataque.Poder * agresor.ataqueEspecial / defensor.defensaEspecial) / 50 + 2;
            }
            else
            {
                danobase = (ataque.Poder * agresor.ataque / defensor.defensa) / 50 + 2;
            }

            danobase *= CalcularModificadores(agresor, ataque, defensor);

            double numeroAleatorio = random.NextDouble() * (1.0 - 0.85) + 0.85;
            danobase *= (float)numeroAleatorio;

            Console.WriteLine($"{defensor.Nombre} ha recibido {(int)danobase} de daño.");

            if (danobase > defensor.psActual)
            {
                defensor.psActual = 0;
                Console.WriteLine($"{defensor.Nombre} se ha debilitado.");
            }
            else
            {
                defensor.psActual -= (int)danobase;
            }
            Console.WriteLine("*****************************************************************");
        }

        public float CalcularModificadores(Pokemon agresor, Ataque ataque, Pokemon defensor)
        {
            float multiplicador = 1.0f;

            // STAB
            if (ataque.TipoAtaque == agresor.Tipo1 || ataque.TipoAtaque == agresor.Tipo2)
            {
                multiplicador *= 1.5f;
            }

            // Efectividad contra tipo1
            if (Tipos.Efectividades.TryGetValue((ataque.TipoAtaque, defensor.Tipo1), out float mult1))
            {
                multiplicador *= mult1;
                MostrarEfectividad(mult1);
            }

            // Efectividad contra tipo2 (si no es NINGUNO)
            if (defensor.Tipo2 != Tipos.Tipo.NINGUNO &&
                Tipos.Efectividades.TryGetValue((ataque.TipoAtaque, defensor.Tipo2), out float mult2))
            {
                multiplicador *= mult2;
                MostrarEfectividad(mult2);
            }

            return multiplicador;
        }

        private void MostrarEfectividad(float multiplicador)
        {
            if (multiplicador > 1.0f)
                Console.WriteLine("¡Es muy eficaz!");
            else if (multiplicador < 1.0f)
                Console.WriteLine("No es muy eficaz...");
        }
    }
}
