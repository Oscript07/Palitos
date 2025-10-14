using System;
String simboloPalo = "|";
String modo;
// Aqui pongo los menus para quitarmelo ya de encima.
String menuArt =
"    /$$       /$$$$$$$           /$$ /$$   /$$                               /$$   \n" +
"   /$$/      | $$__  $$         | $$|__/  | $$                              |  $$  \n" +
"  /$$/       | $$  \\ $$ /$$$$$$ | $$ /$$ /$$$$$$    /$$$$$$   /$$$$$$$       \\  $$ \n" +
" /$$/        | $$$$$$$/|____  $$| $$| $$|_  $$_/   /$$__  $$ /$$_____/        \\  $$\n" +
"|  $$        | $$____/  /$$$$$$$| $$| $$  | $$    | $$  \\ $$|  $$$$$$          /$$/\n" +
" \\  $$       | $$      /$$__  $$| $$| $$  | $$ /$$| $$  | $$ \\____  $$        /$$/ \n" +
"  \\  $$      | $$     |  $$$$$$$| $$| $$  |  $$$$/|  $$$$$$/ /$$$$$$$/       /$$/  \n" +
"   \\__/      |__/      \\_______/|__/|__/   \\___/   \\______/ |_______/       |__/   \n" +
"                                                                                  \n" +
"                                                                                  \n" +
"                                                                                  \n" +
"             /$$                         /$$                         /$$           \n" +
"            |  $$                       |  $$                       |  $$          \n" +
"             \\  $$                       \\  $$                       \\  $$         \n" +
"              \\  $$                       \\  $$                       \\  $$        \n" +
"               \\  $$                       \\  $$                       \\  $$       \n" +
"                \\  $$                       \\  $$                       \\  $$      \n" +
"                 \\  $$                       \\  $$                       \\  $$     \n" +
"                  \\__/                        \\__/                        \\__/     \n" +
"                                                                                  \n" +
"                                                                                  \n" +
"              1. Jugar                     2. Reglas                  3. Salir  \n";
String menuArt2 =
"    /$$          /$$$$$                                               /$$   \n" +
"   /$$/         |__  $$                                              |  $$  \n" +
"  /$$/             | $$ /$$   /$$  /$$$$$$   /$$$$$$   /$$$$$$        \\  $$ \n" +
" /$$/              | $$| $$  | $$ /$$__  $$ |____  $$ /$$__  $$        \\  $$\n" +
"|  $$         /$$  | $$| $$  | $$| $$  \\ $$  /$$$$$$$| $$  \\__/         /$$/\n" +
" \\  $$       | $$  | $$| $$  | $$| $$  | $$ /$$__  $$| $$              /$$/ \n" +
"  \\  $$      |  $$$$$$/|  $$$$$$/|  $$$$$$$|  $$$$$$$| $$             /$$/  \n" +
"   \\__/       \\______/  \\______/  \\____  $$ \\_______/|__/            |__/   \n" +
"                                  /$$  \\ $$                                 \n" +
"                                 |  $$$$$$/                                 \n" +
"                                  \\______/                                  \n";

