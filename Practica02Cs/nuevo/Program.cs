using System;

namespace Principal
{
    class Program
    {
        public static void mostrar(Array arry)
        {
            foreach (var item in arry)
            {
                Console.WriteLine("[ " + item + " ]");
            }
        }

        public static void Encontrar(Array arry)
        {
            string search;
            System.Console.WriteLine("ingrese el digito a buscar: ");
            search = Console.ReadLine();

            var indx = 0;
            foreach (var item in arry)
                if (search == item.ToString())
                {
                    System.Console.WriteLine(item);
                    Console.WriteLine($"Elemento encontrado: " + search + " en la posicion " + indx);
                    indx++;
                }
        }

        static void Main(string[] args)
        {
            var a = 0;
            var suma = 0;

            Console.WriteLine($"ingrese la longitud del array \n");
            a = int.Parse(Console.ReadLine());

            int[] arr = new int[a];
            var ii = 1;
            for (var i = 0; i < arr.Count(); i++)
            {

                Console.WriteLine($"ingrese un elemento [ " + ii + " ] por favor \n"); ii++;
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($@"menu de operaciones 
 0- mostrar array 
 1-mostrar sumatoria 
 2-ver numero mayor. 
 2-ver numero mayor 
 4-encontrar un valor  
 5-modificar 
 6-Eliminar 
 5-salir");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 0:
                    mostrar(arr);
                    break;
                case 1:

                    break;
                case 2:
                    Console.WriteLine(arr.Max());

                    break;
                case 3:
                    Console.WriteLine(arr.Min());

                    break;
                case 4:
                    Encontrar(arr);
                    break;

                case 5:
                    Console.WriteLine($"ingrese el elemento a editar");
                    foreach (var item in arr)
                    {
                        Console.WriteLine($"[ "+ item +" ]\t");
                    }
                                        int ops = int.Parse(Console.ReadLine());

                    System.Console.WriteLine("ingrese nuevo valor");
                    int nuevo = int.Parse(Console.ReadLine());
                    arr[ops] = nuevo;

                    foreach (var item in arr)
                    {
                        Console.WriteLine("[ " + item + " ]");

                    }

                    break;
                case 6:
                    Console.WriteLine($"ingrese el numero a eliminar");
                    int opsE = int.Parse(Console.ReadLine()); 
                    List<int> o = new List<int> { };
                    foreach (var item in arr)
                    {
                        o.Add(item);
                    }
foreach (var item in o)
{
    var i =0;
    if (item == opsE)
    {
        o.RemoveAt(i);
        Console.WriteLine($"eliminado \n nuevo array: \n");
        
        break;
    }
    else
    {
        i++;
    }
}
                   foreach (var item in o)
                    {
                        Console.WriteLine(item);
                    }
                    break;
            }
        }
    }
}
