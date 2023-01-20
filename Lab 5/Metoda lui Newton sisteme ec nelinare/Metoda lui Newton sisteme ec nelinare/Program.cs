using System;
// // Algoritmul  metodei lui newton pentru sisteme de ecuatii neliniare  (Laboratorul 5)

namespace Metoda_lui_Newton_sisteme_ec_nelinare
{
    internal class Program
    {
        public static double F(double x, double y)
        {
            return x*x+y*y-10;
        }

        public static double G(double x, double y)
        {
            return Math.Sqrt(x+y)-2;    
        }

        public static double FX(double x, double y)
        {
            return 2*x;
        }

        public static double FY(double x, double y)
        {
            return 2*y;
        }

        public static double GX(double x, double y)
        {
            return 1/(2*Math.Sqrt(x+y));
        }

        public static double GY(double x, double y)
        {
            return 1/(2*Math.Sqrt(x+y));
        }

        public static double eps(double eps)
        {
            double epsgrad = 1;
            for(int i=0;i<eps;i++)
            {
                epsgrad=epsgrad/10;
            }
            return epsgrad;
        }

        static void Main(string[] args)
        {
            while(true)
            {
                double[] x = new double[100];
                Console.Write("x[0] = ");
                x[0] = double.Parse(Console.ReadLine());
                double[] y = new double[100];
                Console.Write("y[0] = ");
                y[0] = double.Parse(Console.ReadLine());
                Console.Write("epsgrad = - ");
                double epsgrad = double.Parse(Console.ReadLine());
                Console.WriteLine(eps(epsgrad));
                double[] d = new double[100];
                double[] dd = new double[100];

                double[] j = new double[100];

                j[0] = FX(x[0], y[0]) * GY(x[0], y[0]) -  FY(x[0], y[0])* GX(x[0], y[0]);

                d[0] = F(x[0], y[0])* GY(x[0], y[0]) - G(x[0], y[0]) * FY(x[0], y[0]);
                dd[0] = G(x[0], y[0])* FX(x[0], y[0]) - F(x[0], y[0]) * GX(x[0], y[0]);
                x[1]=x[0] - (d[0]/j[0]);
                y[1]=y[0] - (dd[0]/j[0]);

                //x[1] = x[0] - (1/j[0]) * (F(x[0], y[0]) * GY(x[0], y[0]) - G(x[0], y[0]) * FY(x[0], y[0]));
                //y[1] = y[0] - (1/j[0]) * (FX(x[0], y[0]) * G(x[0], y[0]) - GX(x[0], y[0]) * F(x[0], y[0]));

                Console.WriteLine("interatia"+" "+ 1 + " "+"x =>" +" "+ x[1] + " "+ " y =>" + " "+ y[1]);

                int n = 1;
                do
                {
                   

                    j[n] = FX(x[n], y[n]) * GY(x[n], y[n]) -  FY(x[n], y[n])* GX(x[n], y[n]);
                    d[n] = F(x[n], y[n])* GY(x[n], y[n]) - G(x[n], y[n]) * FY(x[n], y[n]);
                    dd[n] = G(x[n], y[n])* FX(x[n], y[n]) - F(x[n], y[n]) * GX(x[n], y[n]);
                    x[n+1]=x[n] - (d[n]/j[n]);
                    y[n+1]=y[n] - (dd[n]/j[n]);

                    Console.WriteLine("interatia"+" "+(n+1)+ " "+" x =>"+" "+ x[n+1] + " "+ "y =>" + " " +y[n+1]);
                    n++;


                } while (Math.Abs(x[n] - x[n-1]) >= eps(epsgrad) || Math.Abs(y[n] - y[n-1]) >= eps(epsgrad));
            }
        }
    }
}
//j[n] = FX(x[n], y[n]) * GY(x[n], y[n]) -  FY(x[n], y[n])* GX(x[n], y[n]);


//x[n+1] = x[n] - (1/j[n]) * (F(x[n], y[n]) * GY(x[n], y[n]) - G(x[n], y[n]) * FY(x[n], y[n]));

//y[n+1] = y[n] - (1/j[n]) * (FX(x[n], y[n]) * G(x[n], y[n]) - GX(x[n], y[n]) * F(x[n], y[n]));