using System;

    public class Task4
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[3][];
            
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };

           
            for (int i = 0; i < jaggedArray.Length; i++)
            {
               
                if (jaggedArray[i].Length % 2 == 0)
                {
                    
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] += 7;
                    }
                }
                else
                {
                    
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] -= 7;
                    }
                }
            }

            
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();  // Перехід на новий рядок після кожного підмасиву
            }
        }
    }