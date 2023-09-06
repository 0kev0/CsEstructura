public class Clase
{
    private static int Random()
    {
        Random rdm = new();
        return rdm.Next(0, 100);
    }
    private static void Ver2D(int[,] arry, int FILA, int COLUMN)
    {
        int sumX = 0, sumY = 0, sumA = 0; //variables para sumatorias
        int[] sumaX = new int[FILA];
        int[] sumaY = new int[COLUMN];//array para alacenar las sumatorias de una fila o columna

        /**************************SUMATORIAS DE FILAS/COLUMNAS**************************************************/
        for (int i = 0; i < FILA; i++)//por cada fila se hace sumatoria de sus pociciones por cada fila
        {//es decir, fila 0 col 0 / fila 0 col 1 / fila 0 coll 2 etc
            for (int ii = 0; ii < COLUMN; ii++)
            {
                sumX += arry[i, ii];//suma de la las posiciones de filas
                sumaX[i] = sumX;//agregar la sumatoria de una filas a un array
            }
            sumA += sumX;
            sumX = 0;
        }

        for (int i = 0; i < COLUMN; i++)//por cada columna se hace sumatoria 
        {//es decir, fila 0 col 0 / fila 1 col 0  / fila 2 coll 0 etc
            for (int ii = 0; ii < FILA; ii++)
            {
                sumY += arry[ii, i];//suma de la las posiciones de columnas
                sumaY[i] = sumY;//agregar la sumatoria de una columna a un array
            }
            sumY = 0;
        }

        /*****************************IMPRIMIR CONTENIDO***********************************************/
        for (int i = 0; i < FILA; i++)
        {
            for (int ii = 0; ii < COLUMN; ii++)
            {
                Console.Write("[ " + arry[i, ii] + " ] ");

            }
            System.Console.WriteLine(@"( " + sumaX[i] + " ) ");
            System.Console.WriteLine();
        }
        for (int ii = 0; ii < COLUMN; ii++)
        {
            System.Console.Write(@"( " + sumaY[ii] + ") ");

        }
        System.Console.WriteLine($"\n\nsumatoria total de la matriz de [ {FILA}*{COLUMN} ] es : " + sumA);

    }
    public static void Main()
    {

        Console.WriteLine($"ingrese la cantidad de personas");

        int cant = int.Parse(Console.ReadLine());
        string[] Personas = new string[cant];
        int[] edad = new int[cant]; 
        string[] mayores = new string[cant];

        for (var i = 0; i < Personas.Length; i++)
        {
            int edades;
            Console.Write($"ingrese nombre de la persona. : ");
            Personas[i] = Console.ReadLine() + " ";
            System.Console.WriteLine("ingrese la edad");
            edades=int.Parse( Console.ReadLine() );  
            edad[i]=edades;
            mayores[i] = (edades > 18) ? Personas[i] : null;          
        }
Console.WriteLine($"Nombre      Edad ");

for (var i = 0; i < Personas.Length; i++)
{
        Console.WriteLine( Personas[i] + "\t "+ edad[i] +"\n");
}
Console.WriteLine($"personas mayores a 18 ");

foreach (var item in mayores)
{
    Console.WriteLine(item);
    
}
Console.WriteLine($"************************************************");

        Console.WriteLine(@"  PRACTICA: 
Crea un array bidimensional con dimenciones ingresadas por terminal,
que represente una matriz de números enteros. Luego, calcula y muestra por consola la suma de cada fila,
la suma de cada columna y la suma total de la matriz." + "\n\n");

        int rows, columns, modNum, rowM, columnM;
        bool seguir = false;

        Console.Write($"ingrese numero de filas: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write($"ingrese numero de columnas: ");
        columns = int.Parse(Console.ReadLine());
        Console.WriteLine($"---------------------------------------");

        int[,] arry02 = new int[rows, columns];//instancia de matriz de 2 dimenciones con tamano ingresada por consola

        for (int i = 0; i < rows; i++)
        {
            for (int ii = 0; ii < columns; ii++)
            {
                arry02[i, ii] = Random();//llenar cada posicion de la matriz con un numero random entre 0 y 100
            }
        }

        Ver2D(arry02, rows, columns);

        do
        {
            Console.WriteLine("EDITAR POSICIONES DENTRO DEL ARRAY DE 2 DIMENCIONES\n");
            Console.Write($"ingrese numero de fila : ");
            rowM = int.Parse(Console.ReadLine());
            Console.Write($"ingrese numero de columna : ");
            columnM = int.Parse(Console.ReadLine());
            Console.WriteLine($"modificar valor  con: ");
            modNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"---------------------------------------");

            arry02[rowM, columnM] = modNum;
            Ver2D(arry02, rows, columns);

            Console.WriteLine($"editar otra casilla? 1/si 2/no: ");
            modNum = int.Parse(Console.ReadLine());

            seguir = (modNum == 1) ? false : true;
            Console.Clear();

        } while (seguir == false);







}
}
