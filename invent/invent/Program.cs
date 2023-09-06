using System.Diagnostics;

public class program
{
    static void ColorChange(String color)
    {
        _ = color.ToLower();

        switch (color)
        {
            case "rojo":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case "azul":
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case "verde":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
        }
    }

    static void ResetColor()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    public class Invent
    {
        public string product;
        public double precio;
        public int cant;

        public Invent(string product, double precio, int cant)
        {
            this.product = product;
            this.precio = precio;
            this.cant = cant;
        }
    }

    public static void Main()
    {
        bool seguir = true;

        while (seguir)
        {
            System.Console.WriteLine("1/PEPS 2/UEPS");
            var op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1: //PEPS**********************************************************
                    Queue<Invent> inventUEPS = new();
                    inventUEPS.Enqueue(new Invent("Arroz", 2.2, 6));

                    Console.WriteLine($"1/Ver inventario\t2/Hacer venta\t3/hacer compra");
                    op = int.Parse(Console.ReadLine());

                    //var invebt
                    switch (op)
                    {
                        case 1:
                            ImprimirInventarioUEPS(inventUEPS);

                            break;
                        case 2: //compra
                            ImprimirInventarioUEPS(inventUEPS);
                            Console.WriteLine($"Que producto desea comprar ?");

                            break;
                        case 3: //venta

                            break;
                        default:
                            Console.WriteLine($"opcion invalida");

                            break;
                    }

                    break;

                case 2: //UEPS**********************************************************
                    Stack<Invent> inventarioPEPS = new();
                    inventarioPEPS.Push(new Invent("Arroz", 2.2, 6));
                    //var invebt
                    switch (op)
                    {
                        case 1:

                            ImprimirInventarioPEPS(inventarioPEPS);

                            break;
                        case 2: //compra
                            Console.Write($"Que producto desea comprar ?");
                            var nombre = Console.ReadLine();
                            Console.Write($"precio unitario?...");
                            var precio = double.Parse(Console.ReadLine());
                            Console.WriteLine($"ingrese la cantidad a comprar");
                            var cant = int.Parse(Console.ReadLine());
                            inventarioPEPS.Push(new Invent(nombre, precio, cant));
                            Console.WriteLine($"-COMPRA EXITOSA-");

                            break;
                        case 3: //venta
                            ImprimirInventarioPEPS(inventarioPEPS);
                            Console.Write($"Que producto desea vender ?");
                            var ops = int.Parse(Console.ReadLine());

                            break;
                        default:
                            Console.WriteLine($"opcion invalida");

                            break;
                    }
                    break;

                default:
                    Console.WriteLine($"opcion invalida");

                    break;
            }

            Console.WriteLine($"seguir? 1/si 2/no");
            seguir = (int.Parse(Console.ReadLine()) == 1) ? true : false;
        }
    }

    /*****************************UEPS*********************************************/
    private static void ImprimirInventarioUEPS(Queue<Invent> inventUEPS)
    {
        var i = 1;
        foreach (var item in inventUEPS)
        {
            Console.WriteLine($"{i} - [{item.product}]\t- [{item.precio}]\t- [{item.cant}]");
            i++;
        }
    }

    private static void VerProductsUEPS(Queue<Invent> inventUEPS)
    {
        for (var i = 0; i < inventUEPS.Count - 1; i++)
        {
            if (i == 0)
            {
                Console.WriteLine($"{i}-\t{inventUEPS.ElementAt(0)}");
            }

            if (inventUEPS.ElementAt(i).product != inventUEPS.ElementAt(i - 1).product && i > 0)
            {
                Console.WriteLine($"{i}-\t{inventUEPS.ElementAt(i).product}");
            }
        }
    }

    /*****************************PEPS*********************************************/
    private static void ImprimirInventarioPEPS(Stack<Invent> inventPEPS)
    {
        var i = 1;
        foreach (var item in inventPEPS)
        {
            Console.WriteLine($"{i} - [{item.product}]\t- [{item.precio}]\t- [{item.cant}]");
            i++;
        }
    }

    private static void VerProductsPEPS(Stack<Invent> inventPEPS)
    {
        for (var i = 0; i < inventPEPS.Count - 1; i++)
        {
            if (i == 0)
            {
                Console.WriteLine($"{i}-\t{inventPEPS.ElementAt(0)}");
            }

            if (inventPEPS.ElementAt(i).product != inventPEPS.ElementAt(i - 1).product && i > 0)
            {
                Console.WriteLine($"{i}-\t{inventPEPS.ElementAt(i).product}");
            }
        }
    }
}
