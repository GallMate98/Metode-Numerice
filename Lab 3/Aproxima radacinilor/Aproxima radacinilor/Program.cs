using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Calcul radicalilor cu metoda de ord 3 (Laboratorul 4)

namespace Aproxima_radacinilor
{
    internal class Program
    {
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


                Console.Write("epsputere = -");
                int eps = int.Parse(Console.ReadLine());

                double[] x = new double[1000000];

                if (a>1)
                    x[0]=a;
                else
                    x[0]=1;


                x[1] = (x[0] * (x[0] * x[0] + 3 * a) / (3 * x[0] * x[0] + a));
                Console.WriteLine("interatia " + 1 + " => " + x[1]);

                int i = 1;

                do
                {
                    x[i + 1] = (x[i] * (x[i] * x[i] + 3 * a) / (3 * x[i] * x[i] + a));
                    Console.WriteLine("interatia " + (i+1) + " => " + x[i+1]);
                    i++;

                }
                while (Math.Abs(x[i] - x[i - 1]) >= epsfunc(eps));
                Console.ReadKey();
            }
        }
    }
}
