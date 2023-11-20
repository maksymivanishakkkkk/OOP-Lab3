// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість елементів масиву:");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];

        // Заповнення масиву псевдовипадковими числами у діапазоні [-28.35; 12.91]
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            array[i] = Math.Round(random.NextDouble() * (12.91 + 28.35) - 28.35, 2);
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Знайти добуток індексів від’ємних елементів
        int negativeProduct = FindNegativeProduct(array);
        Console.WriteLine($"Добуток індексів від'ємних елементів: {negativeProduct}");

        // Впорядкувати перші k елементів за спаданням їх значень
        Console.WriteLine("Введіть кількість елементів для сортування (k):");
        int k = int.Parse(Console.ReadLine());
        SortFirstKElements(array, k);

        Console.WriteLine($"Масив з першими {k} елементами, впорядкованими за спаданням:");
        PrintArray(array);
    }

    static void PrintArray(double[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    static int FindNegativeProduct(double[] arr)
    {
        int product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                product *= i;
            }
        }
        return product;
    }

    static void SortFirstKElements(double[] arr, int k)
    {
        Array.Sort(arr, 0, Math.Min(k, arr.Length), Comparer<double>.Create((a, b) => b.CompareTo(a)));
    }
}
