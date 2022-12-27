/*BUSQUEDA LINEAL
using System;
using System.Diagnostics;

namespace LinearSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un arreglo con al menos 20 elementos de tipo int
            int[] arr = { 2, 5, 7, 8, 9, 10, 12, 15, 17, 20, 22, 25, 27, 30, 35, 40, 45, 50, 55, 60 };

            // Imprimir el arreglo y su posición
            Console.WriteLine("Arreglo desordenado:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }

            // Leer el valor a buscar por pantalla
            Console.WriteLine("\nIngrese el valor a buscar:");
            int valueToSearch = int.Parse(Console.ReadLine());

            // Obtener la hora de inicio de ejecución
            var watch = Stopwatch.StartNew();

            // Realizar la búsqueda lineal
            int index = -1; // inicializar el índice en -1 para indicar que no se ha encontrado el valor
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == valueToSearch)
                {
                    index = i; // asignar el índice del elemento encontrado
                    break; // detener el ciclo
                }
            }

            // Obtener la hora de fin de ejecución y calcular el tiempo transcurrido en milisegundos
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;

            // Mostrar en pantalla el resultado de la búsqueda y el tiempo transcurrido
            if (index != -1)
            {
                Console.WriteLine($"\nSe ha encontrado el valor {valueToSearch} en la posición {index} del arreglo.");
            }
            else
            {
                Console.WriteLine("\nNo se ha encontrado el valor en el arreglo.");
            }
            Console.WriteLine($"Tiempo de ejecución: {elapsedMs} milisegundos.");
        }
    }
}
*/
//BUSQUEDA BINARIA
/*
using System;
using System.Diagnostics;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un arreglo con al menos 20 elementos de tipo int y ordenado de forma ascendente
            int[] arr = { 2, 5, 6, 8, 9, 10, 12, 16, 17, 20, 22, 25, 27, 30, 36, 40, 45, 50, 55, 60 };

            // Imprimir el arreglo y su posición
            Console.WriteLine("Arreglo ordenado:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }

            // Leer el valor a buscar por pantalla
            Console.WriteLine("\nIngrese el valor a buscar:");
            int valueToSearch = int.Parse(Console.ReadLine());

            // Obtener la hora de inicio de ejecución
            var watch = Stopwatch.StartNew();

            // Realizar la búsqueda binaria
            int index = BinarySearch(arr, valueToSearch);

            // Obtener la hora de fin de ejecución y calcular el tiempo transcurrido en milisegundos
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;

            // Mostrar en pantalla el resultado de la búsqueda y el tiempo transcurrido
            if (index != -1)
            {
                Console.WriteLine($"\nSe ha encontrado el valor {valueToSearch} en la posición {index} del arreglo.");
            }
            else
            {
                Console.WriteLine("\nNo se ha encontrado el valor en el arreglo.");
            }
            Console.WriteLine($"Tiempo de ejecución: {elapsedMs} milisegundos.");
        }

        // Método de búsqueda binaria iterativo
        static int BinarySearch(int[] arr, int valueToSearch)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == valueToSearch)
                {
                    return mid;
                }
                else if (arr[mid] < valueToSearch)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
*/
using System;
using System.Linq;

namespace SequentialSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un array de 100 enteros aleatorios en el rango de 1 a 200
            Random rnd = new Random();
            int[] arr = Enumerable.Range(1, 100).Select(x => rnd.Next(1, 201)).ToArray();

            // Seleccionar 50 enteros aleatorios para buscar
            int[] valuesToSearch = Enumerable.Range(1, 50).Select(x => rnd.Next(1, 201)).ToArray();

            //contadores para búsquedas con éxito y fallidas
            int successCounter = 0;
            int failureCounter = 0;

            //búsqueda secuencial de cada valor seleccionado aleatoriamente
            foreach (int valueToSearch in valuesToSearch)
            {
                bool found = false; // inicializar una bandera en false para indicar que no se ha encontrado el valor

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == valueToSearch)
                    {
                        found = true; // cambiar la bandera a true para indicar que se ha encontrado el valor
                        successCounter++; // aumentar el contador de búsquedas con éxito
                        break; // finalizar ciclo
                    }
                }

                if (!found)
                {
                    failureCounter++; // aumentar el contador de búsquedas fallidas
                }
            }

            // Calcular el porcentaje de éxito y de fallo de búsquedas
            double successPercentage = (double)successCounter / valuesToSearch.Length * 100;
            double failurePercentage = (double)failureCounter / valuesToSearch.Length * 100;

            //estadísticas
            Console.WriteLine("Estadísticas:");
            Console.WriteLine($"Número de búsquedas con éxito: {successCounter}");
            Console.WriteLine($"Número de búsquedas fallidas: {failureCounter}");
            Console.WriteLine($"Porcentaje de éxito de búsquedas: {successPercentage:F2}%");
            Console.WriteLine($"Porcentaje de fallo de búsquedas: {failurePercentage:F2}%");

            //los números en orden creciente
            Array.Sort(arr);
            Console.WriteLine("\nNúmeros en orden creciente:");
            foreach (int num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }
}