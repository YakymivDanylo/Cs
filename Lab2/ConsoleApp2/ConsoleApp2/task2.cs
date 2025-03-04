using System;

class Task2
{
    static void Main(string[] args)
    {
        int n = 4;
        int[,] matrix = new int[n, n];
        Random rnd = new Random();

        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(-50, 50);
            }
        }

        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int maxProductRow = -1;
        int maxProduct = int.MinValue;

        
        for (int i = 0; i < n; i++)
        {
            int product = 1;
            for (int j = 0; j < n; j++)
            {
                product *= matrix[i, j];
            }

            if (product > maxProduct)
            {
                maxProduct = product;
                maxProductRow = i;
            }
        }

        
        int minElement = matrix[maxProductRow, 0];
        for (int j = 1; j < n; j++)
        {
            if (matrix[maxProductRow, j] < minElement)
            {
                minElement = matrix[maxProductRow, j];
            }
        }

        Console.WriteLine("Row with max product: " + (maxProductRow + 1));
        Console.WriteLine("Smallest element: " + minElement);
    }
}