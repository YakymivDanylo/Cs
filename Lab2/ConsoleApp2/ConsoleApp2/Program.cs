using System;

class Task2
{
    static void Main(string[] args)
    {
        int n = 4;
        int[,] matrix =
        {
            { 1, -2, 5, 6 },
            { 5, 6, -1, 2 },
            { 2, -3, 4, 5 },
            { -1, 2, 3, 6},
        };

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
        Console.WriteLine("Row with max product: "+(maxProductRow+1));
        Console.WriteLine("Min element: " + minElement);
    }
    
}