// See https://aka.ms/new-console-template for more information



// Algoritmul metodei modificate a lui Euler (Laboratorul 7)

double f(double x, double y)
{

    return x+y;

};

double g(double x)
{
    return 2*Math.Exp(x)-x-1;
};


Console.Write("n = ");
int n = int.Parse(Console.ReadLine());
double[] x = new double[n];
double[] y = new double[n];
double[] K = new double[n];
double[] V = new double[n];

Console.Write("x[0] = ");
x[0] = double.Parse(Console.ReadLine());
Console.Write("y[0] = ");
y[0] = double.Parse(Console.ReadLine());
Console.Write("T = ");
double T = double.Parse(Console.ReadLine());


double h = T/n;



for (int i = 1; i<n; i++)
{
    x[i]=x[0]+i*h;

}

for (int i = 1; i<n; i++)
{
    
    K[i]= f(x[i-1], y[i-1]);
      V[i] = f(x[i-1]+h/2, y[i-1]+((h/2)*K[i]));
      y[i] = y[i-1] + h * V[i];
}



for (int i = 1; i<n; i++)
{
    Console.WriteLine("y[{0} ", i+" ]="+y[i]);
}


for (int i = 1; i<n; i++)
{


    Console.WriteLine();
    Console.WriteLine("x[{0} ", i+" ]="+x[i]);

    Console.WriteLine(g(x[i]));
}