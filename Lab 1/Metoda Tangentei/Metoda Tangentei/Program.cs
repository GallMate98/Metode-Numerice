using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// metoda tangentei (Laboratorul 1)
namespace Metoda_Tangentei
{
    internal class Program
    {
        public static double f(double x)
        {
            return x*x  - 3;
        }

        public static double df(double x)
        {
            return 2 * x;
        }
        public static double epsfunc(int n)
        {
            double eps = 1;
            for (int i = 0; i<n; i++)
            {
                eps=eps/10;
            }
            return eps;
        }
        static void Main(string[] args)
        {
            Console.Write("a=");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b=");
            double b = double.Parse(Console.ReadLine());
            Console.Write("dda=");
            double dda = double.Parse(Console.ReadLine());
            Console.Write("epsgarad=");
            int eps = int.Parse(Console.ReadLine());
            epsfunc(eps);
            int n = 30;
            double[] x = new double[100];

            double mul = f(a) * dda;
            if (mul > 0)
            {
                x[0] = a;
            }
            else
            {
                x[0] = b;
            }


            double c = x[0] - (f(x[0]) / df(x[0]));
            x[1] = c;

            int i = 1;
            do
            {
                x[i + 1] = x[i] - (f(x[i]) / df(x[i]));
                i++;
                Console.WriteLine(x[i]);
            }
            while (Math.Abs(x[i] - x[i - 1]) >= epsfunc(eps));
            Console.ReadKey();
        }
    }
}
