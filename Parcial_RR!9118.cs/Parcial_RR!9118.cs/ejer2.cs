/*
*Kevin Israel Rodriguez Rivera
*RR19118
La carrera de ingeniería de sistemas informáticos desea realizar
 un congreso donde se tendrán ponencias (2 por mañana) y talles 
 ( 2 por tarde) con duración de 2 dias de manera simultanea. Dichas
  salas solo cuentan con una capacidad de 20 espacios disponibles 
  por lo que se desea mostrar en forma de matriz dichos espacios. 
  El usuario podrá elegir el espacio a su criterio, pero este tiene 
  la opción de reservar o eliminar una reserva. Cabe mencionar que
   no podrá hacer dos reservas en horarios iguales. Al finalizar se
    debe de mostrar  que conferencia o taller asistirá.

*/

using System.Security.Cryptography.X509Certificates;

public class congreso
{
    public static int[,,] salas = new int[4, 10, 10];
    public static int[,] sala1 = new int[4, 5];
    public static int[,] sala2 = new int[4, 5];
    public static int[,] sala3 = new int[4, 5];
    public static int[,] sala4 = new int[4, 5];

    public static void Main(string[] args)
    {
        Llenar(sala1);
        Llenar(sala2);
        Llenar(sala3);
        Llenar(sala4);

        Console.WriteLine($"Bienvenido \n se tienen disponibles los dias de \n 1 y  2");

        Console.WriteLine($"Bienvenido \n se tienen disponibles los horarios de \n 1/8am a 10 am 2/11am 12am 3/ 1pm a 3pm 4/4pm a 6pm 5/REVISAR");
        var opción = int.Parse(Console.ReadLine());

        switch (opción)
        {
            case 1:
                escojer(sala1, 1);
                Imprimir(sala1);


                break;
            case 2:
                escojer(sala2, 2);
                Imprimir(sala2);

                break;
            case 3:
                escojer(sala3, 3);
                Imprimir(sala3);

                break;
            case 4:
                escojer(sala4, 4);
                Imprimir(sala4);

                break;
            case 5:
                Console.WriteLine($"salir");
                break;

        }


    }

    private static void Llenar(int[,] sala)//funcion para llenar las salas
    {
        var seat = 1;
        for (var i = 0; i < sala.GetLength(0); i++)
        {
            for (var o = 0; o < sala.GetLength(1); o++)
            {
                sala[i, o] = seat; seat++;

            }
        }
    }

    private static void Imprimir(int[,] sala)//funcion para imprimir los asientos de las salas
    {
        var seat = 1;
        for (var i = 0; i < sala.GetLength(0); i++)
        {
            for (var o = 0; o < sala.GetLength(1); o++)
            {
                if (sala[i, o].ToString().Length < 2)
                {
                                    Console.Write($"[ {sala[i, o]} ]");
                }
                else
                {
                Console.Write($"[ {sala[i, o]} ]");
                }
            }
            Console.WriteLine($"");

        }
    }



    private static void escojer(int[,] sala, int sal)//funcion para escojer asiento
    {

        
        Imprimir(sala);

        Console.WriteLine($"escojer asiento");
        var op = int.Parse(Console.ReadLine());

        for (var i = 0; i < sala.GetLength(0); i++)
        {
            for (var o = 0; o < sala.GetLength(1); o++)
            {
                if (sala[i, o] == op)//si encuentra coincidencia lo reserva
                {
                    sala[i, o] = 0;
                    Console.WriteLine($"reserva exitosa\n");
                    switch (sal)
                    {
                        case 1:
                            Console.WriteLine($"Reserva para el horario de 8  a 10am en sala {sal} asiento {sala[i, o]}");
                            break;
                        case 2:
                            Console.WriteLine($"Reserva para el horario de 11am 12am en sala {sal} asiento {sala[i, o]} ");
                            break;
                        case 3:
                            Console.WriteLine($"Reserva para el horario de 1pm a 3pm en sala {sal} asiento {sala[i, o]}");
                            break;
                        case 4:
                            Console.WriteLine($"Reserva para el horario de 4/4pm a 6pm en sala {sal} asiento {sala[i, o]}");
                            break;
                    }
                    break;
                }
            }
        }
    }
}


