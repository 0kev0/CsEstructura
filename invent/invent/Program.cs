using System.Diagnostics;
using System.Net.Quic;
using System.Runtime.Intrinsics.Arm;

public class Program
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
        Queue<Invent> PEPSarroz = new();
        PEPSarroz.Enqueue(new Invent("Arroz", 2.2, 1));
        PEPSarroz.Enqueue(new Invent("Arroz", 2.4, 3));
        PEPSarroz.Enqueue(new Invent("Arroz", 2, 3));
        PEPSarroz.Enqueue(new Invent("Arroz", 1.6, 5));

        Queue<Invent> PEPSpan = new();
        PEPSpan.Enqueue(new Invent("pan", 2, 1));
        PEPSpan.Enqueue(new Invent("pan", 1.4, 3));
        PEPSpan.Enqueue(new Invent("pan", 1.1, 3));
        PEPSpan.Enqueue(new Invent("pan", 1.6, 5));


        Stack<Invent> UEPSarroz = new();
        UEPSarroz.Push(new Invent("Arroz", 1.5, 5));
        UEPSarroz.Push(new Invent("Arroz", 2.2, 4));
        UEPSarroz.Push(new Invent("Arroz", 1.2, 2));
        UEPSarroz.Push(new Invent("Arroz", 1, 1));

        Stack<Invent> UEPSpan = new();
        UEPSpan.Push(new Invent("pan", 2.1, 4));
        UEPSpan.Push(new Invent("pan", 1.9, 2));
        UEPSpan.Push(new Invent("pan", 1, 1));
        UEPSpan.Push(new Invent("pan", 1.5, 5));

        List<Queue<Invent>> PEPS = new()
        {
            new(UEPSpan),
            new(UEPSarroz)
        };

        List<Stack<Invent>> UEPS = new() {
            new(UEPSarroz),
            new(UEPSpan)
         };

        while (seguir)
        {
            System.Console.WriteLine("1/PEPS<QUEQUE>\t\t2/UEPS<STACK>");
            var op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1: //PEPS**********************************************************

                    Console.WriteLine($"1/Ver inventario total\t2/Ver inventario por producto\t3/Agregar nuevo producto\t4/hacer compra \t5/hacer VENTA");
                    var ops = int.Parse(Console.ReadLine());

                    //var invebt
                    switch (ops)
                    {
                        case 1://ver inventario total
                            ImprimirInventarioPEPS(PEPS);

                            break;

                        case 2://ver clase de productos 
                            ImpreimirClaseProductoPEPS(PEPS);

                            break;

                        case 3://agregar un nuevo producto
                            Console.Write($"ingrese el nombre del producto: ");
                            var name1 = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant1 = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio unitario: ");
                            var precio1 = double.Parse(Console.ReadLine());

                            Queue<Invent> PEPSnew = new();
                            PEPSnew.Enqueue(new(name1, precio1, cant1));
                            PEPS.Add(PEPSnew);

                            break;
                        case 4: //comprar de un tipo de producto
                            ImpreimirClaseProductoPEPS(PEPS);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var indx = int.Parse(Console.ReadLine());

                            Console.WriteLine($"introduzca el nombre del producto");
                            var name = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio unitario: ");
                            var precio = double.Parse(Console.ReadLine());

                            for (var i = 0; i < PEPS.Count; i++)
                            {
                                if (indx == i)
                                {
                                    PEPS[i].Enqueue(new(name, precio, cant));
                                }

                            }

                            //     inventPEPS.Enqueue(new Invent(name, precio, cant));

                            break;
                        case 5: //venta
                            Console.WriteLine($"que calse de producto desea vender?");
                            ImpreimirClaseProductoPEPS(PEPS);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var tipo = int.Parse(Console.ReadLine());

                            for (var i = 0; i < PEPS.Count; i++)
                            {//por cada stack en la lista de stacks
                                foreach (var item in PEPS[i])
                                {
                                    if (tipo == i)
                                    {
                                        VentaPEPS(PEPS[i]);
                                    }
                                }
                            }
                            break;
                        default:
                            Console.WriteLine($"opcion invalida");

                            break;
                    }

                    break;

                case 2: //UEPS**********************************************************
                    Console.WriteLine($"1/Ver inventario total\t2/Ver inventario por producto\t3/Agregar nuevo producto\t4/hacer compra \t5/hacer VENTA");
                    var ops2 = int.Parse(Console.ReadLine());
                    //var invebt
                    switch (ops2)
                    {
                        case 1:
                            ImprimirInventarioUEPS(UEPS);

                            break;
                        case 2: //clases de productos
                            ImpreimirClaseProductoUEPS(UEPS);

                            break;
                        case 3: //agregar producto
                            Console.Write($"ingrese el nombre del producto: ");
                            var name1 = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant1 = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio unitario: ");
                            var precio1 = double.Parse(Console.ReadLine());

                            Stack<Invent> UEPSnew = new();
                            UEPSnew.Push(new(name1, precio1, cant1));
                            UEPS.Add(UEPSnew);

                            break;

                        case 4:
                            ImpreimirClaseProductoUEPS(UEPS);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var indx = int.Parse(Console.ReadLine());

                            Console.WriteLine($"introduzca el nombre del producto");
                            var name = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio unitario: ");
                            var precio = double.Parse(Console.ReadLine());

                            for (var i = 0; i < UEPS.Count; i++)
                            {
                                if (indx == i)
                                {
                                    UEPS[i].Push(new(name, precio, cant));
                                }
                            }

                            break;

                        case 5:
                            Console.WriteLine($"que calse de producto desea vender?");
                            ImpreimirClaseProductoUEPS(UEPS);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var tipo = int.Parse(Console.ReadLine());

                            for (var i = 0; i < UEPS.Count; i++)
                            {//por cada stack en la lista de stacks
                                foreach (var item in UEPS[i])
                                {
                                    if (tipo == i)
                                    {
                                        VentaUEPS(UEPS[i]);
                                    }
                                }
                            }

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
    private static void ImprimirInventarioUEPS(List<Stack<Invent>> inventUEPS)
    {
        var i = 1; var ii = 1;

        Console.WriteLine($"[-producto-]\t[-precio-]\t[-cantidad-");

        foreach (Stack<Invent> lista in inventUEPS)
        {
            Console.WriteLine($"\t\t\t\tPRODUCTO:" + ii);

            foreach (Invent item in lista)
            {
                Console.WriteLine($"{i} - [{item.product}]\t- [{item.precio}_$$]\t- [{item.cant}]"); i++;
            }
            Console.WriteLine($"---------------------------------");
            i++;

        }
    }

    private static void ImpreimirClaseProductoUEPS(List<Stack<Invent>> UEPS)
    {
        Console.WriteLine($"De cual producto desea ver inventario");
        string nombres = "";
        for (var i = 0; i < UEPS.Count; i++)
        {

            foreach (var item in UEPS[i])
            {
                nombres += i + " " + item.product + "\n"; break;
            }
        }
        Console.WriteLine(nombres);
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

    private static void VentaUEPS(Stack<Invent> inventUEPS)
    {

        Console.Write($"ingrese cantidad a comprar: ");
        var cantCompr = int.Parse(Console.ReadLine());

        var total = 0.0;
        var i = 1;
        while (cantCompr > 0)
        {
            var venta = (cantCompr > inventUEPS.Peek().cant) ? inventUEPS.Peek().cant : cantCompr;
            double subtot = inventUEPS.Peek().precio * venta;//saca subtotal de precio*cant
            
            cantCompr = cantCompr - inventUEPS.Peek().cant; //se hace resta de cantidad vendida
            inventUEPS.Peek().cant = inventUEPS.Peek().cant - cantCompr; //restar producto vendido del inventario
            inventUEPS.Peek().cant = (inventUEPS.Peek().cant <= 0) ? 0 : inventUEPS.Peek().cant;//si se excede la cantidad disponible de asigna 0 

            ColorChange("azul");
            Console.WriteLine($"{i}>Venta realizada: [{venta}] {inventUEPS.Peek().product} al precio de {inventUEPS.Peek().precio}$$ quedan en inventario {inventUEPS.Peek().cant}.");
            ResetColor();

            cantCompr = (cantCompr < 0) ? 0 : cantCompr;//asignar el valor que queda por vender, si la resta da menor a 0 se asigna 0
            Console.Write($"\t\tSubtotal por venta {Math.Round(subtot,4)}_$$\t quedan por vender {cantCompr} unidades.\n");
            Console.ReadKey();

            if (inventUEPS.Peek().cant > 0)
            {
                inventUEPS.Peek().cant = inventUEPS.Peek().cant - venta;
                inventUEPS.Peek().cant = (inventUEPS.Peek().cant < 0) ? 0 : inventUEPS.Peek().cant;
                Console.WriteLine($"Quedan {inventUEPS.Peek().cant} en inventario a {inventUEPS.Peek().precio}");
                Console.WriteLine($"----------------------------------------------------------------------"); Console.ReadKey();
            }
            if (inventUEPS.Peek().cant <= 0)
            {
                inventUEPS.Pop();
                ColorChange("rojo");
                Console.WriteLine($"borrado de inventairio");

                Console.WriteLine($"----------------------------------------------------------------------");
                ResetColor(); Console.ReadKey();
            }

            total += Math.Round(subtot,4); //se hace sumatoria de cada venta
            Console.ReadKey();i++;
        }
        ColorChange("verde");
        Console.WriteLine($"**********************************************************************");
        Console.WriteLine($"Venta satisfactoria total de {Math.Round(total,3)} $$");
        Console.WriteLine($"**********************************************************************");
        ResetColor();
        Console.ReadKey();
    }

    /*****************************PEPS/Queque*********************************************/
    private static void ImprimirInventarioPEPS(List<Queue<Invent>> inventPEPS)
    {
        var i = 1; var ii = 1;
        Console.WriteLine($"[-producto-]\t[-precio-]\t[-cantidad-");

        foreach (Queue<Invent> lista in inventPEPS)
        {
            Console.WriteLine($"\t\t\t\tPRODUCTO: " + ii);

            foreach (Invent item in lista)
            {
                Console.WriteLine($"{i} - [{item.product}]\t- [{item.precio}_$$]\t- [{item.cant}]");
                i++;
            }
            Console.WriteLine($"---------------------------------\n");
            ii++;
        }
    }

    private static void ImpreimirClaseProductoPEPS(List<Queue<Invent>> PEPS)
    {
        Console.WriteLine($"De cual producto desea ver inventario");
        string nombres = "";
        for (var i = 0; i < PEPS.Count; i++)
        {
            foreach (var item in PEPS[i])
            {
                nombres += i + " " + item.product + "\n"; break;
            }
        }
        Console.WriteLine(nombres);
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

    private static void VentaPEPS(Queue<Invent> inventPEPS)
    {
        Console.Write($"ingrese cantidad a comprar: ");
        var cantCompr = int.Parse(Console.ReadLine());

        var total = 0.0;
        var i = 1;
        while (cantCompr > 0)
        {
            var venta = (cantCompr > inventPEPS.Peek().cant) ? inventPEPS.Peek().cant : cantCompr;
            double subtot = inventPEPS.Peek().precio * venta;//saca subtotal de precio*cant

            cantCompr = cantCompr - inventPEPS.Peek().cant; //se hace resta de cantidad vendida
            inventPEPS.Peek().cant = inventPEPS.Peek().cant - cantCompr; //restar producto vendido del inventario
            inventPEPS.Peek().cant = (inventPEPS.Peek().cant <= 0) ? 0 : inventPEPS.Peek().cant;//si se excede la cantidad disponible de asigna 0 

            ColorChange("azul");
            Console.WriteLine($"{i}>Venta realizada: [{venta}] {inventPEPS.Peek().product} al precio de {inventPEPS.Peek().precio}$$ quedan en inventario {inventPEPS.Peek().cant}.");
            ResetColor();

            cantCompr = (cantCompr < 0) ? 0 : cantCompr;//asignar el valor que queda por vender, si la resta da menor a 0 se asigna 0
            Console.Write($"\t\tSubtotal por venta {Math.Round(subtot,4)}_$$\t quedan por vender {cantCompr} unidades.\n");
            Console.ReadKey();

            if (inventPEPS.Peek().cant > 0)
            {
                inventPEPS.Peek().cant = inventPEPS.Peek().cant - venta;
                inventPEPS.Peek().cant = (inventPEPS.Peek().cant < 0) ? 0 : inventPEPS.Peek().cant;
                Console.WriteLine($"Quedan {inventPEPS.Peek().cant} en inventario a {inventPEPS.Peek().precio}");
                Console.WriteLine($"----------------------------------------------------------------------"); Console.ReadKey();
            }
            if (inventPEPS.Peek().cant <= 0)
            {
                inventPEPS.Dequeue();
                ColorChange("rojo");
                Console.WriteLine($"borrado de inventairio");

                Console.WriteLine($"----------------------------------------------------------------------");
                ResetColor(); Console.ReadKey();
            }

            total += Math.Round(subtot); //se hace sumatoria de cada venta
            Console.ReadKey();i++;
        }

        ColorChange("verde");
        Console.WriteLine($"**********************************************************************");
        Console.WriteLine($"Venta satisfactoria total de {Math.Round(total,3)} $$");
        Console.WriteLine($"**********************************************************************");
        ResetColor();
        Console.ReadKey();
    }
}
