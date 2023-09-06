public class Estudiante
{
    public int id;
    public String nombre, apellido;
    public double[] notas;

    public Estudiante(int id, string nombre, string apellido, double[] notas)
    {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
        this.notas = notas;
    }

    private double LlenarNotas()
    {
        for (var i = 0; i < notas.Length; i++)
        {
            
        }
        return 0.0;//implementar la funcion de promedio
    }
    private double Prom()
    {
        double[] notas = new double[3]; for (var i = 0; i < this.notas.Length; ++i)
        {

        }
        return 0.0;//implementar la funcion de promedio
    }
}