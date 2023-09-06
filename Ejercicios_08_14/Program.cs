
using System.Runtime.Intrinsics.Arm;

public class Program
{
    public int num;
    public double precio;
    private static void ReservaMult(int[,] arry)
    {
        Console.WriteLine($"cuantos boletos desea comprar");
        var cant = int.Parse(Console.ReadLine());
        int[] reserva = new int[cant];

        for (var i = 0; i < cant; i++)
        {
            Console.WriteLine($"ingrese numero de asiento para el boleto {i}");
            reserva[i] = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        for (int i = 0; i < arry.GetLength(0); i++)
        {
            for (int j = 0; j < arry.GetLength(1); j++)
            {
                for (var x = 0; x < reserva.Length; x++)
                {
                    if (arry[i, j] == reserva[x])
                    {
                        Console.WriteLine($"reservado el asiento {arry[i, j]}");
                        arry[i, j] = 00;
                    }
                }

            }
        }




    }
    private static void LLenado(int[,] arry)
    {
        var num = 1;
        for (int i = 0; i < arry.GetLength(0); i++)
        {
            for (int j = 0; j < arry.GetLength(1); j++)
            {
                arry[i, j] = num; num++;
            }
        }
    }

    private static void Imprimir2D(int[,] arry)
    {
        for (int i = 0; i < arry.GetLength(0); i++)
        {
            for (int j = 0; j < arry.GetLength(1); j++)
            {
                if (arry[i, j].ToString().Length == 1)//si hay un solo numero se le agrega un espacio
                {
                    Console.Write("[ " + arry[i, j] + "  ]");
                }
                else
                {
                    Console.Write("[ " + arry[i, j] + " ]");
                }
            }
            Console.WriteLine($"\n");
        }
    }

    private static void Reserva(int[,] arry, int Dl)
    {
        bool reserva = false;

        for (int i = 0; i < arry.GetLength(0); i++)
        {
            for (int j = 0; j < arry.GetLength(1); j++)
            {
                if (arry[i, j] == Dl)
                {
                    Console.WriteLine($"Text");
                    arry[i, j] = 00;
                    reserva = true;
                }
            }
        }
        if (reserva == false)
        {
            System.Console.WriteLine("Asiento inexistente");
        }
        else
        {
            Console.WriteLine($"Asiento reservado");
        }
    }

    public static void Main(string[] args)
    {
        Console.Clear();
        var fila = 5; var col = 5;
        int[,] Mtrz = new int[fila, col];
        var seguir = false;
        LLenado(Mtrz);

        do
        {

            Console.WriteLine($"Bienvenido \n opciones: 0/ver sala\t 1/reservar asiento \t 3/reservar multiples asientos ");
            var ops = int.Parse(Console.ReadLine());

            switch (ops)
            {
                case 0:
                    Imprimir2D(Mtrz);
                    break;
                case 1:
                    Imprimir2D(Mtrz);
                    Console.WriteLine($"Cual numero de asiento desea reservar");
                    var Delete = int.Parse(Console.ReadLine());
                    Reserva(Mtrz, Delete);
                    break;
                case 2:
                    ReservaMult(Mtrz);
                    break;
                case 3 :
                break;
            }

            Console.WriteLine($"reservar otro asiento? 1/si 0/no");
            var op = int.Parse(Console.ReadLine());
            seguir = (op == 1) ? true : false;

        } while (seguir == true);


    }
}