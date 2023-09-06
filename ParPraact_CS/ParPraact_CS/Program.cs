public class Par
{
    public static void Main(string[] args)
    {

        int[,] arr = new int[3, 3];
        Random random = new Random();
        List<int> numeros = Enumerable.Range(1, 10).ToList();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int index = random.Next(numeros.Count);
                arr[i, j] = numeros[index];
                numeros.RemoveAt(index);
            }
        }
        


        // Imprimir la matriz generada
        NewMethod(arr);

        // Condicionales para números positivos hasta 100
        Console.WriteLine("Ingrese un número positivo hasta 100:");
        string inputNumber = Console.ReadLine();
        int number;

        if (int.TryParse(inputNumber, out number))
        {
            if (number >= 0 && number <= 100)
            {
                Console.WriteLine("Número válido: " + number);
            }
            else
            {
                Console.WriteLine("Número inválido. Por favor, ingrese un número positivo hasta 100.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
        }

        // Condicionales para letras hasta 20 caracteres
        Console.WriteLine("Ingrese una letra o palabra de hasta 20 caracteres:");
        string inputString = Console.ReadLine();

        if (inputString.Length <= 20 && !ContainsNumbers(inputString))
        {
            Console.WriteLine("Cadena válida: " + inputString);
        }
        else
        {
            Console.WriteLine("Cadena inválida. Por favor, ingrese una letra o palabra de hasta 20 caracteres sin números.");
        }

        // Condicionales para números positivos hasta 100
        Console.WriteLine("Ingrese un número positivo hasta 100:");
        string inputNumber3 = Console.ReadLine();
        int number3;

        if (int.TryParse(inputNumber, out number))
        {
            if (number >= 0 && number <= 100)
            {
                Console.WriteLine("Número válido: " + number);
            }
            else
            {
                Console.WriteLine("Número inválido. Por favor, ingrese un número positivo hasta 100.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
        }

        // Condicionales para letras hasta 20 caracteres
        Console.WriteLine("Ingrese una letra o palabra de hasta 20 caracteres:");
        string inputString3 = Console.ReadLine();

        if (inputString.Length <= 20 && !ContainsNumbers(inputString))
        {
            Console.WriteLine("Cadena válida: " + inputString);
        }
        else
        {
            Console.WriteLine("Cadena inválida. Por favor, ingrese una letra o palabra de hasta 20 caracteres sin números.");
        }

        static void NewMethod(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    // Función auxiliar para verificar si una cadena contiene números
    static bool ContainsNumbers(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }


    static bool ContainsNumbers3(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}

// Función auxiliar para verificar si una cadena contiene números