do
{
    // Menú Principal
    Console.Clear(); // Estos son para que quede mas limpia la interfaz
    Console.WriteLine(menuArt);
    modo = Console.ReadLine();

    if (modo == "1")
    {
        String subModo;
        do
        {
            Console.Clear();
            Console.WriteLine(menuArt2);
            Console.WriteLine("1. Jugar (Imposible)");
            Console.WriteLine("2. Jugar (Aleatorio)");
            Console.WriteLine("3. Jugar contra otro jugador");
            Console.WriteLine("4. Cambiar ficha");
            Console.WriteLine("5. Volver al menú principal");
            subModo = Console.ReadLine();

            if (subModo == "1")
            {
                bool reiniciarPartida;

                do
                {
                    reiniciarPartida = false; //Para que no se haga un bucle infinito por poner que siempre reiniciar la partida sea true

                    // Modo Imposible
                    bool activo = true;
                    int palosRestantes = 21;
                    String eleccion;
                    bool turnoJugador = true; // Alterna entre jugador e IA

                    Console.Clear();
                    Console.WriteLine("¡Buena suerte porque la vas a necesitar!\n\nPor listo vas a empezar primero.\n\n Pulsa cualquier tecla para continuar.");
                    Console.ReadKey();
                    while (activo == true) // Para que cuando sea false termine el modo de juego
                    {
                        if (turnoJugador == true)
                        {
                            Console.Clear();
                            Console.WriteLine("\nEs tu turno.\n\nQuedan " + palosRestantes + " palitos.");
                            
                            for (int i = 0; i < palosRestantes; i++)
                            {
                                Console.Write(simboloPalo + " "); // Para mostrar los palos graficamente
                            }
                            Console.Write("\nElige cuántos palos quieres tachar (1 a 4): \n\n\n\nSi desea salir al menú de juego, introduzca 'X'");

                            int palitosAQuitar = 0;
                            bool entradaValida = false;

                            while (entradaValida == false) //Comprueba que no ponga de eleccion algo que no sea 1,2,3 o 4.
                            {
                                eleccion = Console.ReadLine();
                                if (eleccion.ToUpper() == "X") // Por si lo ponen en minusculas o mayusculas que cualquiera sirva para salir.
                                {
                                    activo = false;
                                    entradaValida = true;
                                }
                                else if (eleccion == "1" || eleccion == "2" || eleccion == "3" || eleccion == "4")
                                {
                                    palitosAQuitar = Convert.ToInt32(eleccion);
                                    entradaValida = true;
                                }
                                else
                                {
                                    Console.WriteLine("Número inválido. Introduce un número del 1 al 4:");
                                }
                            }

                            palosRestantes -= palitosAQuitar;

                            if (palosRestantes <= 0) //Aqui es donde compruebo que quites el último palo. No se lo hago a la IA porque doy por hecho que no puede quitar el último.
                            {
                                Console.WriteLine("\nHas tachado el último palo. Has perdido.");

                                Console.WriteLine("\nPulsa R y luego Enter para reiniciar la partida contra la IA, o cualquier otra tecla para volver al menú.");
                                string eleccionReinicio = Console.ReadLine();
                                if (eleccionReinicio.ToUpper() == "R") // El .ToUpper sirve para que si lo pones en minusculas tambien cuente como una R mayuscula
                                {
                                    reiniciarPartida = true;
                                }

                                activo = false; // Termina el modo de juego (Yippeee)

                            }
                            else
                            {
                                turnoJugador = false; // Pasa el turno a la IA
                            }
                        }
                        else
                        {
                            int palosIA = 5 - (21 - palosRestantes) % 5; // IA --> explicación rápida porque sé que no me voy a acordar:
                                                                         // 21 - palosRestantes = palos quitados desde el inicio
                                                                         // % 5 = cuánto se ha ido del múltiplo de 5
                                                                         // 5 - resto = cantidad que la IA debe quitar
                                                                         // Por ejemplo, si el resto es 4, se han quitado 4 palos más del múltiplo de 5,
                                                                         // así que falta 1 por quitar

                            Console.Clear();

                            Console.WriteLine("\nTurno de la IA\n\nLa IA tacha " + palosIA + " palos.\n");
                            palosRestantes -= palosIA;
                            Console.WriteLine("Quedan " + palosRestantes + " palos.\n\nPulsa cualquier botón para continuar.");
                            for (int i = 0; i < palosRestantes; i++)
                            {
                                Console.Write(simboloPalo + " ");
                            }
                            Console.ReadKey();
                            turnoJugador = true; //Pasa turno al jugador
                        }

                    }
                } while (reiniciarPartida == true);


                Console.WriteLine("\nPulsa cualquier tecla para volver al menú del juego...");
                Console.ReadKey();

            }
            else if (subModo == "2")
            {
                // Modo Aleatorio
                Console.WriteLine("Aun no hay jaja.");
                Console.WriteLine("Pulsa cualquier tecla para volver al menú del juego...");
                Console.ReadKey();
            }
            else if (subModo == "3")
            {
                // Jugar contra otra persona
                Console.WriteLine("Aun no hay jaja.");
                Console.WriteLine("Pulsa cualquier tecla para volver al menú del juego...");
                Console.ReadKey();
            }
            else if (subModo == "4")
            {
                // Cambiar ficha
                Console.Clear();
                Console.WriteLine("Elige que simbolo prefieres para tu ficha, actualmente es este << " + simboloPalo+ " >>");
                Console.WriteLine("\n\n\n 1. |         2. @         3. ! \n\n Introduzca cualquier otra opción para cancelar el cambio.");

                String decisionFicha = Console.ReadLine();
                if (decisionFicha == "1")
                {
                    simboloPalo = "|";
                } else if (decisionFicha == "2")
                {
                    simboloPalo = "@";
                }else if (decisionFicha == "3")
                {
                    simboloPalo = "!";
                }




                    Console.WriteLine("Pulsa cualquier tecla para volver al menú del juego...");
                Console.ReadKey();
            }

        }
        while (subModo != "5"); // Si subModo == "5", vuelve al menú principal, si no, pues se sigue ejecutando todo lo de arriba ^^
    }
    else if (modo == "2") // Te explica como jugar
    {
        Console.Clear();
        Console.WriteLine("El juego consiste en tachar palitos (de 1 a 4) por turnos teniendo 21 palitos en total al inicio de la partida.\n" +
            "El jugador o máquina que tache el último palito, pierde.\n\n Pulsa cualquier tecla para volver al menú principal... jeje");
        Console.ReadKey();
    }
}
while (modo != "3"); // Para que si eliges el 3 el juego termine.
Environment.Exit(0);