using System;
using System.Text;

public enum Colores
{
    Black,
    DarkBlue,
    DarkGreen,
    DarkCyan,
    DarkRed,
    DarkMagenta,
    DarkYellow,
    DarkGray,
    Gray,
    Blue,
    Green,
    Cyan,
    Red,
    Yellow,
    White
}


namespace Tateti_Definitivo
{
    class Program
    {
        static void Main(string[] args)
        {

            MostrarMenu();
            MostrarMensaje("El juego termino");
        }

        static void MostrarMenu()
        {
            int opc;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(15, 1);
                Console.WriteLine("1) Jugar");
                Console.SetCursorPosition(15, 2);
                Console.WriteLine("2) Cambiar el color de la consola");
                Console.SetCursorPosition(15, 3);
                Console.WriteLine("3) Ayuda");
                Console.SetCursorPosition(15, 4);
                Console.WriteLine("4) Salir");

                Console.SetCursorPosition(15, 5);
                Console.WriteLine(" ---------");
                Console.SetCursorPosition(15, 6);
                Console.Write("Seleccione una opcion para continuar > ");
                opc = PedirNumero(15, 7);

                switch (opc)
                {
                    case 1:
                        ModoDeJuego();
                        break;
                    case 2:
                        Colores();
                        break;
                    case 3:
                        Ayuda();
                        break;
                    case 4: break;
                    default:
                        MostrarMensaje("La opcion elegida no es correcta, intente nuevamente");
                        break;
                }


            } while (opc != 4);
        }

        static int PedirNumero(int Fila, int Columna)
        {
            string s;
            int r = -1;

            Console.SetCursorPosition(Fila, Columna);
            s = Console.ReadLine();
            if (s.Length == 1)
            {
                if (Encoding.ASCII.GetBytes(s)[0] >= 48 && Encoding.ASCII.GetBytes(s)[0] <= 57)
                {
                    r = Convert.ToInt32(s);
                }
                else
                {
                    if (Encoding.ASCII.GetBytes(s)[0] == 83 || Encoding.ASCII.GetBytes(s)[0] == 115)
                    {
                        r = -2;
                    }
                }

            }

            else
            {
                r = -1;
            }

            return r;
        }

        static void MostrarMensaje(string s)
        {
            Console.Clear();
            Console.SetCursorPosition(15, 6);
            Console.WriteLine(s);
            Console.ReadKey();
        }

        static void ModoDeJuego()
        {
            int opc;
            Console.Clear();
            Console.SetCursorPosition(14, 1);
            Console.WriteLine("Seleccione el modo de juego: ");
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("1) Jugador VS Jugador");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("2) Jugador VS Computadora");

            Console.SetCursorPosition(14, 5);
            Console.WriteLine(" ---------");
            Console.SetCursorPosition(14, 6);
            Console.Write("Seleccione una opcion para continuar > ");
            opc = PedirNumero(14, 7);

            switch (opc)
            {
                case 1:
                    JugarVSJugador();
                    break;
                case 2:
                    SeleccionDificultad();
                    break;
                default:
                    MostrarMensaje("La opcion elegida no es correcta, intente nuevamente");
                    break;
            }
        }

