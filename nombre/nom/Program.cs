public class MyClass
{
    public static void Main(string[] args)
    {
        string[,] nombreTrabajo = new string[2, 2];

        for (int i = 0; i < nombreTrabajo.GetLength(0); i++)
        {
            string nombre = Console.ReadLine();
            string trabajo = Console.ReadLine();
            for (int ii = 0; ii < nombreTrabajo.GetLength(1); ii++)
            {


                if (i == 0)
                {
                    nombreTrabajo[i, ii] = nombre;
                }
                if (i == 1)
                {
                    nombreTrabajo[i, ii] = trabajo;
                }
            }
        }

        for (int i = 0; i < nombreTrabajo.GetLength(0); i++)
        {
            for (int ii = 0; ii < nombreTrabajo.GetLength(1); ii++)
            {
                Console.WriteLine(nombreTrabajo[i, ii]);
            }System.Console.WriteLine();
        }
    }
}