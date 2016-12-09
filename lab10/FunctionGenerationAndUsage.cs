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
    }

}
