using System;
/*Дані для перевірки 
  В колі: R=5, x=-3, y=2
  На межі: R=4, x=2, y=0
  Ззовні: R=3, x=5, y=5
*/
namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter R: ");
                double R = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter x: ");
                double x = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter y: ");
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine("\nWas the point hit ?");

                checkPointPosition(R, x, y);
                
                Console.WriteLine("\nDo you want to continue? (y/n)?");
                string continueInput = Console.ReadLine();
                if (continueInput.ToLower() != "yes")
                {
                    break;
                }
            }
        }

        //Ліве коло
        static bool insideLeftCircle(double R, double x, double y)
        {
            return Math.Pow(x + R / 2, 2) + Math.Pow(y, 2) < Math.Pow(R, 2);
        }

        static bool onBorderLeftCircle(double R, double x, double y)
        {
            return Math.Pow(x + R / 2, 2) + Math.Pow(y, 2) == Math.Pow(R, 2);
        }

        //Праве коло
        static bool insideRightCircle(double R, double x, double y)
        {
            return Math.Pow(x - R / 2, 2) + Math.Pow(y, 2) < Math.Pow(R, 2);
        }

        static bool onBorderRightCircle(double R, double x, double y)
        {
            return Math.Pow(x - R / 2, 2) + Math.Pow(y, 2) == Math.Pow(R, 2);
        }

        static void checkPointPosition(double R, double x, double y)
        {
            if (onBorderLeftCircle(R, x, y) || onBorderRightCircle(R, x, y))
            {
                Console.WriteLine("On border");
            }
            else if (insideLeftCircle(R, x, y) || insideRightCircle(R, x, y))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}