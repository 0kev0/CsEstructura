/********************************************************
*Nombre del archivo
*
*
*Nombre del programado                               
*
*
*Descripción del programa
*
*
********************************************************/

public class Practica
{
    public static void Main(string[] args)
    {
        Funciones Fn = new Funciones();

        Mav_Valor();

        // int o = Fn.AsignarNumeroPositivo();
        //System.Console.WriteLine(o);
        int[] eliminar = new int[] { 1, 2, 3, 4, 5, 6 };
        eliminar = NewMethod(eliminar);

        foreach (var item in eliminar)
        {
            Console.WriteLine($"{item}");
        }

    }
//encuentra el valor maximo en un array
    private static void Mav_Valor()
    {
        int[] array = new int[10];
        int max = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
    }

    // eliminar y redimancionar array
    private static int[] NewMethod(int[] eliminar)
    {
        var eli = int.Parse(s: Console.ReadLine());

        var nuevo = eliminar.Length - 1;
        int[] nuevoEliminar = new int[nuevo];

        var j = 0;

        for (var i = 0; i < eliminar.Length; i++)
        {
            if (eliminar[i] != eli)
            {
                nuevoEliminar[j] = eliminar[i];
                j++;
            }
        }
        eliminar = new int[nuevo];
        for (var i = 0; i < nuevoEliminar.Length; i++)
        {
            eliminar[i] = nuevoEliminar[i];
            j++;
        }
        return eliminar;
    }
}