using System;
using System.Xml.XPath;

namespace MetodeApproxSuccesPtProbCauchyDeOrdI
{
    internal class Program
    {
        // Metoda aproximatilor succesive pentru problema bilocala de ordinul intai (Laboratorul 10)
        public static  double f(double x, double y)
        {
            return x+y;
        }

        public static double g(double x)
        {
            return 2*Math.Exp(x)-x-1;
        }

        public static double epsfunc(int n)
        {
            return 1/(Math.Pow(10,n));
        }

        public static double sum(int j, int i, double[]x, double y0)
        {
            double sumtotal = 0;

            for (int k = j; k<=i; k++)
            {
                sumtotal += f(x[k-1], y0) + f(x[k], y0);
            }

            return sumtotal;
        }

        public static double sum2(int m,int i, double[] x, double[,] y)
        {
            double sumtotal = 0;

            for (int j = 1 ; j<=i; j++)
            {
                sumtotal += f(x[j-1], y[m,j-1]) + f(x[j], y[m, j]);
            }

            return sumtotal;
        }

   
        public static double max(double[,] y, int m, int n)
        {
            double max = 0;
            for(int i = 1; i<= n; i++)
            {
                if (Math.Abs(y[m, i]-y[m-1,i]) > max)
                {
                    max = Math.Abs(y[m, i]-y[m-1, i]);
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            
            //1

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            double[] x = new double[100];

            double[,] y = new double[100, 100];
            Console.Write("y0 = ");
            double y0 = double.Parse(Console.ReadLine());
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("epsputere = -");
            int eps = int.Parse(Console.ReadLine());


            //2
            x[0] = a;
            double h = (b-a)/n;
            Console.WriteLine("h = "+h);
            
            //3
    
            
            for (int i = 1; i<=n; i++)
            {
                x[i] = a + i * h;
                //Console.WriteLine("x[" + i + "]=" + x[i]);
            }
            
            //4
            for (int i = 0; i<=n; i++)
            {
                y[0, i] = y0;
                //Console.WriteLine(y[0,i]);
            }

          

            //5
            y[1, 0] = y0;
          

            //6
            for (int i = 1; i<=n; i++)
            {
                y[1, i] = y0 + (b-a)/(2*n) * sum(1, i,x,y0);
                Console.WriteLine(y[1,i]);
            }
           
            //7
            int m = 1;

            while (max(y,m, n)>=epsfunc(eps))
            {
                y[m, 0] = y0;

                for (int i = 1; i<=n; i++)
                {
                    y[m + 1, i] = y0 + (double)(b - a) / (2 * n) * sum2(m,i,x,y);
                }

                m++;
            }
            
            

            // tiparire

            Console.WriteLine("ultima iteratie este {0}:" , m);
            for (int i = 0; i<=n; i++)
            {
                Console.WriteLine("y[" + i + "] = " + y[m,i]);
            }

            Console.WriteLine();
            Console.WriteLine("------------");
            Console.WriteLine();

            for (int i = 0; i<=n; i++)
            {
                Console.WriteLine("g(x[" + i + "]) = " + g(x[i]));
            }
        }
    }
}
