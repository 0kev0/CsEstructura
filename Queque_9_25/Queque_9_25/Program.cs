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
    public static void Main(string[] args)
    {
        Queue<string> clientes = new() { };
        string[] cajeros = new string[] { "Cajero #0014", "Cajero #0023", "Cajero #0031" };

        ColorChange("azul");
        Console.WriteLine($"Bienvenido bancok\n");
        Console.WriteLine($"Ingrese cuantos cliente desea atender");
        ResetColor();

        var cant = int.Parse(Console.ReadLine());

        for (var i = 0; i < cant; i++)
        {
            Console.Write($"Nombre?");
            var Nombre = Console.ReadLine();
            clientes.Enqueue(Nombre);
        }

     /*   for (var i = 0; i < cant; i++)
        {
            ColorChange("azul");
            Console.WriteLine($"Cliente #{i + 1} {clientes.Peek()} atendiendose... ");
            Thread.Sleep(2000);
            ColorChange("verde");
            Console.WriteLine($"{clientes.Dequeue()} atendido ");
        }*/
var client =1;
        for (var i = 0; i < cajeros.Length; i++)
        {
            ColorChange("azul");
            Console.WriteLine($"Cliente #{client } {clientes.Peek()} atendiendose en {cajeros[i]} ");
            Thread.Sleep(1000);
            ColorChange("verde");
            Console.WriteLine($"{clientes.Dequeue()} atendido ");
            if (i == 2)
            {
                i=-1;
            }
            client++;
            if (clientes.Count==0)
            {
                Console.WriteLine("finalizado");
                break;
            }
        }

    }

}