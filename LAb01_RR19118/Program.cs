public class MyClass
{
    public class Productos
    {
        public string Producto;
        public double precio;

        public Productos(string Producto, double precio)
        {
            this.Producto = Producto;
            this.precio = precio;
        }

    }

    public static int Random()
    {
        return new Random().Next(1, 50);
    }

    public static void Ver2D(int[,] arry)
    {
        for (var i = 0; i < arry.GetLength(0); i++)
        {
            for (var ii = 0; ii < arry.GetLength(1); ii++)
            {
                System.Console.Write($"[ " + arry[i, ii] + " ]");
            }
            System.Console.WriteLine("\n");
        }
    }

    public static int Calcular2D(int[,] arry)
    {
        int SumaX = 0, SumaY = 0, SumaT = 0;

        for (var i = 0; i < arry.GetLength(0); i++)
        {
            for (var ii = 0; ii < arry.GetLength(1); ii++)
            {
                SumaT += arry[i, ii];
            }
        }
        return SumaT;
    }

    public static int[,] sumaMatriz(int[,] arryA, int[,] arryB)
    {
        int[,] resultante = new int[arryA.GetLength(0),arryA.GetLength(1)];
        var filaA = arryA.GetLength(0);
        var colA = arryA.GetLength(1);

        for (var i = 0; i < filaA; i++)
        {
            for (var ii = 0; ii < colA; ii++)
            {
                resultante[i,ii] = arryA[i,ii] + arryB[i,ii];
            }
        }

        return resultante;
    }

    public static void Main(string[] args)
    {
        Console.Clear();

        Productos[] productos = new Productos[3];
        string producto; double precio;
        bool seguir = false;

        for (int i = 0; i < productos.Length; i++)
        {
            seguir = false;
            do
            {
                try
                {
                    Console.Write($"ingrese producto: ");
                    producto = Console.ReadLine();
                    Console.WriteLine($"ingrese precio");
                    precio = double.Parse(Console.ReadLine());
                }

                catch (System.Exception)
                {
                    System.Console.WriteLine("formato incorrecto");
                    seguir = false;
                    throw;
                }

                productos[i] = new Productos(producto, precio);
                seguir = true;

            } while (seguir == false);


        }
        Console.WriteLine("");
        var total = 0.0;
        foreach (var item in productos)
        {
            Console.WriteLine($"\t\tproducto: {item.Producto}\t precio: $${item.precio}");
            total += item.precio;
        }
        Console.WriteLine($"**********************************\n\n \tTOTAL A PAGAR $${total}");

        Console.WriteLine($"desea eliminar un articulo");

        /*EJERCICIO 02*/
    
        Console.Write($"MATRIZ 2 X 2\n Ingresar numero de filas:");
        int filas = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese numero de columnas");
        int col = int.Parse(Console.ReadLine());
        int[,] arry2D = new int[filas, col];

        Console.Write($"MATRIZ 2 X 2\n Ingresar numero de filas:");
        int filas2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese numero de columnas");
        int col2 = int.Parse(Console.ReadLine());



        int[,] arry2D2 = new int[filas2, col2];

        for (int i = 0; i < filas; i++)//llenar ambos arry de 2x2
        {
            for (var ii = 0; ii < col; ii++)
            {
                arry2D[i, ii] = Random();
                arry2D2[i,ii]=Random();
            }
        }

        var total2D = 0;

        Ver2D(arry2D);
        Ver2D(arry2D2);
        System.Console.WriteLine($"Total de matrizces*** ");
        Ver2D(sumaMatriz(arry2D,arry2D2));
        int posicionX = 0, posicionY = 0;

        Console.WriteLine($"Ingrese la posicion que desea editar");
        posicionX = int.Parse(Console.ReadLine());
        posicionY = int.Parse(Console.ReadLine());
        Console.WriteLine($"Ingrese el nuevo valor de la posicion [{posicionX} ,{posicionY}]");

        var NuevoValor = int.Parse(Console.ReadLine());

        arry2D[posicionX, posicionY] = NuevoValor;
        Ver2D(arry2D);
        System.Console.WriteLine($"Total de matriz {Calcular2D(arry2D)}");









    }
}