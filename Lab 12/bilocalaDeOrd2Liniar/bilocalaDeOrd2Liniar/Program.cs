using System;

namespace bilocalaDeOrd2Liniar
{
    class Program
    {  //Metoda diferentelor finite pt problema bilocala de ordinul doi liniar (Labortorul 13)
        public static double r(double x)
        {
            return 1;
        }

        public static double f(double t)
        {
            return 2*Math.Exp(-t)*Math.Cos(t)+Math.Exp(-t)*Math.Sin(t);
        }

        public static double g(double t)
        {
            return Math.Exp(-t)*Math.Sin(t);
        }

        static void Main(string[] args)
        {
            while (true)
            {

                Console.Write("n = ");
                int n = int.Parse(Console.ReadLine());

                double[] v = new double[n+1];
                double[] p = new double[n+1];
                double[] w = new double[n+1];
                double[] u = new double[n+1];
                double[] t = new double[n+1];
                double[] rr = new double[n+1];
                double[] ff = new double[n+1];
                double[] y = new double[n+1];


                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = Math.PI;
                Console.Write(b);

                double h = (b-a)/n;
                double z = -1;
                Console.WriteLine();

                for (int i = 0; i<=n; i++)
                {
                    t[i] = a + i * h;
                }

                for (int i = 1; i<=n-1; i++)
                {
                    rr[i] = r(t[i]) * h * h;
                    ff[i] = f(t[i]) * h * h;
                    y[i] = 2 + rr[i];
                }

                u[1] = z/y[1];

                for (int i = 2; i<=n-2; i++)
                {
                    w[i] = y[i] - u[i-1] * z;
                    u[i] = z/w[i];
                }

                w[n-1] = y[n-1] - u[n-2] * z;

                p[1] = ff[1]/2;


                for (int i = 2; i<=n-1; i++)
                {
                    p[i] = (ff[i] - z * p[i-1])/w[i];
                }

                v[0] = 0;
                v[n] = 0;
                v[n-1] = p[n-1];

                for (int i = n-2; i>=1; i--)
                {
                    v[i] = p[i] - u[i] * v[i+1];
                }

                for (int i = 0; i<=n; i++)
                {
                    Console.WriteLine("v["+i+"]= " +v[i]);
                }
                Console.WriteLine();

                for (int i = 0; i<=n; i++)
                {
                    Console.WriteLine("g["+i+"]= " +g(t[i]));
                }
            }

            
        }
    }
}
