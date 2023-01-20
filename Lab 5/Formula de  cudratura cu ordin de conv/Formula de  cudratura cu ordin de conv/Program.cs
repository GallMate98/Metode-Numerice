using System;

namespace Formula_de__cudratura_cu_ordin_de_conv
{
    internal class Program
        //metoda gauss-seidel penntru sisteme de ecuatii neliniare  Laboratorul(6)
    {
        public static double F(double x, double y, double z)
        {
            return Math.Sqrt(0.5*(y*z+5*x-1));
        }

        public static double G(double x, double y, double z)
        {
            return Math.Sqrt(2*x+Math.Log(z)); ;
        }
        public static double H (double x, double y, double z)
        {
            return Math.Sqrt(x*y+2*z+8);
        }

        public static double eps(double eps)
        {
            double epsgrad = 1;
            for (int i = 0; i<eps; i++)
            {
                epsgrad=epsgrad/10;
            }
            return epsgrad;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("x[0] = ");
                double[] x = new double[100];
                x[0]= double.Parse(Console.ReadLine());
                Console.Write("y[0] = ");
                double[] y = new double[100];
                y[0]= double.Parse(Console.ReadLine());
                Console.Write("z[0] = ");
                double[] z = new double[100];
                z[0]= double.Parse(Console.ReadLine());
                Console.Write("epsgrad = - ");
                double epsgrad = double.Parse(Console.ReadLine());

                x[1] = F(x[0], y[0], z[0]);
                y[1] =G(x[0], y[0], z[0]);
                z[1] =H(x[0], y[0], z[0]);

                Console.WriteLine("interatia"+" "+ 1 + " "+"x =>" +" "+ x[1] + " "+ " y =>" + " "+ y[1] +  " z =>" + " "+ z[1]);

                int n = 1;
                do
                {

                    x[n+1] = F(x[n], y[n], z[n]);
                    y[n+1] =G(x[n+1], y[n], z[n]);
                    z[n+1] =H(x[n+1], y[n+1], z[n]);

                    Console.WriteLine("interatia"+" "+(n+1)+ " "+" x =>"+" "+ x[n+1] + " "+ "y =>" + " " +y[n+1]+  " z =>" + " "+ z[n+1]);

                    n++;
                } while (Math.Abs(x[n] - x[n-1]) >= eps(epsgrad) || Math.Abs(y[n] - y[n-1]) >= eps(epsgrad));
            }
        }
    }
}
