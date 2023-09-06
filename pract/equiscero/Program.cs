using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;


class Juego
{
    public static bool punto(string[,] juego)
    {
        for (int i = 0; i < 3; i++)
        {
            if (juego[i, 0] == juego[i, 1] && juego[i, 1] == juego[i, 2] && juego[i, 0] != "[ ]" && juego[i, 1] != "[ ]" && juego[i, 2] != "[ ]")
            {
                System.Console.WriteLine("victoria");
                return true;
            }

            if (juego[0, i] == juego[1, i] && juego[1, i] == juego[2, i] && juego[0, i] != "[ ]" && juego[1, i] != "[ ]" && juego[2, i] != "[ ]")
            {
                System.Console.WriteLine("victoria");
                return true;
            }

            if (juego[0, 0] == juego[1, 1] && juego[1, 1] == juego[2, 2] && juego[0, 0] != "[ ]" && juego[1, 1] != "[ ]" && juego[2, 2] != "[ ]")
            {
                System.Console.WriteLine("victoria");
                return true;
            }

            if (juego[0,2] == juego[1, 1] && juego[2,0] == juego[0,2] && juego[0,2] != "[ ]" && juego[1, 1] != "[ ]" && juego[2,0] != "[ ]")
            {
                System.Console.WriteLine("victoria");
                return true;
            }



        }
        return false;

    }

    public static void Ver(string[,] juego)
    {
        System.Console.WriteLine("-------------------");
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                System.Console.Write("  "+juego[x, y]+"  ");
            }
            System.Console.WriteLine("\n");
        }
        System.Console.WriteLine("-------------------");


    }


    public static void vaciar(string[,] juego)
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {

                juego[x, y] = "[ ]";

            }
            System.Console.WriteLine();
        }
    }

    public static void Jugada(string[,] juego, int ops1, int ops2,string L)
    {
if (L=="X")
{
    System.Console.WriteLine("jugada de X");        juego[ops1, ops2] = "["+L+"]";
}
if (L=="Y")
{
        System.Console.WriteLine("jugada de Y");        juego[ops1, ops2] = "["+L+"]";

}


    }

    private static void PosicionDisponible(string[,] juego)
    {
        Console.WriteLine($"ingresar su jugada \n Pociciones disponibles");
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                string a = (juego[x, y] == "[ ]") ? "[" + x.ToString() + y.ToString() + "]" + " " : "No";
                System.Console.Write("  "+a+" ");
                ;
            }
            System.Console.WriteLine("\n");
        }
    }

    public static void Main(string[] args)
    {
        string[,] juego = new string[3, 3];
        int op1, op2;
        bool seguir = false, salir = false;


        vaciar(juego);
        System.Console.WriteLine("empieza X");

        do
        {
            PosicionDisponible(juego);

            op1 = int.Parse(Console.ReadLine());
            op2 = int.Parse(Console.ReadLine());
            if (op1 > 2 || op2 > 2)
            {
                System.Console.WriteLine("Fuera del limite 3x3");
            }
            else
            {
                Jugada(juego, op1, op2,"X");

                Console.WriteLine($"Seguir? 1/si 2/no");
                if (Console.ReadLine() == "2")
                {
                    Console.Clear();
                    seguir = true;
                }
                Ver(juego);
            }

                        PosicionDisponible(juego);

            op1 = int.Parse(Console.ReadLine());
            op2 = int.Parse(Console.ReadLine());
            if (op1 > 2 || op2 > 2)
            {
                System.Console.WriteLine("Fuera del limite 3x3");
            }
            else
            {
                Jugada(juego, op1, op2,"Y");

                Console.WriteLine($"Seguir? 1/si 2/no");
                if (Console.ReadLine() == "2")
                {
                    seguir = true;
                }
                                    Console.Clear();
                Ver(juego);
            }

            seguir = punto(juego);


        } while (seguir == false);













    }


}