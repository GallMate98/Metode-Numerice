// See https://aka.ms/new-console-template for more information
//Algoritmul lui Runge-kutta de ord 4 (Laboratorul 9)
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


for (int i = 1; i<n; i++)
{
    x[i]=a+i*h;

}

for (int i = 1; i<n; i++)
{

    K[i]= f(x[i-1], y[i-1]);
    U[i] = f(x[i-1]+h/3, y[i-1]+((h/3)*K[i]));
    V[i] = f(x[i-1]+(2*h)/3, y[i-1]+h*((-1/3)*K[i]+U[i]));
    W[i] = f(x[i-1]+h, y[i-1]+h*(K[i]-U[i]+V[i]));
    y[i] = y[i-1] + (h/8) *(K[i] + 3*U[i]+3*V[i]+ W[i]);
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
