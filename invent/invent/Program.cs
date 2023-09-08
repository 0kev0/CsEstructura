using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

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
        Console.Clear();

        bool seguir = true;
        Queue<Invent> inventPEPS = new();
        inventPEPS.Enqueue(new Invent("Arroz", 2.2, 6));
        inventPEPS.Enqueue(new Invent("Arroz", 2.5, 6));
        Stack<Invent> inventUEPS = new();
        inventUEPS.Push(new Invent("Arroz", 2.5, 6));
        inventUEPS.Push(new Invent("Arroz", 2.2, 6));
        inventUEPS.Push(new Invent("Arroz", 1, 2));

        while (seguir)
        {
            System.Console.WriteLine("1/PEPS 2/UEPS");
            var op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1: //PEPS**********************************************************

                    Console.WriteLine($"1/Ver inventario\t2/Hacer venta\t3/hacer compra");
                    var ops = int.Parse(Console.ReadLine());

                    //var invebt
                    switch (ops)
                    {
                        case 1:
                            ImprimirInventarioPEPS(inventPEPS);

                            break;
                        case 2: //compra

                            ImprimirInventarioPEPS(inventPEPS);
                            Console.Write($"ingrese el nombre del producto: ");
                            var name = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio unitario: ");
                            var precio = double.Parse(Console.ReadLine());

                            inventPEPS.Enqueue(new Invent(name, precio, cant));

                            break;
                        case 3: //venta

                            break;
                        default:
                            Console.WriteLine($"opcion invalida");

                            break;
                    }

                    break;

                case 2: //UEPS**********************************************************
                    Console.WriteLine($"1/Ver inventario\t2/Hacer venta\t3/hacer compra");
                    var ops2 = int.Parse(Console.ReadLine());
                    //var invebt
                    switch (ops2)
                    {
                        case 1:
                            ImprimirInventarioUEPS(inventUEPS);

                            break;
                        case 2: //compra
                            Console.Write($"Que producto desea comprar ?");
                            var nombre = Console.ReadLine();
                            Console.Write($"precio unitario?...");
                            var precio = double.Parse(Console.ReadLine());
                            Console.WriteLine($"ingrese la cantidad a comprar");
                            var cant = int.Parse(Console.ReadLine());
                            inventUEPS.Push(new Invent(nombre, precio, cant));
                            Console.WriteLine($"-COMPRA EXITOSA-");

                            break;
                        case 3: //venta
                            ImprimirInventarioUEPS(inventUEPS);
                            Console.Write($"Que producto desea vender ?");
                            var opVender = Console.ReadLine();
                            Console.WriteLine($"ingrese cantidad a comprar");
                            var cantCompr = int.Parse(Console.ReadLine());

                            var total = 0.0;
                            while (cantCompr > 0)
                            {
                                
                                Console.WriteLine(
                                    $"Venta realizada: {inventUEPS.Peek().product}/a {inventUEPS.Peek().precio}$$/ y hay {inventUEPS.Peek().cant}"
                                );
                                var subtot = 0.0;
                                Console.WriteLine($"{subtot}");
                                
                              //  var cantvendida = (cantCompr > inventUEPS.Peek().cant ) ?inventUEPS.Peek().cant :  inventUEPS.Peek().cant-cantCompr  ;
                                subtot = inventUEPS.Peek().precio * subtot; //se saca subtotal de venta
                                Console.WriteLine($"{cantCompr} - {inventUEPS.Peek().cant};");
                                
                                cantCompr = cantCompr - inventUEPS.Peek().cant; //se hace resta de cantidad vendida

                                inventUEPS.Peek().cant = inventUEPS.Peek().cant - cantCompr; //restar producto vendido del inventario


                                Console.WriteLine(
                                    $"subtotal por venta {subtot}\tquedan por vender {cantCompr}"
                                );

                                if (inventUEPS.Peek().cant <= 0)
                                {
                                    inventUEPS.Pop();
                                    Console.WriteLine($"borrado");
                                }
                                else
                                {
                                    Console.WriteLine($"quedan {inventUEPS.Peek().cant} en invent");
                                    break;
                                }
                                total += subtot; //se hace sumatoria de cada venta
                            }
                            Console.WriteLine($"Venta satisfactoria total de {total}");

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

    /*****************************UEPS/STACK*********************************************/
    private static void ImprimirInventarioUEPS(Stack<Invent> inventUEPS)
    {
        var i = 1;
        List<Invent> list = inventUEPS.ToList();
        foreach (var item in list)
        {
            Console.WriteLine($"{i} - [{item.product}]\t- [{item.precio}]\t- [{item.cant}]");
            i++;
        }
    }

    private static void VerProductsUEPS(Stack<Invent> inventUEPS)
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

    /*****************************PEPS/Queque*********************************************/
    private static void ImprimirInventarioPEPS(Queue<Invent> inventPEPS)
    {
        var i = 1;
        List<Invent> list = inventPEPS.ToList();
        foreach (var item in list)
        {
            Console.WriteLine($"{i} - [{item.product}]\t- [{item.precio}]\t- [{item.cant}]");
            i++;
        }
    }

    private static void VerProductsPEPS(Queue<Invent> inventPEPS)
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
