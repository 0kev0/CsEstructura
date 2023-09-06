
public class Program
{
    public static void main(String[] args)
    {
        Console.Clear();
        int Op = 0;
        int opcion;
        bool seguir = true;
        Console.WriteLine($"ejercicio practico**************************");

        List<string> pendings = new();
        do
        {
            Console.WriteLine($"Opcion a realizar 0/ver pendientes 1/agregar pendientes 2/Insertar pendientes 3/eliminar pendientes");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 0:
                    foreach (var item in pendings)
                    {
                        Console.WriteLine($">{item}");
                    }
                    break;

                case 1:
                    Console.Write($"Agregar pendiente");
                    string pendiente = Console.ReadLine();
                    pendings.Add(pendiente);

                    break;
                case 2:
                    Console.Write($"Insertar pendiente");
                    string pendientes = Console.ReadLine();
                    Console.WriteLine($"en que posicion?");
                    int indx = int.Parse(Console.ReadLine());
                    pendings.Insert(indx, pendientes);


                    break;
                case 3:
                    System.Console.WriteLine("Eliminar por indice");
                    var inx = int.Parse(Console.ReadLine());
                    pendings.RemoveAt(inx);

                    break;

                default:
                    Console.WriteLine($"Salir");
                    Environment.Exit(0);

                    break;
            }


            if (Op == 2)
            {
                seguir = false;
            }
        } while (seguir == true);
    }







    public class nums
    {
        public int un, dos, tres;

        public nums(int un, int dos, int tres)
        {
            this.un = un;
            this.dos = dos;
            this.tres = tres;
        }
    }
    public static void Main()
    {
        Console.Clear();
        int Op = 0;
        int opcion;
        bool seguir = true;

        List<string> pendings = new();
        do
        {
            Console.WriteLine($"Opcion a realizar 0/ver pendientes 1/agregar pendientes 2/Insertar pendientes 3/eliminar pendientes");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 0:
                    foreach (var item in pendings)
                    {
                        Console.WriteLine($">{item}");
                    }
                    break;

                case 1:
                    Console.Write($"Agregar pendiente");
                    string pendiente = Console.ReadLine();
                    pendings.Add(pendiente);

                    break;
                case 2:
                    Console.Write($"Insertar pendiente");
                    string pendientes = Console.ReadLine();
                    Console.WriteLine($"en que posicion?");
                    int indx = int.Parse(Console.ReadLine());
                    pendings.Insert(indx, pendientes);


                    break;
                case 3:
                    System.Console.WriteLine("Eliminar por indice");
                    var inx = int.Parse(Console.ReadLine());
                    pendings.RemoveAt(inx);

                    break;

                default:
                    Console.WriteLine($"Salir");
                    Environment.Exit(0);

                    break;
            }

            System.Console.WriteLine("Seguir? 2/no");
            Op = int.Parse(Console.ReadLine());
            if (Op == 2)
            {
                seguir = false;
            }
        } while (seguir == true);


        Console.WriteLine($"ejemplo***************");

        List<nums> Lista = new();
        Lista.Add(new nums(0, 2, 3));
        Random num = new Random();
        for (var i = 0; Lista.Count < 10; i++)
        {
            nums o = new nums(i, i, i);
            Lista.Add(o);
            Console.WriteLine($"{Lista[i].un}-{Lista[i].dos}-{Lista[i].tres}");
        }

        Console.WriteLine($"indice a eliminar");
        int indice = int.Parse(Console.ReadLine());

        Lista.RemoveAt(indice);
        System.Console.WriteLine();
        foreach (var item in Lista)
        {
            Console.WriteLine($"{item.un}-{item.dos}-{item.tres}");
        }
        System.Console.WriteLine();
        Lista.Remove(new nums(0, 2, 3));



        foreach (var item in Lista)
        {
            Console.WriteLine($"{item.un}-{item.dos}-{item.tres}");
        }
    }
}

