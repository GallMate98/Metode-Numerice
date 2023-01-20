using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Transactions;

namespace ConsoleApp1
{
    internal class Program
    {
        // Algoritmul metodei aproximatiilor succesive pt problema Cauchy de ordinul doi. (Labortorul nr 12)
        public static double f(double x, double y)
        {
            return (2*Math.Exp(x)/3)+(y/3);
        }

        public static double g(double x)
        {
            return Math.Exp(x);
        }

        public static double epsfunc(int n)
        {
            return 1/(Math.Pow(10, n));
        }

       public static double dif (double[,] y, int m, int n, int eps)
        {
            for (int i = 1; i<=n; i++)
            {
                 if (Math.Abs(y[m, i]-y[m-1, i])<epsfunc(eps))
                 {
                    return 1;
                 }
            }
      
            return 0;   
            
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("n=");
                int n = int.Parse(Console.ReadLine());

                double[,] y = new double[n+1, n+1];
                double[] x = new double[n+1];

                Console.Write("a=");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b=");
                double b = double.Parse(Console.ReadLine());
                Console.Write("y0=");
                double y0 = double.Parse(Console.ReadLine());
                Console.Write("y0'=");
                double y1 = double.Parse(Console.ReadLine());
                Console.Write("epsputere = -");
                int eps = int.Parse(Console.ReadLine());

                Console.WriteLine(f(0, 1));
                Console.WriteLine(epsfunc(eps));

                x[0] = a;
                double h = (b-a)/n;

                for (int i = 1; i <= n; i++)
                {
                    x[i] = a + i * h;
                }

                for (int i = 0; i <= n; i++)
                {
                    y[0, i] = y0 + (x[i]-x[0]) * y1;
                }

                int m = 0;

                do
                {
                    m++;
                    y[m, 0] = y0;

                    for (int i = 1; i<=n; i++)
                    {
                        double sum = 0;
                        for (int j = 1; j<=i; j++)
                        {
                            sum += ((x[i]-x[j-1]) * f(x[j-1], y[m-1, j-1])) + ((x[i] - x[j]) * f(x[j], y[m-1, j]));
                        }
                        y[m, i] = y[0, i] + ((h/2) * sum);
                    }



                } while (dif(y, m, n, eps) == 0);

                Console.WriteLine("ultima iteratie este {0}:", m);
                for (int i = 0; i<=n; i++)
                {
                    Console.WriteLine("y[" + i + "] = " + y[m, i]);
                }

                Console.WriteLine();
                Console.WriteLine("------------");



                for (int i = 0; i<=n; i++)
                {
                    Console.WriteLine("g(x[" + i + "]) = " + g(x[i]));


                }
                Console.ReadKey();
            }
        }
    }
}



