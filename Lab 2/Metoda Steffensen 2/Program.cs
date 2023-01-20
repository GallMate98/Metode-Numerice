using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs2Part2
{
    internal class Program
    {
        public static double epsfunc(int n)
        {
            double eps = 1;
            for (int i = 0; i<n; i++)
            {
                eps=eps/10;
            }
            return eps;
        }
        public static double f(double a)
        {
            return a*a*a-a-1;
        }
        public static Double f_dda (double a)
        {
            return 6*a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("b = ");
            double b = double.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            double esp = epsfunc(p);
            double dda = f_dda(a);
            int n = 30;
            double[] x = new double[n];
          //  x[0]= a;
            //x[1]= b;
            int i = 1;

            if (dda * f(a) > 0)
            {
                x[0] = a;
            }
            else
            {
                x[0] = b;
            }


            x[1] = x[0] - (f(x[0]) * f(x[0])) / (f(x[0] + f(x[0])) - f(x[0]));
            do
            {
               // x[i+1]=x[i]-((f(x[i])*(x[i]-x[i-1]))/(f(x[i])-f(x[i-1])));


                x[i + 1] = x[i] = (f(x[i]) * f(x[i])) / (f(x[i] + f(x[i])) - f(x[i]));
                Console.WriteLine(x[i] + " - " + i);
                i++;
            } while (Math.Abs(x[i]-x[i-1]) >= esp);
            Console.ReadKey();

        }
    }
}
}
