// See https://aka.ms/new-console-template for more information
using System;


internal class Program
{

    double f(double x, double y)
    {

        return x+y;

    }

    double g(double x)
    {
        return 2*Math.Exp(x)-x-1;
    }

    double epsfunc(int n)
    {
        double eps = 1;

        for (int i = 0; i < n; i++)
        {
            eps = eps / 10;
        }

        return eps;
    }

    double sum(double j, double n)
    {
        int sumtotal = 0;
        int sum = 0;
        for (int i = j; i<=n; i++)
        {
            sum = f(x[j-1], y[0, 0])+f(x[j], y[0, 0]);
            sumtotal = sumtotal + sum;
            sum = 0;
        }
    }

    private static void Main(string[] args)
    {

        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        double[] x = new double[n+1];

        double[,] y = new double[n+1, n+1];
        Console.Write("y[0,0] = ");
        y[0, 0] = new double(Console.ReadLine());
        Console.Write("a = ");
        double a = new double(Console.ReadLine());
        Console.Write("b = ");
        double b = new double(Console.ReadLine());
        Console.Write("epsputere = -");
        int eps = int.Parse(Console.ReadLine());

        x[0] = a;
        h = (b-a)/n;


        for (int i = 0; i<=n; i++)
        {
            x[i] = a + i * h;

        }
        for (int i = 0; i<=n; i++)
        {
            y[0, i] = y[0, 0];

        }
        y[1, 0] = y[0, 0];



        for (int i = 1; i<n; i++)
        {

            y[1, i] = y[0, 0] + (b-a)/(2*n) * sum(1, i);
        }

        int m = 1;
        do
        {

        } while (M);



for (int i = 0; i<=n; i++)
        {
            Console.WriteLine("y[{0} ", i+" ]="+y[i]);
        }


        for (int i = 0; i<=n; i++)
        {


            Console.WriteLine();
            Console.WriteLine("x[{0} ", i+" ]="+x[i]);

            Console.WriteLine(g(x[i]));
        }
    }
}