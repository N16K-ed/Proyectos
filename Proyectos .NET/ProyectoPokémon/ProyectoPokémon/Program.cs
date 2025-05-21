// See https://aka.ms/new-console-template for more information
using ProyectoPokémon;

    Random random = new Random();

    Console.WriteLine("Elije tu nombre:");
    string nombre = Console.ReadLine();
    Jugador player = new Jugador(nombre);

    Console.WriteLine("¡Has recibido un charmander!");
    Console.WriteLine("¿Quieres ponerle un mote? (S/N)");
    string opcion = Console.ReadLine();
    while(!(opcion.Equals("S") || opcion.Equals("N") || opcion.Equals("s") || opcion.Equals("n")))
    {
        Console.WriteLine("Seleccione una opcion válida (S/N):");
        opcion = Console.ReadLine();
    }
    if (opcion.Equals("S") || opcion.Equals("s"))
    {
        Console.WriteLine("Introduce el mote de Charmander:");
        string nombrePoke = Console.ReadLine();
        Charmander charmander = new Charmander(nombrePoke);
        player.aniadirPokemon(charmander);

    }
    else
    {
        Charmander charmander = new Charmander("Charmander");
        player.aniadirPokemon(charmander);
    }
    
    
    Console.WriteLine("\nPulse enter para continuar...");
    Console.ReadLine();
    Console.Clear();

    Bulbasaur bulba = new Bulbasaur("Bulbasaur enemigo");
    bool debilitado = false;

    Console.WriteLine("Vas a combatir contra Bulbasaur");
    
    Pokemon pokeActual;
    pokeActual = player.Pokemon[0];
    int opcionCombate;
    int opcionAtaque;
    List<Pokemon> pokemonVivos = new List<Pokemon>();
    pokemonVivos.AddRange(player.Pokemon);
    int contadorAtaques;
    int opcionCambiar;
    int atqueAleatorio = random.Next(0, bulba.Ataques.Count);
    Ataque enemigo;
    do
    {
        Console.WriteLine("\nPulse enter para continuar...");
        Console.ReadLine();
        Console.Clear();
        if (debilitado)
        {            
            break;
        }
        if (pokeActual.PsActual == 0)
        {            
            break;
        }
    Console.WriteLine("************************************************");
        Console.WriteLine(bulba.Nombre + ": " + bulba.PsActual + " PS");
        Console.WriteLine(pokeActual.Nombre + ": " + pokeActual.PsActual + " PS");
        Console.WriteLine("************************************************");

        Console.WriteLine("¿Qué quieres hacer\n1-Atacar\n2-Cambiar de Pokémon");
        opcionCombate= int.Parse(Console.ReadLine());
        
        while(opcionCombate != 1 && opcionCombate != 2)
        {
            Console.WriteLine("Seleccione una opcion válida:");
            opcionCombate = int.Parse(Console.ReadLine());
        }
        switch (opcionCombate)
        {
            case 1: //atacar
                Console.WriteLine("Seleccione un ataque:");
                contadorAtaques = 1;
                foreach(Ataque at in pokeActual.Ataques)
                {
                    Console.WriteLine(contadorAtaques + "-" + at.Nombre);
                    contadorAtaques++;
                }
                opcionAtaque = int.Parse(Console.ReadLine());
                while(opcionAtaque <= 0 || opcionAtaque > pokeActual.Ataques.Count)
                {
                    Console.WriteLine("Seleccione una opcion válida:");
                    opcionAtaque = int.Parse(Console.ReadLine());
                }
                Ataque ataque = pokeActual.Ataques[opcionAtaque - 1];
                pokeActual.Atacar(pokeActual, ataque, bulba);
                if (pokeActual.PsActual == 0)
                {
                    pokemonVivos.Remove(pokeActual);
                }
                if (bulba.PsActual == 0)
                {
                    debilitado = true;
                    break;
                }
            //ataca de vuelta el enemigo
            enemigo = bulba.Ataques[atqueAleatorio];
            bulba.Atacar(bulba, enemigo, pokeActual);
            break;
            case 2: // Cambiar Pokemon
                if (player.Pokemon.Count == 1)
                {
                    Console.WriteLine("No tienes más Pokémon");                   
                }
                else
                {
                    foreach (Pokemon viable in pokemonVivos)
                    {
                        Console.WriteLine("-" + viable.Nombre);
                    }
                    opcionCambiar = int.Parse(Console.ReadLine());
                    while (opcionCambiar <= 0 || opcionCambiar > pokemonVivos.Count)
                    {
                        Console.WriteLine("Seleccione una opcion válida:");
                        opcionCambiar = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Has cambiado de Pokémon");
                    pokeActual = pokemonVivos[opcionCambiar - 1];
                    

                }
                break;
        }

    } while (pokemonVivos.Count > 0 || !debilitado);
    if (debilitado)
    {
        Console.Clear();
        Console.WriteLine("¡Has ganado el combate!");
        Console.WriteLine("\nPulse enter para terminar");
        Console.ReadLine();
        Console.Clear();
}
    else
    {
        Console.Clear();
        Console.WriteLine("Has perdido el combate...");
        Console.WriteLine("\nPulse enter para terminar");
        Console.ReadLine();
        Console.Clear();
}
