
public class Funciones
{
    //
public int Vilid_Int()
{
    int numero = 0;
    bool esNumeroPositivo = false;

    while (!esNumeroPositivo)
    {
        Console.WriteLine("Introduce un número positivo:");
        string input = Console.ReadLine();

        try
        {
            numero = int.Parse(input);

            if (numero > 0)
            {
                esNumeroPositivo = true;
            }
            else
            {
                Console.WriteLine("El número debe ser positivo.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error de formato: el valor ingresado no es un número válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    return numero;
}



}