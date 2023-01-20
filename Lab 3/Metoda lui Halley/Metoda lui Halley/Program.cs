using System;
// metoda lui Halley (Laboratorul 3)
namespace Metoda_lui_Halley
{
    internal class Program
    {
        public static double f(double x)
        {
            return x * x * x - x - 1;
        }

        public static double df(double x)
        {
            return 3 * x * x - 1;
        }

        public static double ddf(double x)
        {
            return 6 * x;
        }

        public static double epsfunc(int n)
        {
            double eps = 1;

            for (int i = 0; i < n; i++)
            {
                eps = eps / 10;
            }

            return eps;
        }

        static void Main(string[] args)
        {
            while (true)
            {


                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());

                Console.Write("epsputere = -");
                int eps = int.Parse(Console.ReadLine());

                double[] x = new double[1000000];

                double val = f(a) * ddf(a);

                if (val > 0)
                    x[0] = a;
                else
                    x[0] = b;



                x[1] = x[0] - 2 * f(x[0]) * df(x[0]) /
                    ((2 * df(x[0]) * df(x[0])) - (f(x[0]) * ddf(x[0])));

                Console.WriteLine("interatia " + 1 + " => " + x[1]);

                int i = 1;

                do
                {
                     x[i+1] = x[i] - 2 * f(x[i]) * df(x[i]) / 
                         ((2 * df(x[i]) * df(x[i])) - (f(x[i]) * ddf(x[i])));

                    Console.WriteLine("interatia " + (i+1) + " => " + x[i+1]);
                    i++;

                }
                while (Math.Abs(x[i] - x[i - 1]) >= epsfunc(eps));
                Console.ReadKey();
            }
        }
    }
}

