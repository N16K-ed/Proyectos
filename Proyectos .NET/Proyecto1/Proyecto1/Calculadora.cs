// See https://aka.ms/new-console-template for more information

    int opcion;     
    int n1;
    int n2;
    float resultado;
    bool flag = false;
    
    
    
    while (!flag)
    {
    Console.Clear();
    Console.WriteLine("Introduzca una opción válida:\n1-SUMA\n2-RESTA\n3-MULTIPLICACIÓN\n4-DIVISIÓN\n5-SALIR");



    string input = Console.ReadLine();
    
    while (!int.TryParse(input, out opcion)|| opcion > 5 && opcion < 0 )
    {
    Console.WriteLine("Introduzca una opción válida");
    input = Console.ReadLine();
    }
    Console.Clear();
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Se van a sumar 2 números.\nIntroduzca el 1er número:");
            input = Console.ReadLine() ;
            while (!int.TryParse(input,out n1))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            Console.WriteLine("Introduzca el 2o número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n2))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            resultado = n1 + n2;
            Console.WriteLine("El resultado es " +  resultado);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Pulse enter para continuar...");               
            
            break;

        case 2:
            Console.WriteLine("Se van a restar 2 números.\nIntroduzca el 1er número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n1))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            Console.WriteLine("Introduzca el 2o número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n2))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            resultado = n1 - n2;
            Console.WriteLine("El resultado es " + resultado);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Pulse enter para continuar...");

            break;

        case 3:
            Console.WriteLine("Se van a multiplicar 2 números.\nIntroduzca el 1er número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n1))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            Console.WriteLine("Introduzca el 2o número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n2))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            resultado = n1 * n2;
            Console.WriteLine("El resultado es " + resultado);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Pulse enter para continuar...");

            break;

        case 4:
            Console.WriteLine("Se van a dividir 2 números.\nIntroduzca el 1er número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n1))
            {
                Console.WriteLine("Introduzca un número:");
                input = Console.ReadLine();
            }
            Console.WriteLine("Introduzca el 2o número:");
            input = Console.ReadLine();
            while (!int.TryParse(input, out n2) || n2 == 0)
            {
                Console.WriteLine("Introduzca un número distinto a 0:");
                input = Console.ReadLine();
            }
            resultado = n1 / n2;
            Console.WriteLine("El resultado es " + resultado);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Pulse enter para continuar...");

            break;

        case 5:
            Console.WriteLine("Saliendo del Programa...");
            flag = true; 
            break;
    }
    Console.ReadLine();
    Console.Clear ();
}
