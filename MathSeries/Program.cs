using System;

namespace MathSeries
{
    class Program
    {
        public static double CalculateSeries(double xValue, uint startPoint, uint endPoint, Func<double, uint, double> formula)
        {
            if (startPoint >= endPoint)
            {
                throw new ArgumentException("End point value must be greater than start point value.");
            }

            double result = 0;

            for (uint i = startPoint; i <= endPoint; i++)
            {
                result += formula(xValue, i);
            }

            return result;
        }

        static void Main()
        {
            Console.Write("Введите k и x: ");
            string[] input = Console.ReadLine().Split();

            uint k = UInt32.Parse(input[0]);
            double x = Double.Parse(input[1]);

            double result = CalculateSeries(x, 0, k, (xValue, n) =>
            {
                double factorial = 1;

                for (uint i = 2; i <= (2 * n + 1); i++)
                {
                    factorial *= i;
                }

                return Math.Pow(xValue, 2 * n + 1) / factorial;
            });

            Console.WriteLine($"Значение суммы: {result}");
        }
    }
}

