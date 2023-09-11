using System.Diagnostics;
using System.Drawing;
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
        public double precioC;
        public double precioV;
        public int cant;

        public Invent(string product, double precioC, double precioV, int cant)
        {
            this.product = product;
            this.precioC = precioC;
            this.precioV = precioV;
            this.cant = cant;
        }
    }

    public static void Main()
    {
        Console.Clear();

        bool seguir = true;

        Queue<Invent> PEPSarroz = new();
        PEPSarroz.Enqueue(new Invent("Arroz", 2.2, 2.3, 1));
        PEPSarroz.Enqueue(new Invent("Arroz", 2.4, 2.6, 3));
        PEPSarroz.Enqueue(new Invent("Arroz", 2, 2.15, 3));
        PEPSarroz.Enqueue(new Invent("Arroz", 1.6, 2.0, 5));

        Queue<Invent> PEPSpan = new();
        PEPSpan.Enqueue(new Invent("pan", 2, 2.3, 1));
        PEPSpan.Enqueue(new Invent("pan", 1.4, 1.55, 3));
        PEPSpan.Enqueue(new Invent("pan", 1.1, 1.4, 3));
        PEPSpan.Enqueue(new Invent("pan", 1.6, 1.8, 5));

        Queue<Invent> PEPShuevo = new();
        PEPSpan.Enqueue(new Invent("huevo", 2, 2.15, 1));
        PEPSpan.Enqueue(new Invent("huevo", 1.4, 1.7, 3));

        List<Queue<Invent>> PEPScompra = new()
        {
            new(PEPSpan),
            new(PEPSarroz),
            new(PEPShuevo)
        };

        List<string> resumenPEPS = new();
        List<Invent> entradasPEPS = new();
        Entradas_existenciasPEPS(PEPScompra, resumenPEPS);


        /***********************UEPS*/
        Stack<Invent> UEPSarroz = new();
        UEPSarroz.Push(new Invent("Arroz", 1.5, 1.55, 5));
        UEPSarroz.Push(new Invent("Arroz", 2.2, 2.5, 4));
        UEPSarroz.Push(new Invent("Arroz", 1.2, 1.23, 2));
        UEPSarroz.Push(new Invent("Arroz", 1, 1.4, 1));

        Stack<Invent> UEPSpan = new();
        UEPSpan.Push(new Invent("pan", 2.1, 2.15, 4));
        UEPSpan.Push(new Invent("pan", 1.9, 2.1, 2));
        UEPSpan.Push(new Invent("pan", 1, 1.15, 1));
        UEPSpan.Push(new Invent("pan", 1.5, 1.66, 5));

        Queue<Invent> UEPShuevo = new();
        PEPSpan.Enqueue(new Invent("huevo", 2, 2.1, 1));
        PEPSpan.Enqueue(new Invent("huevo", 1.4, 1.15, 3));



        List<Stack<Invent>> UEPScompra = new() {
            new(UEPSarroz),
            new(UEPSpan),
            new(UEPShuevo)
        };
        List<string> resumenUEPS = new();
        List<Invent> PEPSventa = new() { };

        List<Invent> UEPSventa = new() { };
        Entradas_existenciasUEPS(UEPScompra, resumenUEPS);



        while (seguir)
        {

            Console.WriteLine("1/PEPS<QUEQUE>\t\t2/UEPS<STACK>\t\tCoso promedio");
            var op = int.Parse(s: Console.ReadLine());

            switch (op)
            {
                case 1: //PEPS**********************************************************

                    Console.WriteLine($"1/Ver inventario total\t2/Ver inventario por producto\t3/Agregar nuevo producto\t4/hacer compra \t5/hacer VENTA\t6/resumen");
                    var ops = int.Parse(Console.ReadLine());

                    //var invebt
                    switch (ops)
                    {
                        case 1://ver inventario total
                            ImprimirInventarioPEPS(PEPScompra);
                            Console.ReadKey();
                            Console.Clear();


                            break;

                        case 2://ver clase de productos 
                            ImpreimirClaseProductoPEPS(PEPScompra);
                            Console.ReadKey();
                            Console.Clear();

                            break;

                        case 3://agregar un nuevo producto
                            Console.Write($"ingrese el nombre del producto: ");
                            var name1 = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant1 = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio de compra: ");
                            var precioC = double.Parse(Console.ReadLine());
                            Console.Write($"ingrese el precio de venta: ");
                            var precioV = double.Parse(Console.ReadLine());

                            Queue<Invent> PEPSnew = new();
                            PEPSnew.Enqueue(new(name1, precioC, precioV, cant1));
                            PEPScompra.Add(PEPSnew);
                            entradasPEPS.Add(new(name1, precioC, precioV, cant1));
                            resumenPEPS.Add(name1 + " -     " + precioC + "$-     " + precioV + "$-     " + cant1 + "u                                                                 ");

                            ColorChange("verde");
                            Console.WriteLine($"--------------------------------\nagregado stisfacroriamente\n--------------------------------");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();


                            break;
                        case 4: //comprar de un tipo de producto
                            ImpreimirClaseProductoPEPS(PEPScompra);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var indx = int.Parse(Console.ReadLine());

                            Console.WriteLine($"introduzca el nombre del producto");
                            var name = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio de compra: ");
                            var precioC2 = double.Parse(Console.ReadLine());
                            Console.Write($"ingrese el precio de venta: ");
                            var precioV2 = double.Parse(Console.ReadLine());

                            for (var i = 0; i < PEPScompra.Count; i++)
                            {
                                if (indx == i)
                                {
                                    PEPScompra[i].Enqueue(new(name, precioC2, precioV2, cant));
                                    resumenPEPS.Add(name + " -     " + precioC2 + "$-      " + precioV2 + "$-     " + cant + "u                                                                 ");
                                }

                            }
                            ColorChange("verde");
                            Console.WriteLine($"--------------------------------\nagregado stisfacroriamente\n--------------------------------");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case 5: //venta
                            Console.WriteLine($"que calse de producto desea vender?");
                            ImpreimirClaseProductoPEPS(PEPScompra);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var tipo = int.Parse(Console.ReadLine());

                            for (var i = 0; i < PEPScompra.Count; i++)
                            {//por cada stack en la lista de stacks

                                foreach (var item in PEPScompra[i])
                                {
                                    if (tipo == i)
                                    {
                                        VentaPEPS(PEPScompra[i], PEPSventa, resumenPEPS); break;
                                    }
                                }


                            }
                            ColorChange("azul");
                            Console.WriteLine($"\n\n--------------------------------\n fin de venta \n--------------------------------");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Entradas_existenciasPEPS(PEPScompra, resumenPEPS);
                            Console.WriteLine($"  ENTRADAS                               SALIDAS                               EXISTENCIAS");
                            Console.WriteLine($"[producto---costo---precio---cantidad_][producto---costo---precio---cantidad_][producto---costo---precio---cantidad");


                            for (int i = 0; i < resumenPEPS.Count; i++)
                            {
                                Console.WriteLine($"{resumenPEPS[i]}");

                            }

                            ColorChange("verde");
                            Console.WriteLine($"********************************************************************************* ");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            ColorChange("rojo");
                            Console.WriteLine($"--------------------------------\n opcion invalida \n--------------------------------");
                            Console.ReadKey();
                            ResetColor();
                            Console.Clear();


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
                            ImprimirInventarioUEPS(UEPScompra);

                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case 2: //clases de productos
                            ImpreimirClaseProductoUEPS(UEPScompra);


                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case 3: //agregar producto
                            Console.Write($"ingrese el nombre del producto: ");
                            var name1 = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant1 = int.Parse((Console.ReadLine()));
                            Console.Write($"ingrese el precio de compra: ");
                            var precioC = double.Parse(Console.ReadLine());
                            Console.Write($"ingrese el precio de venta: ");
                            var precioV = double.Parse(Console.ReadLine());

                            Stack<Invent> UEPSnew = new();
                            UEPSnew.Push(new(name1, precioV, precioC, cant1));
                            UEPScompra.Add(UEPSnew);
                            resumenUEPS.Add(name1 + " -     " + precioC + "$-     " + precioV + "$-     " + cant1 + "u                                                                 ");
                            ColorChange("verde");
                            Console.WriteLine($"--------------------------------\nagregado stisfacroriamente\n--------------------------------");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 4:
                            ImpreimirClaseProductoUEPS(UEPScompra);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var indx = int.Parse(Console.ReadLine());

                            Console.WriteLine($"introduzca el nombre del producto");
                            var name = Console.ReadLine();
                            Console.Write($"Ingrese la cantidad a comprar");
                            var cant = int.Parse((Console.ReadLine()));
                            var precioC2 = double.Parse(Console.ReadLine());
                            Console.Write($"ingrese el precio unitario: ");
                            var precioV2 = double.Parse(Console.ReadLine());

                            for (var i = 0; i < UEPScompra.Count; i++)
                            {
                                if (indx == i)
                                {
                                    UEPScompra[i].Push(new(name, precioC2, precioV2, cant));
                                    resumenPEPS.Add(name + " -     " + precioC2 + "$-     " + precioV2 + "$-     " + cant + "u                                                                 ");

                                }
                            }
                            ColorChange("verde");
                            Console.WriteLine($"--------------------------------\nagregado stisfacroriamente\n--------------------------------");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 5:
                            Console.WriteLine($"que calse de producto desea vender?");
                            ImpreimirClaseProductoUEPS(UEPScompra);
                            Console.WriteLine($"introduzca el indice del progucto a comprar: ");
                            var tipo = int.Parse(Console.ReadLine());

                            for (var i = 0; i < UEPScompra.Count; i++)
                            {//por cada stack en la lista de stacks
                                foreach (var item in UEPScompra[i])
                                {
                                    if (tipo == i)
                                    {
                                        VentaUEPS(UEPScompra[i], UEPSventa, resumenUEPS); break;
                                    }
                                }
                            }
                            ColorChange("azul");
                            Console.WriteLine($"\n\n--------------------------------\n fin de venta \n--------------------------------");
                            ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        default:
                            ColorChange("rojo");
                            Console.WriteLine($"--------------------------------\n opcion invalida \n--------------------------------");
                            Console.ReadKey();
                            ResetColor();
                            Console.Clear();
                            break;
                    }
                    break;



                case 3://costo promedio ***************************************************
                    Console.WriteLine($"resumen de ventas del mes, cada inventario vaicado es agregado al libro mayor...0");
                    ColorChange("azul");
                    Console.WriteLine($"[No.][producto][cantidad][costo unitario][precio venta][margen]");
                    Console.WriteLine($"manejo de inventario UEPS");
                    ResetColor();

                    for (int i = 0; i < UEPSventa.Count; i++)
                    {
                        var margen = (UEPSventa[i].cant * UEPSventa[i].precioV) - (UEPSventa[i].cant * UEPSventa[i].precioC);
                        Console.WriteLine($"[{i}>   [{UEPSventa[i].product}]          {UEPSventa[i].cant}          {UEPSventa[i].precioC}" + $"          {UEPSventa[i].precioV}        " + Math.Round(margen, 4) + "]");
                    }

                    ColorChange("azul");
                    Console.WriteLine($"[No.][producto][cantidad][costo unitario][precio venta][margen]");
                    Console.WriteLine($"manejo de inventario UEPS");
                    ResetColor();
                    for (int i = 0; i < PEPSventa.Count; i++)
                    {
                        var margen = (PEPSventa[i].cant * PEPSventa[i].precioV) - (PEPSventa[i].cant * PEPSventa[i].precioC);
                        Console.WriteLine($"[{i}>   [{PEPSventa[i].product}]          {PEPSventa[i].cant}          {PEPSventa[i].precioC}" + $"          {PEPSventa[i].precioV}          " + Math.Round(margen, 4) + "]");
                    }


                    break;
                default:
                            ColorChange("rojo");
                            Console.WriteLine($"--------------------------------\n opcion invalida \n--------------------------------");
                            Console.ReadKey();
                            ResetColor();
                            Console.Clear();
                    break;
            }

            Console.WriteLine($"seguir? 1/si 2/no");
            seguir = (int.Parse(Console.ReadLine()) == 1) ? true : false;
        }
    }

    /*****************************UEPS/STACK*********************************************/
    private static void Entradas_existenciasUEPS(List<Stack<Invent>> PEPS, List<string> resumen)
    {

        for (var i = 0; i < PEPS.Count; i++)
        {

            foreach (var item in PEPS[i])
            {
                resumen.Add("                                                                                           " + item.product + " -     " + item.precioC + "$-     " + item.precioV + "$     " + item.cant + "u");
            }
        }
    }
    private static void ImprimirInventarioUEPS(List<Stack<Invent>> inventUEPS)
    {
        var i = 1; var ii = 1;

        Console.WriteLine($"[-producto-]\t[-precio de compra-]\t[-precio de venta-]\t[-cantidad-");

        foreach (Stack<Invent> lista in inventUEPS)
        {
            foreach (Invent item in lista)
            {
                Console.WriteLine($"{i} - [{item.product}]\t[{item.precioC} $$]\t\t-[{item.precioV} $$]\t\t- [{item.cant}]"); i++;
            }
            Console.WriteLine($"---------------------------------");
            i++;

        }
    }


    private static void ImpreimirClaseProductoUEPS(List<Stack<Invent>> UEPS)
    {
        Console.WriteLine($"Productos en existencia");        string nombres = "";
        for (var i = 0; i < UEPS.Count; i++)
        {

            foreach (var item in UEPS[i])
            {
                nombres += i + " " + item.product + "\n"; break;
            }
        }
        Console.WriteLine(nombres);
    }


    private static void VentaUEPS(Stack<Invent> inventUEPS, List<Invent> UEPSventa, List<string> reumenUEPS)
    {

        Console.Write($"ingrese cantidad a comprar: ");
        var cantCompr = int.Parse(Console.ReadLine());

        var total = 0.0;
        var i = 1;
        while (cantCompr > 0 && inventUEPS.Count > 0)

        //adfesrfewsfgsdf

        {
            var cantinicial = inventUEPS.Peek().cant;
            var venta = (cantCompr > inventUEPS.Peek().cant) ? inventUEPS.Peek().cant : cantCompr;
            double subtot = inventUEPS.Peek().precioV * venta;//saca subtotal de precio*cant

            cantCompr = cantCompr - inventUEPS.Peek().cant; //se hace resta de cantidad vendida
            inventUEPS.Peek().cant = inventUEPS.Peek().cant - cantCompr; //restar producto vendido del inventario
            inventUEPS.Peek().cant = (inventUEPS.Peek().cant <= 0) ? 0 : inventUEPS.Peek().cant;//si se excede la cantidad disponible de asigna 0 

            ColorChange("azul");
            Console.WriteLine($"{i}>Venta realizada: [{venta}] {inventUEPS.Peek().product} al precio de {inventUEPS.Peek().precioV}$$ quedan en inventario {inventUEPS.Peek().cant}.");
            ResetColor();

            cantCompr = (cantCompr < 0) ? 0 : cantCompr;//asignar el valor que queda por vender, si la resta da menor a 0 se asigna 0
            Console.Write($"\t\tSubtotal por venta {Math.Round(subtot, 4)}_$$\t quedan por vender {cantCompr} unidades.\n");
            Console.ReadKey();

            if (inventUEPS.Peek().cant > 0)
            {
                reumenUEPS.Add("                                         " + inventUEPS.Peek().product + " - " + inventUEPS.Peek().precioC + "$- " + inventUEPS.Peek().precioV + "$- " + cantCompr + "u                             ");
                inventUEPS.Peek().cant = inventUEPS.Peek().cant - venta;
                inventUEPS.Peek().cant = (inventUEPS.Peek().cant < 0) ? 0 : inventUEPS.Peek().cant;
                Console.WriteLine($"Quedan {inventUEPS.Peek().cant} en inventario a {inventUEPS.Peek().precioV}");
                Console.WriteLine($"----------------------------------------------------------------------"); Console.ReadKey();
            }
            if (inventUEPS.Peek().cant <= 0)
            {
                inventUEPS.Peek().cant = cantinicial;
                UEPSventa.Add(inventUEPS.Peek());//cuando se acaba el inventario se es enviado a registro 
                reumenUEPS.Add("                                         " + inventUEPS.Peek().product + " - " + inventUEPS.Peek().precioC + "$- " + inventUEPS.Peek().precioV + "$- " + cantinicial + "u                             ");

                inventUEPS.Pop();
                ColorChange("rojo");
                Console.WriteLine($"borrado de inventairio");

                Console.WriteLine($"----------------------------------------------------------------------");
                ResetColor(); Console.ReadKey();
            }

            total += Math.Round(subtot, 4); //se hace sumatoria de cada venta
            i++;
        }
        ColorChange("verde");
        Console.WriteLine($"**********************************************************************");
        Console.WriteLine($"          Venta satisfactoria total de {Math.Round(total, 3)} $$");
        Console.WriteLine($"**********************************************************************");
        ResetColor();
        Console.ReadKey();
    }


    /*****************************PEPS/Queque*********************************************/
    /*****************************PEPS/Queque*********************************************/
    /*****************************PEPS/Queque*********************************************/
    private static void Entradas_existenciasPEPS(List<Queue<Invent>> PEPS, List<string> resumen)
    {

        for (var i = 0; i < PEPS.Count; i++)
        {

            foreach (var item in PEPS[i])
            {
                resumen.Add("                                                                                   " + item.product + " -     " + item.precioC + "$-     " + item.precioV + "$     " + item.cant + "u");
            }
        }
    }

    private static void ImprimirInventarioPEPS(List<Queue<Invent>> inventPEPS)
    {
        var i = 1; var ii = 1;
        Console.WriteLine($"[-producto-]\t[-precio de compra-]\t[-precio de venta-]\t[-cantidad-");

        foreach (Queue<Invent> lista in inventPEPS)
        {

            foreach (Invent item in lista)
            {
                Console.WriteLine($"{i} - [{item.product}]\t[{item.precioC} $$]\t\t-[{item.precioV} $$]\t\t- [{item.cant}]"); i++;
                i++;
            }
            Console.WriteLine($"---------------------------------\n");
            ii++;
        }
    }

    private static void ImpreimirClaseProductoPEPS(List<Queue<Invent>> PEPS)
    {
        Console.WriteLine($"Productos en existencia");
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


    private static void VentaPEPS(Queue<Invent> inventPEPS, List<Invent> PEPSventas, List<string> resuenPEPS)
    {
        Console.Write($"ingrese cantidad a comprar: ");
        var cantCompr = int.Parse(Console.ReadLine());

        var total = 0.0;
        var i = 1;
        while (cantCompr > 0 && inventPEPS.Count > 0)
        {
            var cantinicial = inventPEPS.Peek().cant;
            var venta = (cantCompr > inventPEPS.Peek().cant) ? inventPEPS.Peek().cant : cantCompr;
            double subtot = inventPEPS.Peek().precioV * venta;//saca subtotal de precio*cant

            cantCompr = cantCompr - inventPEPS.Peek().cant; //se hace resta de cantidad vendida
            inventPEPS.Peek().cant = inventPEPS.Peek().cant - cantCompr; //restar producto vendido del inventario
            inventPEPS.Peek().cant = (inventPEPS.Peek().cant <= 0) ? 0 : inventPEPS.Peek().cant;//si se excede la cantidad disponible de asigna 0 

            ColorChange("azul");
            Console.WriteLine($"{i}>Venta realizada: [{venta}] {inventPEPS.Peek().product} al precio de {inventPEPS.Peek().precioV}$$ quedan en inventario {inventPEPS.Peek().cant}.");
            ResetColor();

            cantCompr = (cantCompr < 0) ? 0 : cantCompr;//asignar el valor que queda por vender, si la resta da menor a 0 se asigna 0
            Console.Write($"\t\tSubtotal por venta {Math.Round(subtot, 4)}_$$\t quedan por vender {cantCompr} unidades.\n");
            Console.ReadKey();

            if (inventPEPS.Peek().cant > 0)
            {

                resuenPEPS.Add("                                         " + inventPEPS.Peek().product + " - " + inventPEPS.Peek().precioC + "$- " + inventPEPS.Peek().precioV + "$- " + cantCompr + "u                             ");
                inventPEPS.Peek().cant = inventPEPS.Peek().cant - venta;
                inventPEPS.Peek().cant = (inventPEPS.Peek().cant < 0) ? 0 : inventPEPS.Peek().cant;
                Console.WriteLine($"Quedan {inventPEPS.Peek().cant} en inventario a {inventPEPS.Peek().precioV}");
                Console.WriteLine($"----------------------------------------------------------------------"); Console.ReadKey();
            }
            if (inventPEPS.Peek().cant <= 0)
            {
                inventPEPS.Peek().cant = cantinicial;
                PEPSventas.Add(inventPEPS.Peek());//cuando se acaba el inventario se es enviado a registro 
                resuenPEPS.Add("                                         " + inventPEPS.Peek().product + " - " + inventPEPS.Peek().precioC + "$- " + inventPEPS.Peek().precioV + "$- " + cantinicial + "u                             ");


                inventPEPS.Dequeue();
                ColorChange("rojo");
                Console.WriteLine($"borrado de inventairio");

                Console.WriteLine($"----------------------------------------------------------------------");
                ResetColor(); Console.ReadKey();
            }

            total += Math.Round(subtot); //se hace sumatoria de cada venta
            i++;
        }

        ColorChange("verde");
        Console.WriteLine($"**********************************************************************");
        Console.WriteLine($"      Venta satisfactoria total de {Math.Round(total, 3)} $$");
        Console.WriteLine($"**********************************************************************");
        ResetColor();
        Console.ReadKey();
    }
}
