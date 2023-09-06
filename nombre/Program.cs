class practica
{

    public class persona
    {
        public int edad;
        public string nombre;

        public persona(int edad, string nombre)
        {
            this.edad = edad;
            this.nombre = nombre;
        }
    }
    public static int Random()
    {
        Random r = new();
        return r.Next(0, 100);//indicas limites ;
    }

    public static void Main(  )
    {/*
        string[] nombres = new string[] { "Ana", "Beto", "Carlos", "Diana", "Eduardo" };//declarada y llenada a la vez
        foreach (var item in nombres)
        {
            System.Console.WriteLine(item);
        }

        int[] numero = new int[5];//declarada su tipo, nombre y tamano

        int tamano = int.Parse(Console.ReadLine());
        numero = new int[tamano];

        for (var i = 0; i < numero.GetLength(0); i++)//get .GetLength() te da el tamano del array, si es de una dimencion va un 0, si es de dos 
        //para saber el unumero de filas es 0 tambien, para saber numero de columnas 1
        {
            numero[i] = random();//asignas un numero random a la posicion en la que vaya i
        }

        foreach (var item in numero)
        {
            System.Console.WriteLine(item);
        }

        int[,] par = new int[tamano, tamano];
        Console.WriteLine($"llenar");

        for (var i = 0; i < par.GetLength(0); i++)
        {
            for (var j = 0; j < par.GetLength(1); j++)
            {
                par[i, j] = random();//en la posicion x,y un numero random
            }
        }
        System.Console.WriteLine("imprimir");
        for (var i = 0; i < par.GetLength(0); i++)
        {
            Console.WriteLine($"dato");
            for (var j = 0; j < par.GetLength(1); j++)
            {
                System.Console.WriteLine(par[i, j]);//en la posicion x,y un numero random
            }
        }

        */
        Tuple<int,string> [] nombreEdad = new Tuple<int, string>[2];

        for (var i = 0; i < nombreEdad.Length; i++)
        {
            Console.WriteLine($"nombre: ?");
            string name = Console.ReadLine();
            Console.WriteLine($"edad: ?");
            int age = int.Parse(Console.ReadLine());
            nombreEdad [i]=new Tuple<int, string>(age,name);//crea
                    }
foreach (var item in nombreEdad)
{
    System.Console.WriteLine(item.Item1 + item.Item2);
}

    persona[] personas = new persona[2];
            for (var i = 0; i < personas.Length; i++)
        {
            Console.WriteLine($"nombre: ?");
            string name = Console.ReadLine();
            Console.WriteLine($"edad: ?");
            int age = int.Parse(Console.ReadLine());
            personas [i] = new persona(age,name);//crea
                    }
foreach (var item in personas)
{
    System.Console.WriteLine(item.edad + " " + item.nombre);
}


    }
}