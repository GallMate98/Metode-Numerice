using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metoda_combinata_a_tangentei
{
    internal class Program
    {
        //metoda combinata tangentei (Laboratorul 4)
         
        public static double f(double x)
        {
            return (1/Math.Tan(x))-x;
        }

        public static double df(double x)
        {
            return (-1/Math.Sin(x)*Math.Sin(x)) - 1;    
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

                double[] x = new double[1000000];
                Console.Write("x[0] = ");
                x[0] = 2;


                Console.Write("epsputere = -");
                int eps = int.Parse(Console.ReadLine());

                

            

                x[1] = x[0] -  (f(x[0]) / df(x[0])) -
                    (f( x[0]-(f(x[0])/df(x[0])) )/df(x[0]));

                Console.WriteLine("interatia " + 1 + " => " + x[1]);

                int n = 1;

                do
                {
                    x[n+1] = x[n] -  (f(x[n]) / df(x[n])) -
                    (f(x[n]-(f(x[n])/df(x[n])))/df(x[n]));
                    Console.WriteLine("interatia " + (n+1) + " => " + x[n+1]);
                    n++;

                }
                while (Math.Abs(x[n] - x[n - 1]) >= epsfunc(eps));
                Console.ReadKey();
            }
        }
    }
}

