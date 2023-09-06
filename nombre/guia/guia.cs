using System;
namespace nombre
{
    public class Guia
    {
        public class alumnos
        {
            public string nombre;
            public double nota;

            public alumnos(string nombre, double nota)
            {
                this.nombre = nombre;
                this.nota = nota;
            }
        }
        public static int Random()
        {
            Random r = new();
            return r.Next(0, 100);//indicas limites ;
        }

        public static void ver1D(int[] arry)
        {
            foreach (var item in arry)
            {
                System.Console.WriteLine(item);
            }
        }

        public static void Main()
        {
            Console.WriteLine(@"Escribe un programa que inserte y elimine elementos en un arreglo 
            unidimensional de tipo entero que se encuentre desordenado. Considera que no 
            se pueden insertar elementos repetidos.");

            int[] arry01 = new int[5];
            bool seguir = false;

            for (var i = 0; i < arry01.Length; i++)
            {
                arry01[i] = Random();
            }

            ver1D(arry01);

            do
            {
                System.Console.WriteLine("Editar por posicion \n que posicion desea? ");
                int elimine = int.Parse(Console.ReadLine());
                elimine--;

                List<int> Lista = arry01.ToList();
                Lista.RemoveAt(elimine);

                arry01 = Lista.ToArray();

                foreach (var item in Lista)
                {
                    System.Console.WriteLine(item);
                }

                Console.WriteLine($"Valor elimindao con exito");


                Console.WriteLine($"seguir? 1/si 0/no");
                elimine = int.Parse(Console.ReadLine());
                seguir = (elimine == 1) ? false : true;
            } while (seguir == false);

            Console.WriteLine(@"En un arreglo unidimensional de tipo real se almacenan las calificaciones de un 
            grupo de N alumnos que presentaron un examen de admisión a una universidad. 
            Escribe un programa que calcule e imprima lo siguiente:
            nombre
            o El promedio general del grupo. 
            o El porcentaje de alumnos aprobados (todos aquellos alumnos cuyo puntaje 
            supere los 7 puntos).
            o El número de alumnos cuya calificación sea mayor o igual a 8.5");

            Tuple<int, string>[] tuple = new Tuple<int, string>[]
            {
                new(1,"q"),new(1,"q"),new(1,"q"),new(1,"q"),new(1,"q"),
            };
System.Console.WriteLine("esta es una forma de usar un array son 2 o mas variables dentro de una posicion");
            foreach (var item in tuple)
            {
                System.Console.WriteLine(item.Item1 + " " + item.Item2);
            }


            alumnos[] calificaciones = new alumnos[3];
            int tam = calificaciones.Length;

            int[,] d =new int[3,6];
            int tamanoFilas = d.GetLength(0);
            int tamanoCol = d.GetLength(1);


            for (var i = 0; i < tam; i++)
            {
                string nombre; double nota;
                Console.WriteLine($"ingrese nombra: ");
                nombre = Console.ReadLine();
                Console.WriteLine($"Ingrese la nota:");
                nota = double.Parse(Console.ReadLine());

                calificaciones[i] = new alumnos(nombre, nota);

            }

            foreach (var item in calificaciones)
            {
                Console.WriteLine($"alumno: {item.nombre} edad: {item.nota}");
            }

            var sumaNotas = 0.0;
            var aprobados = 0;
            var exelent = 0;

            for (var i = 0; i < tam; i++)
            {//promedio
                sumaNotas += calificaciones[i].nota;
                aprobados += /*condicion*/ (calificaciones[i].nota > 7) ?/*true*/ 1 : /*false*/ 0;

                if (calificaciones[i].nota > 7)
                {
                    sumaNotas += 1;
                }
                exelent += (calificaciones[i].nota > 8.5) ? 1 : 0;
                if (calificaciones[i].nota > 8.5)
                {
                    sumaNotas += 1;
                }
            }
            var prom = sumaNotas / tam;

            Console.WriteLine($"promedio de {tam} alumnos es de: {prom}");
            Console.WriteLine($"aprobados : {aprobados} Sobresalientes {exelent}");


            string[] palabras = new string[] { "a", "b", "c" };

            string buscar = Console.ReadLine();
            var posicion = 0;




            for (var i = 0; i < palabras.GetLength(0); i++)
            {
                if (palabras[i] == buscar)
                {
                    posicion = i;
                    break;
                }
            }
            Console.WriteLine($"encontrado en posicion {posicion}");


        }
    }
}