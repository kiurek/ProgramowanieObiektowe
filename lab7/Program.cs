using System;

namespace lab7
{
    delegate double Operation(double a, double b);
    class Program
    {
        static double Addition (double a, double b)
        {
            return a + b;
        }

        static double Mul(double x, double y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Operation add = Addition;
            double result = add.Invoke(3, 5);
            Console.WriteLine(result);

            add = Mul;
            Console.WriteLine(add.Invoke(3, 5));
        }
    }
}
