using System;

namespace ООП3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SolvingFunction();
        }
        static void SolvingFunction()
        {
            int n = 10;
            double x, y, sn, se, a = 0.1, b = 1, k = (b - a) / n, e = 0.0001;

            for (double i = a; i <= b; i = i + k)
            {
                x = i;
                Console.Write($"X = {x:F2}    ");
                sn = An(x, n);
                Console.Write($"SN = {sn:F5}    ");
                se = An(x, e);
                Console.Write($"SE = {se:F5}    ");
                y = Math.Cos(x);
                Console.WriteLine($"Y = {y:F5}");
            }
            Console.ReadLine();
        }
        static double An(double x, int n)
        {
            if (n > 0)
            {
                return An(x, n - 1) + Math.Pow(-1, n) * (Math.Pow(x, 2 * n) / (Fact(2 * n)));
            }
            else 
                return 1;
        }
        static double An(double x, double e)
        {
            int n = 1;
            double sum = 0;
            while (Math.Abs(An(x, n) - An(x, n - 1)) > e)
            {
                sum = An(x, n);
                n++;
            }
            return sum;
        }
        static double Fact(int n)
        {
            if (n > 1)
            {
                return (n * Fact(n - 1));
            }
            else 
                return 1;
        }
    }
}
