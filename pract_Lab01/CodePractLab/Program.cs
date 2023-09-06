/*
Ejercicio 1: Crea un array unidimensional de 10 números enteros aleatorios entre 1 y 100.
Luego, ordena el array de forma ascendente usando el método Array.Sort() 
y muestra el array ordenado por consola. Puedes usar la clase Random para 
generar números aleatorios.

Ejercicio 2: Crea un array bidimensional de 3 filas y 4 columnas que represente una matriz
de números enteros. Luego, calcula y muestra por consola la suma de cada fila, la suma de 
cada columna y la suma total de la matriz. Puedes usar bucles anidados para recorrer el array.

Ejercicio 3: Crea un array tridimensional de 2 páginas, 3 filas y 4 columnas que represente
una colección de matrices de números enteros. Luego, muestra por consola cada matriz con su
número de página y sus elementos. Puedes usar tres bucles anidados para recorrer el array.*/

class Ejercicio
{
    private static int Random()
    {
        Random rdm = new();
        return rdm.Next(0, 100);
    }

    private static void Ver1D(int[] arry)
    {
        foreach (var item in arry)
        {
            Console.Write("[ " + item + " ]");
        }
        Console.WriteLine("\n\n");
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

            Ver2D(arry02, rows, columns);


    private static void Ver3D(int page, int rows, int columns, int[,,] arry03)
    {
        int sumP = 0, sumC = 0, sumF = 0;//variables para sumatorias
        int[] sumR = new int[rows];
        int[] SUMp = new int[page];
        int[] SUMc = new int[columns];

        /***************************LLENAR EL ARRAY DE TRES DIMENCIONES*********************/


        /***************************SUMATORIA DE PAGINAS*********************/
        for (int i = 0; i < page; i++)
        {
            for (int ii = 0; ii < rows; ii++)
            {

                for (int iii = 0; iii < columns; iii++)
                {
                    sumP += arry03[i, ii, iii];
                }

            }
            SUMp[i] = sumP; sumP = 0;
        }
     int p = 0;
        /**************************SUMATORIA DE COLUMNAS*********************/
        for (int ii = 0; ii < columns; ii++)
        {
            for (int i = 0; i < page; i++)
            {
           

                for (int iii = 0; iii < rows; iii++)
                {
                    sumC += arry03[i, ii, iii];//suma de la las posiciones de columnas


                }          

            }
                      SUMc[ii] = sumC;//agregar la sumatoria de una columna a un array

                                sumC = 0;p++;
        }
        /**************************SUMATORIA DE FILAS*********************/
        for (int i = 0; i < page; i++)
        {
            int o = 0;
            for (int ii = 0; ii < rows; ii++)
            {

                for (int iii = 0; iii < columns; iii++)
                {
                    sumF += arry03[i, ii, iii];//suma de la las posiciones de columnas
                }
            }
            sumR[o] = sumF;//agregar la sumatoria de una columna a un array
            o++; sumF = 0;
        }

        System.Console.WriteLine();
        for (var i = 0; i < page; i++)
        {
            System.Console.WriteLine($"Total de Pag. {i + 1} es: {SUMp[i]}\n");
            for (var ii = 0; ii < columns; ii++)
            {
                for (var iii = 0; iii < rows; iii++)
                {
                    Console.Write("\t[ " + arry03[i, ii, iii] + " ]");
                }
                System.Console.WriteLine("\n");
            }
            System.Console.WriteLine("-----------------------");
        }

        foreach (var item in SUMc)
        {
            System.Console.WriteLine(item);
        }
    }
        
    /*/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\*/
    public static void Main()
    {
        int[] arry01 = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arry01[i] = Random();
        }
        Console.WriteLine($"Ejercicio 01\n");
        Ver1D(arry01);


        Console.WriteLine(@"  EJERCICIO 2: 
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



        Console.WriteLine($"ejercicio 3");
        Console.WriteLine(@"Crea un array tridimensional de 3 páginas, 3 filas y 3 columnas que represente
 una colección de matrices de números enteros. Luego, muestra por consola cada matriz con su
  número de página y sus elementos");



        int page, pageM;
        seguir = false;

        Console.Write($"ingrese numero de paguinas: ");
        page = int.Parse(Console.ReadLine());
        Console.Write($"ingrese numero de filas: ");
        rows = int.Parse(Console.ReadLine());
        Console.Write($"ingrese numero de columnas: ");
        columns = int.Parse(Console.ReadLine());
        Console.WriteLine($"---------------------------------------");


        int[/*page*/   ,/*row*/    ,/*column*/] arry03 = new int[page, rows, columns];
        for (int i = 0; i < page; i++)
        {
            for (int ii = 0; ii < rows; ii++)
            {
                for (int iii = 0; iii < columns; iii++)
                {
                    arry03[i, ii, iii] = Random();
                }
            }
        }

        Ver3D(page, rows, columns, arry03);

        /***********************************MODIFICAR ARRAY DE 3 DIMENCIONES************/
        do
        {
            Console.WriteLine("EDITAR POSICIONES DENTRO DEL ARRAY DE 3 DIMENCIONES\n");
            Console.Write($"ingrese numero de paguina : ");
            pageM = int.Parse(Console.ReadLine());
            Console.Write($"ingrese numero de fila : ");
            rowM = int.Parse(Console.ReadLine());
            Console.Write($"ingrese numero de columna : ");
            columnM = int.Parse(Console.ReadLine());
            Console.WriteLine($"modificar valor  con: ");
            modNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"---------------------------------------");
            //   private static void ModificarCasilla3D(int page, int rows, int columns, int modNum,int pageM, int rowM, int columnM, int[,,] arry03)

            arry03[pageM, rowM, columnM] = modNum;
            Ver3D(page, rows, columns, arry03);

            Console.WriteLine($"editar otra casilla? 1/si 2/no: ");
            modNum = int.Parse(Console.ReadLine());

            seguir = (modNum == 1) ? false : true;
            Console.Clear();

        } while (seguir == false);
    }


}