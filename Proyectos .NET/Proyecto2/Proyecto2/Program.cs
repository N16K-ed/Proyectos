// See https://aka.ms/new-console-template for more information

using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class GestorNotas
{
    private static List<Alumno> alumnos = new List<Alumno>();


    static void Main()
    {
        string input;
        bool flag = false;
        string al;
        while (!flag)
        {
            Console.Clear();
            Console.WriteLine("Elije una opción:");
            Console.WriteLine("1-Añadir Alumno");
            Console.WriteLine("2-Calificar Alumno");
            Console.WriteLine("3-Ver Notas");
            Console.WriteLine("4-Eliminar Alumno");
            Console.WriteLine("5-Salir");
            int opcion = int.Parse(Console.ReadLine());
            while (opcion == null || opcion > 5 && opcion < 0)
            {
                Console.WriteLine("Introduzca una opción válida:");
                opcion = int.Parse(Console.ReadLine());
            }
            switch (opcion)
            {
                case 1:
                    añadirAlumno();
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Pulse enter para continuar...");
                    break;

                case 2:
                    Console.WriteLine("Introduzca el nombre de un alumno existente:");
                    al = Console.ReadLine();
                    calificarAlumno();
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Pulse enter para continuar...");

                    break;

                case 3:
                    Console.WriteLine("Introduzca el nombre de un alumno existente:");
                    al = Console.ReadLine();
                    verNotasAlumno(al);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Pulse enter para continuar...");

                    break;

                case 4:
                    eliminarAlumno();
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Pulse enter para continuar...");

                    break;

                case 5:
                    Console.WriteLine("Saliendo del Programa...");
                    flag = true;
                    break;
            }

        }
    }
    public class Alumno
    {
        private string nombre;
        private string curso;
        private Dictionary<string, float> notas;

        public Alumno(string nombre, string curso)
        {
            this.nombre = nombre;
            this.curso = curso;
            this.notas = new Dictionary<string, float>();
        }

        public void verNotas()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Alumno: " + this.nombre);
            Console.WriteLine("Curso: " + this.curso);
            if (this.notas.Count == 0)
            {
                Console.WriteLine("Este alumno aún no ha sido calificado en ninguna asignaura.");

            }
            else
            { 
                foreach (KeyValuePair<string, float> entry in notas)
                {
                    string asignatura = entry.Key;
                    double nota = entry.Value;

                    Console.WriteLine(asignatura + ": " + nota);
                }
                Console.WriteLine("********************");
            }
        }
        public void calificar()
        {
            Console.WriteLine("Introduzca una asignatura:");
            string asig = Console.ReadLine();
            Console.WriteLine("Introduzca la nota");
            float nota = float.Parse(Console.ReadLine());
            this.notas.Add(asig, nota);
        }
        public string getNombre()
        {
            return nombre;
        }

    }
    static void añadirAlumno()
    {
        Console.WriteLine("Introduzca un nombre");
        string nombre = Console.ReadLine();
        Console.WriteLine("Introduzca el curso");
        string curso = Console.ReadLine();

        Alumno al1 = new Alumno(nombre, curso);
        alumnos.Add(al1);
        Console.WriteLine("Se ha añadido el alumno " +  al1.getNombre() + " al curso " + curso);
    }

    static void calificarAlumno()
    {
        Console.WriteLine("Introduzca el nombre del alumno:");
        string nombre = Console.ReadLine();
        foreach (Alumno al in alumnos)
        {
            if (al.getNombre() == nombre)
            {
                al.calificar();
            }
        }

    }

    static void verNotasAlumno(string nom)
    {
        Console.WriteLine("Introduzca el nombre del alumno:");
        string nombre = Console.ReadLine();
        foreach (Alumno al in alumnos)
        {
            if (al.getNombre() == nombre)
            {
                al.verNotas();
            }
        }
    }

    static void eliminarAlumno()
    {
        Console.WriteLine("Introduzca el nombre del alumno a eliminar:");
        string nombre = Console.ReadLine();
        foreach (Alumno al in alumnos)
        {
            if (al.getNombre() == nombre)
            {
                alumnos.Remove(al);
                Console.WriteLine("Se ha eliminado al alumno: " + al.getNombre());
            }
            else
            {
                Console.WriteLine("No se ha encontrado al alumno: " + nombre);
            }
        }
    }


    
}