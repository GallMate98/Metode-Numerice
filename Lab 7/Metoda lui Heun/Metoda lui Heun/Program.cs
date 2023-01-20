// See https://aka.ms/new-console-template for more information
// Algoritmul metodei Heun (Laboratorul 8)
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
double[] U= new double[n];

Console.Write("x[0] = ");
double a = double.Parse(Console.ReadLine());
Console.Write("y[0] = ");
double b = double.Parse(Console.ReadLine());
Console.Write("T = ");
double T = double.Parse(Console.ReadLine());

double h = T/n;
y[0]=b;


for (int i = 0; i<n; i++)
{
    x[i]=a+i*h;

}

for (int i = 1; i<n; i++)
{

    K[i]= f(x[i-1], y[i-1]);
    U[i] = f(x[i-1]+(2.0/3)*h, y[i-1]+((2.0/3)*h*K[i]));
    y[i] = y[i-1] + (0.25*h)*(K[i]+3*U[i]);
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