        static void JugarVSJugador()
        {
            char[] Tablero = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
            String[] jugador = new string[2];

            char[] ficha = { 'X', 'O' };
            string s = null;
            int opc = 0;
            int turno = -1;

            Console.Clear();

            Console.SetCursorPosition(15, 1);
            Console.WriteLine("Ingrese el nombre del jugador 1: ");
            Console.SetCursorPosition(15, 2);
            jugador[0] = Console.ReadLine();

            Console.SetCursorPosition(15, 3);
            Console.WriteLine("Ingrese el nombre del jugador 2: ");
            Console.SetCursorPosition(15, 4);
            jugador[1] = Console.ReadLine();


            do
            {
                DarTurno(ref turno);

                bool salir = false;

                opc = ComprobarPartida(Tablero);
                if (opc == -10 || opc == -11)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡{0} ha ganado la partida!", s);
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -3)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Empate!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                do
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("{0}, donde desea ingresar la ficha {1}? (S para salir)", jugador[turno], ficha[turno]);
                    opc = PedirNumero(15, 13);

                    if (opc >= 0 && opc <= 8)
                    {
                        if (ControlarCargaEnTablero(Tablero, opc))
                        {
                            Tablero[opc] = ficha[turno];
                            salir = true;
                            s = jugador[turno];
                        }
                    }
                    if (opc == -2)
                    {
                        salir = false;
                        break;
                    }
                } while (!salir);
            } while (opc >= 0);
        }

        static void SeleccionDificultad()
        {
            int opc;

            Console.Clear();
            Console.SetCursorPosition(14, 1);
            Console.WriteLine("A que desea cambiarle el color? ");
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("1) Facil");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("2) Medio");
            Console.SetCursorPosition(15, 4);
            Console.WriteLine("3) Imposible");

            Console.SetCursorPosition(14, 6);
            Console.WriteLine(" ---------");
            Console.SetCursorPosition(14, 7);
            Console.Write("Seleccione una opcion para continuar > ");
            opc = PedirNumero(14, 8);

            switch (opc)
            {
                case 1:
                    JugarVSComputadora_Facil();
                    break;
                case 2:
                    JugarVSComputadora_Medio();
                    break;
                case 3:
                    JugarVSComputadora_Imposible();
                    break;
                default:
                    MostrarMensaje("La opcion elegida no es correcta, intente nuevamente");
                    break;
            }
        }

        static void JugarVSComputadora_Facil()
        {
            char[] Tablero = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            String jugador;

            char[] ficha = { 'X', 'O' };
            int opc = 0;
            int turno = -1;

            Console.Clear();

            Console.SetCursorPosition(15, 1);
            Console.WriteLine("Ingrese su nombre: ");
            Console.SetCursorPosition(15, 2);
            jugador = Console.ReadLine();


            do
            {
                DarTurno(ref turno);

                bool salir = false;

                opc = ComprobarPartida(Tablero);
                if (opc == -11)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡{0} ha ganado la partida!", jugador);
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -10)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Has perdido la partida!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -3)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Empate!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (turno == 0)
                {
                    do
                    {
                        Random r = new Random(DateTime.Now.Millisecond);
                        opc = r.Next(0, 8);
                        if (ControlarCargaEnTablero(Tablero, opc))
                        {
                            Tablero[opc] = ficha[turno];
                            salir = true;
                        }
                    } while (!salir);
                }
                else
                {
                    do
                    {
                        Console.Clear();
                        DibujarTablero(Tablero);
                        Console.SetCursorPosition(15, 12);
                        Console.WriteLine("{0}, donde desea ingresar la ficha {1}? (S para salir)", jugador, ficha[turno]);
                        opc = PedirNumero(15, 13);

                        if (opc >= 0 && opc <= 8)
                        {
                            if (ControlarCargaEnTablero(Tablero, opc))
                            {
                                Tablero[opc] = ficha[turno];
                                salir = true;
                            }
                        }
                        if (opc == -2)
                        {
                            salir = false;
                            break;
                        }
                    } while (!salir);
                }
            } while (opc >= 0);
        }

        static void JugarVSComputadora_Medio()
        {
            char[] Tablero = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            String jugador;

            char[] ficha = { 'X', 'O' };
            int opc = 0;
            int turno = -1;

            Console.Clear();

            Console.SetCursorPosition(15, 1);
            Console.WriteLine("Ingrese su nombre: ");
            Console.SetCursorPosition(15, 2);
            jugador = Console.ReadLine();


            do
            {
                DarTurno(ref turno);

                bool salir = false;

                opc = ComprobarPartida(Tablero);
                if (opc == -11)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡{0} ha ganado la partida!", jugador);
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -10)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Has perdido la partida!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -3)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Empate!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (turno == 0)
                {
                    opc = IA_Medio(Tablero);
                    Tablero[opc] = ficha[turno];
                }
                else
                {
                    do
                    {
                        Console.Clear();
                        DibujarTablero(Tablero);
                        Console.SetCursorPosition(15, 12);
                        Console.WriteLine("{0}, donde desea ingresar la ficha {1}? (S para salir)", jugador, ficha[turno]);
                        opc = PedirNumero(15, 13);

                        if (opc >= 0 && opc <= 8)
                        {
                            if (ControlarCargaEnTablero(Tablero, opc))
                            {
                                Tablero[opc] = ficha[turno];
                                salir = true;
                            }
                        }
                        if (opc == -2)
                        {
                            salir = false;
                            break;
                        }
                    } while (!salir);
                }
            } while (opc >= 0);
        }

        static void JugarVSComputadora_Imposible()
        {
            char[] Tablero = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            String jugador;

            char[] ficha = { 'X', 'O' };
            int opc = 0;
            int turno = -1;

            Console.Clear();

            Console.SetCursorPosition(15, 1);
            Console.WriteLine("Ingrese su nombre: ");
            Console.SetCursorPosition(15, 2);
            jugador = Console.ReadLine();


            do
            {
                DarTurno(ref turno);

                bool salir = false;

                opc = ComprobarPartida(Tablero);
                if (opc == -11)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡{0} ha ganado la partida!", jugador);
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -10)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Has perdido la partida!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (opc == -3)
                {
                    Console.Clear();
                    DibujarTablero(Tablero);
                    Console.SetCursorPosition(15, 12);
                    Console.WriteLine("¡Empate!");
                    Console.SetCursorPosition(15, 13);
                    Console.ReadKey();
                    break;
                }

                if (turno == 0)
                {
                    opc = IA_Imposible(Tablero);
                    Tablero[opc] = ficha[turno];
                }
                else
                {
                    do
                    {
                        Console.Clear();
                        DibujarTablero(Tablero);
                        Console.SetCursorPosition(15, 12);
                        Console.WriteLine("{0}, donde desea ingresar la ficha {1}? (S para salir)", jugador, ficha[turno]);
                        opc = PedirNumero(15, 13);

                        if (opc >= 0 && opc <= 8)
                        {
                            if (ControlarCargaEnTablero(Tablero, opc))
                            {
                                Tablero[opc] = ficha[turno];
                                salir = true;
                            }
                        }
                        if (opc == -2)
                        {
                            salir = false;
                            break;
                        }
                    } while (!salir);
                }
            } while (opc >= 0);
        }

        static bool ControlarCargaEnTablero(char[] Tablero, int opc)
        {
            bool control = true;

            if (Tablero[opc] == 'X' || Tablero[opc] == 'O')
            {
                control = false;
            }

            return control;
        }

        static int ComprobarPartida(char[] Tablero)
        {
            int i = 0, j = 2, g = 0;

            for (i = 0; i < 9; i += 3)
            {
                if (Tablero[i] == 'X' && Tablero[i + 1] == 'X' && Tablero[i + 2] == 'X')
                {
                    return -10;
                }
                if (Tablero[i] == 'O' && Tablero[i + 1] == 'O' && Tablero[i + 2] == 'O')
                {
                    return -11;
                }
            }
            for (i = 0; i < 3; i++)
            {
                if (Tablero[i] == 'X' && Tablero[i + 3] == 'X' && Tablero[i + 6] == 'X')
                {
                    return -10;
                }
                if (Tablero[i] == 'O' && Tablero[i + 3] == 'O' && Tablero[i + 6] == 'O')
                {
                    return -11;
                }
            }
            for (i = 6; i < 9; i = i + 2)
            {
                if (Tablero[i] == 'X' && Tablero[i - j] == 'X' && Tablero[i - 2 * j] == 'X')
                {
                    return -10;
                }
                if (Tablero[i] == 'O' && Tablero[i - j] == 'O' && Tablero[i - 2 * j] == 'O')
                {
                    return -11;
                }
                j = j + 2;
            }

            for (i = 0; i < 9; i++)
            {
                if (Tablero[i] == 'X' || Tablero[i] == 'O')
                {
                    g++;
                }
            }
            if (g == 9)
            {
                return -3;
            }
            return 0;
        }

        static void DarTurno(ref int turno)
        {
            if (turno == -1)
            {
                Random r = new Random(DateTime.Now.Millisecond);
                turno = r.Next(0, 2);
                return;
            }
            if (turno == 0)
            {
                turno = 1;
            }
            else
            {
                turno = 0;
            }
        }

        static void DibujarTablero(char[] Tablero)
        {
            Console.Clear();

            Console.SetCursorPosition(15, 4);
            Console.WriteLine(" " + Tablero[0] + " | " + Tablero[1] + " | " + Tablero[2]);
            Console.SetCursorPosition(15, 5);
            Console.WriteLine("------------");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine(" " + Tablero[3] + " | " + Tablero[4] + " | " + Tablero[5]);
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("------------");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine(" " + Tablero[6] + " | " + Tablero[7] + " | " + Tablero[8]);

        }

        static void Ayuda()
        {
            Console.Clear();
            Console.SetCursorPosition(5, 3);
            Console.WriteLine("¡Bienvenido al juego Ta-te-ti!");

            Console.SetCursorPosition(5, 5);
            Console.WriteLine("La opcion 1 le permitira iniciar una partida de Ta-te-ti, ya sea contra otro jugador o contra la computadora");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("El juego consiste en colocar fichas en un tablero de 3x3 por turnos");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("Para ganar hay que formar 3 fichas iguales en fila");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("Se le avisara al jugador cuando sea su turno, y debera colocar el numero de la celda donde quiera colocar la ficha");

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("La opcion 2 le permitira cambiar el color de la consola");

            Console.SetCursorPosition(5, 12);
            Console.WriteLine("Y la opcion 4 finalizara el juego");
            Console.ReadKey();
        }

        static void Colores()
        {
            int opc;

            Console.Clear();
            Console.SetCursorPosition(14, 1);
            Console.WriteLine("A que desea cambiarle el color? ");
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("1) Fondo");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("2) Letra");
            Console.SetCursorPosition(15, 4);
            Console.WriteLine("3) Salir");

            Console.SetCursorPosition(14, 6);
            Console.WriteLine(" ---------");
            Console.SetCursorPosition(14, 7);
            Console.Write("Seleccione una opcion para continuar > ");
            opc = PedirNumero(14, 8);

            switch (opc)
            {
                case 1:
                    CambiarFondo();
                    break;
                case 2:
                    CambiarLetra();
                    break;
                case 3: break;
                default:
                    MostrarMensaje("La opcion elegida no es correcta, intente nuevamente");
                    break;
            }
        }

        static void CambiarFondo()
        {
            int i = 0, opc;

            Console.Clear();
            Console.WriteLine("Ingrese el numero del color del fondo:");
            Type type = typeof(ConsoleColor);

            foreach (var name in Enum.GetNames(type))
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, name);

                if (Console.ForegroundColor != Console.BackgroundColor)
                {
                    Console.WriteLine(i + " ) " + name);
                    i++;
                }
                else if (Console.ForegroundColor == Console.BackgroundColor)
                {
                    i++;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("Su opcion: ");
            opc = Convert.ToInt32(Console.ReadLine());

            var f = (Colores)opc;
            Console.WriteLine(f);

            Console.BackgroundColor = (ConsoleColor)f;
        }

        static void CambiarLetra()
        {
            int i = 0, opc;

            Console.Clear();
            Console.WriteLine("Ingrese el numero del color de la letra:");
            Type type = typeof(ConsoleColor);

            foreach (var name in Enum.GetNames(type))
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);

                if (Console.ForegroundColor != Console.BackgroundColor)
                {
                    Console.WriteLine(i + " ) " + name);
                    i++;
                }
                else if (Console.ForegroundColor == Console.BackgroundColor)
                {
                    i++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Su opcion: ");
            opc = Convert.ToInt32(Console.ReadLine());

            var f = (Colores)opc;
            Console.WriteLine(f);

            Console.ForegroundColor = (ConsoleColor)f;
        }

        static int IA_Medio(char[] Tablero)
        {
            double MejorPuntaje = double.NegativeInfinity;
            char ia = 'X';
            int i = 0, movimiento = 0;
            double puntaje = 0;

            for (i = 0; i < 9; i++)
            {
                if (Tablero[i] == ' ')
                {
                    Tablero[i] = ia;
                    puntaje = 1;
                    Tablero[i] = ' ';
                    if (puntaje > MejorPuntaje)
                    {
                        MejorPuntaje = puntaje;
                        movimiento = i;
                    }
                }
            }
            return movimiento;
        }

        static int IA_Imposible(char[] Tablero)
        {
            //(Toda esta parte la tuve que comentar porque me perdia demasiado)

            /* Esta funcion guarda el mejor puntaje de la funcion "Minimax" y su posicion
               para asi colocarla en el tablero */

            double MejorPuntaje = double.NegativeInfinity; //Puntaje minimo
            char ia = 'X'; //Ficha de la computadora
            int i = 0, movimiento = 0;
            double puntaje = 0;

            for (i = 0; i < 9; i++) //Recorre todo el tablero
            {
                if (Tablero[i] == ' ') //Va a chequear los espacios en blanco
                {
                    Tablero[i] = ia; //Coloca una ficha (De la IA, 'X') en un espacio
                    puntaje = minimax(Tablero, false); //Lo que devuelva minimax va a puntaje (ver funcion "Minimax")
                    Tablero[i] = ' '; //Coloca un espacio en blanco donde habia puesto la ficha
                    if (puntaje > MejorPuntaje) //Si el puntaje devuelto es mayor a menos infinito (o al Mejor puntaje anterior)
                    {
                        MejorPuntaje = puntaje; //El puntaje pasa a MejorPuntaje (para chequear con los proximos "puntaje)
                        movimiento = i; //El valor de "i" se guarda (la "mejor" posicion elegida) en movimiento
                    }
                }
            }
            return movimiento; //Devuelve la "mejor" posicion
        }

        static char ChequearGanador(char[] Tablero)
        {
            int a;

            a = ComprobarPartida(Tablero);

            if (a == -10)
            {
                return 'X';
            }
            else if (a == -11)
            {
                return 'O';
            }
            else if (a == -3)
            {
                return 'E';
            }

            return 'Q';
        }

        static double minimax(char[] Tablero, bool Maximizado)
        {
            /* Explicacion del algoritmo: Primero se chequea que el juego no haya terminado,
               despues se chequea si "Maximizado" es verdadero o falso (esto sirve para saber 
               de quien seria cada turno y para diferenciar las funciones):
               La primera vez que se ejecute sera falso, lo que significa que probara con un turno 
               del jugador (colocando la ficha 'O'), "Maximizado" pasara a ser verdadero y volvera a ejecutar 
               la funcion "minimax", al "Maximizado" ser verdadero, se coloca una ficha de la computadora ('X')
               y asi hasta llenar el tablero. 
               Al finalizar el ciclo, se devuelve el ultimo "Mejorpuntaje" (y se guarda en puntaje),
               se coloca el espacio en blanco y (dependiendo la funcion) se comprueba 
               que "puntaje" sea mayor o menor a "MejorPuntaje", y se prueba con otra posicion del tablero.
               Al terminar el for, se devuelve el "MejorPuntaje" a la funcion "IA"*/

            char resultado, ia = 'X', Jugador = 'O'; //Se declaran las fichas
            int i = 0;
            double puntaje;
            resultado = ChequearGanador(Tablero); //Se chequea si la partida termino, y quien gano

            if (resultado != 'Q') //'Q' significa que la partida sigue
            {
                if (resultado == ia)
                {
                    return 10; //Si la computadora gana devuelve un 10
                }
                if (resultado == Jugador)
                {
                    return -10; //Si el jugador gana, devuelve -10
                }
                if (resultado == 'E')
                {
                    return 0; //Si hubo un empate, devuelve 0
                }
            }

            if (Maximizado) //Si "Maximizado" es verdadero (Osea, el turno es de la IA)
            {
                double MejorPuntaje = double.NegativeInfinity; //El mejor puntaje es menos infinito
                for (i = 0; i < 9; i++) //Se chequea el tablero
                {
                    if (Tablero[i] == ' ') //Se comprueba si el espacio esta vacio
                    {
                        Tablero[i] = ia; //Se coloca una ficha 'X' en el espacio
                        puntaje = minimax(Tablero, false); //Se repite la funcion, para ver si la partida termino o si iria el Jugador
                        Tablero[i] = ' '; //Se coloca de nuevo un espacio en blanco
                        if (puntaje > MejorPuntaje) //Si el puntaje obtenido de minimax es mayor a "MejorPuntaje"...
                        {
                            MejorPuntaje = puntaje; // Puntaje pasa a ser el mejor puntaje
                        }
                    }
                }
                return MejorPuntaje; //Y se devuelve el mejor puntaje
            }
            else //En cambio, si "Maximizado" es falso (Es decir, el turno "seria" del jugador)
            {
                double MejorPuntaje = double.PositiveInfinity; //El mejor puntaje es infinito
                for (i = 0; i < 9; i++) //Se chequea el tablero
                {
                    if (Tablero[i] == ' ') //Se comprueba si el espacio elegido esta en blanco
                    {
                        Tablero[i] = Jugador; //Se coloca una ficha 'O' en el espacio
                        puntaje = minimax(Tablero, true); //Otra vez, se repite la funcion, para chequear si la partida termino o que la computadora coloque otra ficha
                        Tablero[i] = ' '; //Se coloca de nuevo el espacio vacio
                        if (puntaje < MejorPuntaje) //Se comprueba que el puntaje obtenido sea menor que el MejorPuntaje
                        {
                            MejorPuntaje = puntaje; //Y si el puntaje es menor, puntaje es el mejor puntaje
                            
                            /*Explicacion: En esta funcion se busca el menor puntaje posible, ya que,
                              se trata de buscar los puntajes mas favorables para la IA, y los menos
                              favorables para el jugador*/
                        }
                    }
                }
                return MejorPuntaje; //Y finalmente, se devuelve el mejor puntaje
            }
        }
    }
}
