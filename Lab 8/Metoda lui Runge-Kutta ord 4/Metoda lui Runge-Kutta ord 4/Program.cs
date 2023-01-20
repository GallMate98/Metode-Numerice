// See https://aka.ms/new-console-template for more information
//Algoritmul metodei Rubge-Kutta de tipul 3/8 de ord 4 (Laboratorul 9)
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
double[] x = new double[n+1];
double[] y = new double[n+1];
double[] K = new double[n];
double[] V = new double[n];
double[] U = new double[n];
double[] W = new double[n];

Console.Write("a = ");
double a = double.Parse(Console.ReadLine());
Console.Write("b = ");
double b = double.Parse(Console.ReadLine());
Console.Write("T = ");
double T = double.Parse(Console.ReadLine());


double h = T/n;
y[0]=b;



for (int i = 0; i<=n; i++)
{
    x[i]=a+i*h;

}

for (int i = 1; i<n; i++)
{

    K[i]= h*f(x[i-1], y[i-1]);
    U[i] = h*f(x[i-1]+h/2, y[i-1]+K[i]/2);
    V[i] = h*f(x[i-1]+h/2, y[i-1]+U[i]/2);
    W[i] = h*f(x[i-1]+h, y[i-1]+V[i]);
    y[i] = y[i-1] +  ((K[i] + 2*U[i]+ 2*V[i]+W[i])/6);
}



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
