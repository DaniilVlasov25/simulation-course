using System;

class Program
{
    static Int128 M = (Int128)Math.Pow(2, 63);
    static Int128 Beta = (Int128)Math.Pow(2, 32) + 3;
    static Int128 X;

    static void SetSeed()
    {
        X = Beta;
    }

    static double NextDouble()
    {
        X = (Beta * X) % M;
        return (double)X / (double)M;
    }

    static double Mean(double[] values)
    {
        double sum = 0;
        foreach (double v in values)
            sum += v;
        return sum / values.Length;
    }

    static double Variance(double[] values)
    {
        double mean = Mean(values);
        double sumSq = 0;
        foreach (double v in values)
            sumSq += (v - mean) * (v - mean);
        return sumSq / values.Length;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        const int N = 100_000;

        double theoreticalMean = 0.5;
        double theoreticalVariance = 1.0 / 12.0;

        Console.WriteLine("=== Лабораторная работа 4: Базовый датчик случайных чисел ===");
        Console.WriteLine();
        Console.WriteLine($"Размер выборки: {N:N0}");
        Console.WriteLine();
        Console.WriteLine("Теоретические значения (U[0, 1]):");
        Console.WriteLine($"  Среднее   = {theoreticalMean:F4}");
        Console.WriteLine($"  Дисперсия = {theoreticalVariance:F4}  (1/12)");
        Console.WriteLine();

        SetSeed();
        double[] myValues = new double[N];
        for (int i = 0; i < N; i++)
            myValues[i] = NextDouble();

        double myMean = Mean(myValues);
        double myVariance = Variance(myValues);

        Console.WriteLine("--- Наш датчик ---");
        Console.WriteLine($"  Среднее   = {myMean:F4}  (отклонение: {Math.Abs(myMean - theoreticalMean):F4})");
        Console.WriteLine($"  Дисперсия = {myVariance:F4}  (отклонение: {Math.Abs(myVariance - theoreticalVariance):F4})");
        Console.WriteLine();

        var rnd = new Random();
        double[] builtInValues = new double[N];
        for (int i = 0; i < N; i++)
            builtInValues[i] = rnd.NextDouble();

        double builtInMean = Mean(builtInValues);
        double builtInVariance = Variance(builtInValues);

        Console.WriteLine("--- Встроенный датчик  (Random.NextDouble) ---");
        Console.WriteLine($"  Среднее   = {builtInMean:F4}  (отклонение: {Math.Abs(builtInMean - theoreticalMean):F4})");
        Console.WriteLine($"  Дисперсия = {builtInVariance:F4}  (отклонение: {Math.Abs(builtInVariance - theoreticalVariance):F4})");
        Console.WriteLine();
    }
}