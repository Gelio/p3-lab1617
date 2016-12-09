using System;
using System.Collections.Generic;

namespace lab10A
{

    public static class FunctionGenerationAndUsage
    {
        public static Func<double, double, double> LukasiewiczTnormGeneration()
        {
            return (a, b) => Math.Max(0, a + b - 1);
        }

        public static T ReduceManyArguments<T>(Func<T, T, T> reduceFn, params T[] arguments)
        {
            if (arguments.Length == 0)
                return default(T);
            else if (arguments.Length == 1)
                return arguments[0];

            T result = reduceFn(arguments[0], arguments[1]);
            for (int i = 2; i < arguments.Length; i++)
                result = reduceFn(result, arguments[i]);
            return result;
        }

        public static Func<double, double> QuadraticFunction(Func<double, double> f, double a, double b, double c)
        {
            return x => (c + f(x) * (b + f(x) * a));
        }

        public static bool IsMonotonic(double a, double b, double n, Func<double, double> f)
        {
            if (a > b)
            {
                double c = a;
                a = b;
                b = c;
            }

            double previousValue = f(a),
                step = (b - a) / n,
                currentX = a + step;

            int previousSlope,
                currentSlope;
            double currentValue = f(currentX);
            previousSlope = GetSlope(previousValue, currentValue);

            currentX += step;
            previousValue = currentValue;

            for (; currentX <= b; currentX += step)
            {
                currentValue = f(currentX);
                currentSlope = GetSlope(previousValue, currentValue);
                if (currentSlope != previousSlope)
                    return false;

                previousValue = currentValue;
            }

            return true;
        }

        private static int GetSlope(double f1, double f2)
        {
            if (f1 == f2)
                return 0;
            else if (f1 > f2)
                return 1;
            else
                return -1;
        }

        public static Func<Point2D, Point2D, double> ManhattanDistance()
        {
            return (Point2D p1, Point2D p2) =>
            {
                return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
            };
        }

        public static Point2D Medoid(List<Point2D> points, Func<Point2D, Point2D, double> distanceFn)
        {
            double minDistance = double.PositiveInfinity;
            Point2D minPoint = null;
            for (int i=0; i < points.Count; i++)
            {
                double currentDistance = 0;
                for (int j=0; j < points.Count; j++)
                    currentDistance += distanceFn(points[i], points[j]);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    minPoint = points[i];
                }
            }

            return minPoint;
        }

        public static Func<int[], int[]> PascalTriangleGeneration(int a, int b, int c)
        {
            return previousRow =>
            {
                if (previousRow.Length == 0)
                    return new int[1] { a };
                else if (previousRow.Length == 1)
                    return new int[2] { b, c };

                int[] newRow = new int[previousRow.Length + 1];
                newRow[0] = previousRow[0];
                for (int i = 1; i < newRow.Length - 1; i++)
                    newRow[i] = previousRow[i - 1] + previousRow[i];
                newRow[newRow.Length - 1] = previousRow[previousRow.Length - 1];
                return newRow;
            };
        }

        public static void TriangleGeneration(Func<int[], int[]> generateFn, int n)
        {
            int[] previousResult = new int[0];
            for (int i=0; i < n; i++)
            {
                previousResult = generateFn(previousResult);
                PrintArray(previousResult);
            }
        }

        public static void PrintArray<T>(T[] array)
        {
            foreach (T el in array)
                System.Console.Out.Write(el + " ");
            System.Console.Out.WriteLine();
        }
    }

}
