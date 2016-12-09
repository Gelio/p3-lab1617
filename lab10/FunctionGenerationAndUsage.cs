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
    }

}
