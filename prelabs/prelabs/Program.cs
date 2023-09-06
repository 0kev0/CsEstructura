// See https://aka.ms/new-console-template for more information
Random rdm = new Random();
int del = rdm.Next(1, 9);


/*Console.WriteLine("Hello, World!");
int[,] ints = new int[3, 3];
int[] rd = new int[9];


int o = 9;
for (var i = 0; i < ints.GetLength(0); i++)
{
    for (var x = 0; x < ints.GetLength(1); x++)
    {
        while (Array.IndexOf(rd, o) != -1)
        {
            rd[x] = rdm.Next(1, 10);
        }
    }
    System.Console.WriteLine();

}




for (var x = 0; x < ints.GetLength(0); x++)
{
    for (var y = 0; y < ints.GetLength(1); y++)
    {
        for (var u = 0; u < rd.Length; u++)
        {
           ints[x, y]=rd[u];
           Console.WriteLine(ints[x,y]);
           

        }
    }
    System.Console.WriteLine();
}
*/
bool seguir = false;
bool type = false;

do
{
    var op = int.Parse(Console.ReadLine());
int oo ;
    while (type == false)
    {
        try
        {
            Console.WriteLine($"solo int");
            oo = int.Parse(Console.ReadLine());
            type = true;
        }
        catch (System.Exception err)
        {
            Console.WriteLine($"error" + err.GetType().Name);
            type = false;
        }
    }
    Console.WriteLine($"{oo}");

    




    switch (op)
    {
        case 1:

            break;
        case 2:

            break;

        case 3:
            break;
    }

} while (true);
