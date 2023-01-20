using System;


namespace Metoda_lui_Cebisev
{ //Metoda lui Cebuisev (Laboratorul 3)
    internal class Program
    {
        public static double epsfunc(int n)
        {
            double eps = 1;

            for (int i = 0; i < n; i++)
            {
                eps=eps / 10;
            }

            return eps;
        }

        public static double f(double a)
        {
            return a * a * a - a - 1;
        }

        public static double df(double a)
        {
            return 3 * a * a - 1 ;
        }

        public static double ddf(double a)
        {
            return 6 * a;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                //Console.Write("a = ");
                //double a = double.Parse(Console.ReadLine());
                double[] x = new double[100];


                Console.Write("x[0] = ");
                double b = double.Parse(Console.ReadLine());

                Console.Write("epsgrad = ");
                int epsvalue = int.Parse(Console.ReadLine());

                double esp = epsfunc(epsvalue);
                x[0]=b;



                x[1] = x[0] - ((f(x[0]) / df(x[0])) -
                    ((f(x[0]) * f(x[0]) * ddf(x[0])) / (2 * df(x[0]) * df(x[0]) * df(x[0]))));
                Console.WriteLine("interatia " + 1 + "-a => " + x[1]);

                int n = 1;

                do
                {
                    x[n + 1] = x[n] - ((f(x[n]) / df(x[n])) -
                        ((f(x[n]) * f(x[n]) * ddf(x[n])) / (2 * df(x[n]) * df(x[n]) * df(x[n]))));
                    Console.WriteLine("interatia " + (n+1) + "-a => " + x[n+1]);
                    n++;


                } while (Math.Abs(x[n]-x[n-1]) >= esp);




                Console.ReadKey();
            }

        }
    }

}

