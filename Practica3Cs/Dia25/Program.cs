public class Program
{
    public static int[] Dimenciones()
    {
        System.Console.Write("Ingrese las filas de la mtriz. -> ");
        int fila = Convert.ToInt32(Console.ReadLine());
        System.Console.Write("Ingrese las columnas de la mtriz. -> ");
        int columna = Convert.ToInt32(Console.ReadLine());

        int[] dim = { fila, columna };

        return dim;
    }

    public static void Main()
    {
        Console.WriteLine($"Ejercicio propuesto #1 \ndefinir por consola las dimenciones de una matriz de 2 por 2\n");

        Random numeros = new();
        var suma = 0;
        int[] dimen = Dimenciones();
        int fila = dimen[0];
        int columna = dimen[1];
        int[,] matriz = new int[fila, columna];//matriz con dimenciones ingresadas
        int[] sumatoria = new int[columna];


        for (int x = 0; x < fila; x++)
        {
            for (int y = 0; y < columna; y++)
            {
                matriz[x, y] = numeros.Next(0, 9);
                Console.Write(" [" + matriz[x, y] + "] ");
                suma += matriz[x, y];//suma de la las posiciones de columnas
                sumatoria[y] = suma;//agregar la sumatoria de una columna a un array
            }
            System.Console.WriteLine();
            suma = 0;//reiniciar total para cada sumatoria de columna nueva
        }

        foreach (var item in sumatoria)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine($"\nEjercicio propuesto #2 \nSumatoria de matrices\n");
        System.Console.Write("Indique la cantidad de matrices a sumar. -> ");
        var Cant = int.Parse(Console.ReadLine());



        int[] dimen2 = Dimenciones();//dimenciones 2
        int fila2 = dimen2[0];
        int columna2 = dimen2[1];
        int[,] matriz2 = new int[fila2, columna2];//matriz con dimenciones ingresadas
        
        for (int i = 0; i < Cant; i++)
        {
            for (int x = 0; x < fila2; x++)
            {
                for (int y = 0; y < columna2; y++)
                {
                    matriz2[x, y] = numeros.Next(0, 9);
                    Console.Write(" [" + matriz2[x, y] + "] ");
                    suma += matriz2[x, y];//suma de cada celda
                }
                System.Console.WriteLine();
            }
            Console.WriteLine($"----------");
            
        }
        Console.WriteLine($"Sumatoria de "+Cant+" matrices  de dimenciones " + fila + "x" +columna+ " es de: " + suma);
        
    }
}
