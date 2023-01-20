using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Metoda secantei (Laboratorul 2)
namespace Curs2
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
        public static double f (double a)
        {
            return a*a*a-a-1;
        }

        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            double esp = epsfunc(p);
           int n =30;
            double[] x = new double[n];
            x[0]= a;
            x[1]= b;
            int i = 1;
            do
            {
                x[i+1]=x[i]-((f(x[i])*(x[i]-x[i-1]))/(f(x[i])-f(x[i-1])));
                Console.WriteLine("i = " + i + "\nx[i] = " + x[i]);
                i++;
            } while (Math.Abs(x[i]-x[i-1]) >= esp);
            Console.ReadKey();

        }
    }
}
