List<List<int>> coleccionDeListas = new List<List<int>>();

// Agregar listas a la colección
coleccionDeListas.Add(new List<int>() { 1, 2, 3 });
coleccionDeListas.Add(new List<int>() { 4, 5, 6 });
coleccionDeListas.Add(new List<int>() { 7, 8, 9 });

// Utilizar IEnumerable para recorrer y mostrar los elementos de las listas
foreach (List<int> lista in coleccionDeListas)
{
    foreach (int elemento in lista)
    {
        Console.WriteLine(elemento);
    }
}

