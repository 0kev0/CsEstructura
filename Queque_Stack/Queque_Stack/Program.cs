using System.Drawing;
 
/*
codigo de clase
Rodriguez Rivera,Kevin Israel 
RR19118
*/
public class MyClass
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
        Queue<string> pila = new() { };
        ColorChange("verde");
        Console.WriteLine("orden de entrada y salida de una pila\n el primero en entrar es el primero en salir");

        pila.Enqueue("1_hola");
        pila.Enqueue("2_hola");
        pila.Enqueue("3_hola");
        pila.Enqueue("4_hola");

        pila.Dequeue();
        foreach (var item in pila)
        {
            Console.WriteLine(item);
        }

        ResetColor();
        ColorChange("azul");
        Console.WriteLine($"orden de  entrada y salida de un stack\n el primero en entrar es el ultimo en salir");

        Stack<string> cola = new() { };
        cola.Push("1_hola");
        cola.Push("2_hola");
        cola.Push("3_hola");
        cola.Push("4_hola");


        Console.WriteLine($"elemento en 2 {cola.ElementAt(2)}");
        cola.Pop();



        foreach (var item in cola)
        {
            System.Console.WriteLine(item);
        }

        Console.WriteLine($"eliminar por metodo .pop()");

        for (var i = 0; i < cola.Count; i++)
        {
            cola.Pop();
        }
        ResetColor();

        /******************************EJEMPLO***************************************/

        Stack<string> history = new() { };
        Stack<string> historyend = new() { };

        string page_actual = "inicio";

        //menu

        while (true)
        {
            ColorChange("verde");
            Console.WriteLine("Bienvenido al navegador ESD");
            Console.WriteLine($" 1>ir a inicio de pagina\t 2>Volver a pagina anterior\t 3>Siguiente pagina \t 3>salir");

            var op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1://ingresar paginas visitadas por consola
                    Console.WriteLine($"Ingrese la pagina a visitar");
                    ResetColor();
                    var Page = Console.ReadLine();
                    history.Push(Page);

                    break;

                case 2://hace un pop al stack para mostrar la ultima pagina visitada
                    Console.WriteLine(history.Peek());
                    historyend.Push(history.Peek());
                    history.Pop();

                    break;
                case 3:
                    Console.WriteLine(historyend.Peek());
                    history.Push(historyend.Peek());
                    historyend.Pop();
                    break;

                case 4://juego
                    Stack<int> gamble = new();
                    Random rdm = new();

                    for (var i = 0; i < 3; i++)
                    {
                        gamble.Push(rdm.Next(0,10));
                    }

                    int turn = 1;
                    while (turn < 4)
                    {
                        ColorChange("azul");
                        Console.WriteLine($"ingrese numero entre 0 y 10 ");
                        var intento = int.Parse(Console.ReadLine());

                        if (gamble.Peek() == intento)
                        {
                            ColorChange("verde");
                            Console.WriteLine($"intento #{turn}");
                            Console.WriteLine($"VICTORIA "); break;
                        }
                        else
                        {
                            ColorChange("rojo");
                            Console.WriteLine($"intento #{turn}");
                            Console.WriteLine($"Fallo, el valor era {gamble.Peek()}");
                            turn++;
                            Console.WriteLine((turn == 4) ? "GAME-OVER" : " ");
                            ResetColor();
                            gamble.Pop();
                        }
                    }

                    break;
                default:
                Console.WriteLine($"invalid");
                

                    break;
            }


        }



    }
}