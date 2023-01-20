using System;

namespace MetodaAppoxSucPtProbBilocalaDeOrd2
{
    internal class Program
    {

        // Algoritmul metodei aproximatiilor succesive pentru problema bilocala de ordinul doi (Laboratorul 11)
        public static double f(double t, double x)
        {
            return (2/3)*Math.Exp(t)+(1/3)*x;
        }

        public static double g(double x)
        {
            return Math.Exp(x);
        }

        public static double epsfunc(int n)
        {
            return 1/(Math.Pow(10, n));
        }

        public static double sum1(double a, double b, int i, double[] t, double[,]x, int m)
        {
            double sumtotal = 0;

            for (int j = 1; j<=i; j++)
            {
                sumtotal += ((t[j-1]-a)*(b-t[i]))/(b-a)*f(t[j-1], x[m, j-1])+((t[j]-a)*(b-t[i]))/(b-a)
                    * f(t[j], x[m, j]);
            }

            return sumtotal;
        }

        public static double sum2(double a,double b, int n, int i, double[] t, double[,] x, int m)
        {
            double sumtotal = 0;

            for (int j=i+1 ; j<=n; j++)
            {
                sumtotal += ((t[i]-a)*(b-t[j-1]))/(b-a)*f(t[j-1], x[m, j-1])+((t[i]-a)*(b-t[j]))/(b-a)
                    * f(t[j], x[m, j]);
            }

            return sumtotal;
        }


        public static double max(double[,]x, int m, int n)
        {
            double max = 0;
            for (int i = 1; i<= n-1; i++)
            {
                if (Math.Abs(x[m, i]-x[m-1, i]) > max)
                {
                    max = Math.Abs(x[m, i]-x[m-1, i]);
                }
            }

            return max;
        }

        static void Main(string[] args)
        {
            
            //1

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            double[] t = new double[100];

            double[,] x = new double[500, 500];
            Console.Write("alfa= ");
            double alfa = double.Parse(Console.ReadLine());
            double beta = Math.E;
            Console.WriteLine("beta = " +beta);
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("epsputere = -");
            int eps = int.Parse(Console.ReadLine());


            //2
            for(int i=0; i<=n; i++)
            {
                t[i] = a + (i*(b-a))/n;
            }

            //3
            for (int i = 0; i<=n; i++)
            {
                x[0,i] = (b-t[i]/b-a)*alfa +(t[i]-a/b-a)*beta ;
            }

          

            //4
            int m = 1;

            while (max(x, m, n)>=epsfunc(eps)) 
            {
                x[m+1, 0] = alfa;
                x[m+1, n] = beta;

                for (int i = 1; i<=n-1; i++)
                {
                    x[m+1, i] = (b-t[i]/b-a)*alfa + (t[i]-a/b-a)*beta -((b-a)/2*n)*sum1(a, b, i, t, x, m)
                        -((b-a)/2*n)*sum2(a, b, n, i, t, x, m);
                }

                m++;
                if(m==2)
                {
                    for (int i = 0; i<=n; i++)
                    {
                        Console.WriteLine("y[" + i + "] = " + x[m, i]);
                    }
                }
            } 



            // tiparire

            Console.WriteLine("ultima iteratie este {0}:", m);
            for (int i = 0; i<=n; i++)
            {
                Console.WriteLine("y[" + i + "] = " + x[m, i]);
            }

            Console.WriteLine();
            Console.WriteLine("------------");
            
            

            for (int i = 0; i<=n; i++)
            {
                Console.WriteLine("g(x[" + i + "]) = " + g(t[i]));


            }
            Console.ReadKey();
        }
    }
}
