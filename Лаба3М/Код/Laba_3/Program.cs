double startPosition = 0.1, endPosition = 1;
double step = (endPosition - startPosition) / 10;   //17
double X = 0.1, Y = 0;
int n = 10; // количество слагаемых
double E = 0.0001; // точность

while (X <= endPosition)
{
    Y = (Math.Pow(Math.E, X) + Math.Pow(Math.E, -X))/2;

    double recurrent1 = 1;
    double SN = 0;
    for (int i = 1; i <= n; ++i)
    {
        if (i != 1)
            recurrent1 *= Math.Pow(X, 2) / ((2 * i - 2) * (2 * i - 3));

        SN += recurrent1;
    }

    int j = 1;
    double recurrent2 = 1;
    double SE = 0;
    do
    {
        if (j != 1)
            recurrent2 *= Math.Pow(X, 2) / ((2 * j - 2) * (2 * j - 3));

        SE += recurrent2;
        ++j;
    } while (recurrent2 > E);

    Console.WriteLine($"X = {X:F4}   SN = {SN:F4}   SE = {SE:F4}   Y = {Y:F4}");

    X += step;
}