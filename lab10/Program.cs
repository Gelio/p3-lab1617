using System;
using System.Collections.Generic;

namespace lab10A
{
    class Program
    {
        public static void PrintArray<T>(T[] array)
        {
            foreach (T el in array)
                System.Console.Out.Write(el + " ");
            System.Console.Out.WriteLine();
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (T el in list)
                System.Console.Out.Write(el + " ");
            System.Console.Out.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Etap 1: czesc 1");

            Console.Write(FunctionGenerationAndUsage.LukasiewiczTnormGeneration()(0.6, 0.6) + " ");
            Console.Write(FunctionGenerationAndUsage.LukasiewiczTnormGeneration()(0.3, 0.6) + " ");
            Console.Write(FunctionGenerationAndUsage.LukasiewiczTnormGeneration()(0.6, 0.9) + " ");
            Console.Write(FunctionGenerationAndUsage.LukasiewiczTnormGeneration()(0.6, 1.0) + " ");
            Console.Write(FunctionGenerationAndUsage.LukasiewiczTnormGeneration()(1.0, 0.6) + "\n");
            Console.WriteLine("Powinno byc:\n0,2 0 0,5 0,6 0,6");

            Console.WriteLine("\nEtap 1: czesc 2");
            Console.WriteLine(FunctionGenerationAndUsage.ReduceManyArguments(FunctionGenerationAndUsage.LukasiewiczTnormGeneration(), 1, 0.99, 0.67, 0.87, 0.96));
            Console.WriteLine("Powinno byc: 0,49");
            Console.WriteLine(FunctionGenerationAndUsage.ReduceManyArguments(FunctionGenerationAndUsage.LukasiewiczTnormGeneration(), 1, 0.89, 0.57, 0.67, 0.96));
            Console.WriteLine("Powinno byc: 0,089999999");


            Console.WriteLine("\nEtap 2: czesc 1");

            //uzupelnij funkcja, ktora przyjmuje x i zwraca sin(x+pi)+1.0
            Func<double, double> testFn = x => (Math.Sin(x + Math.PI) + 1.0);
            Console.Write(FunctionGenerationAndUsage.QuadraticFunction(testFn, 0.6, 0.8, 1)(1) + " ");
            Console.Write(FunctionGenerationAndUsage.QuadraticFunction(testFn, 0.3, 0.6, -3)(0.5) + " ");
            Console.Write(FunctionGenerationAndUsage.QuadraticFunction(testFn, 0.6, 0.1, 0)(-0.5) + " ");
            Console.Write(FunctionGenerationAndUsage.QuadraticFunction(testFn, 2.0, 1.0, 0.5)(0.8) + " ");
            Console.Write(FunctionGenerationAndUsage.QuadraticFunction(testFn, 1.0, 0.6, 0.1)(1.2) + "\n");

            Console.WriteLine("Powinno byc:\n1,14190208134835 -2,60635599220526 1,46116250842502 0,942419067803675 0,145395234255834");

            Console.WriteLine("\nEtap 2: czesc 2");

            //uzupelnij funkcja, ktora przyjmuje x i zwraca sin(x+pi)+1.0
            Console.WriteLine(FunctionGenerationAndUsage.IsMonotonic(0, 1, 20,
                FunctionGenerationAndUsage.QuadraticFunction(testFn, 0.6, 0.8, 1)));
            Console.WriteLine("Powinno byc: True");
            Console.WriteLine(FunctionGenerationAndUsage.IsMonotonic(0, 2, 20,
                FunctionGenerationAndUsage.QuadraticFunction(testFn, -0.6, 0.8, 1)));
            Console.WriteLine("Powinno byc: False");

            List<Point2D> points = new List<Point2D>() { new Point2D(0.3, -0.4),
                new Point2D(0.7, 0.4), new Point2D(0.8, -0.1), new Point2D(-1.5, -0.77),
                new Point2D(-0.7, -1.4), new Point2D(2.3, 1.4), new Point2D(-0.3, -0.221),
                new Point2D(1.3, -1.2)};

            Console.WriteLine("\nEtap 3: czesc 1");

            Console.Write(FunctionGenerationAndUsage.ManhattanDistance()(points[0], points[1]) + " ");
            Console.Write(FunctionGenerationAndUsage.ManhattanDistance()(points[0], points[2]) + " ");
            Console.Write(FunctionGenerationAndUsage.ManhattanDistance()(points[2], points[1]) + " ");
            Console.Write(FunctionGenerationAndUsage.ManhattanDistance()(points[3], points[1]) + " ");
            Console.Write(FunctionGenerationAndUsage.ManhattanDistance()(points[4], points[2]) + "\n");
            Console.WriteLine("Powinno byc:\n1,2 0,8 0,6 3,37 2,8");

            Console.WriteLine("\nEtap 3: czesc 2");
            Console.WriteLine(FunctionGenerationAndUsage.Medoid(points, FunctionGenerationAndUsage.ManhattanDistance()));
            Console.WriteLine("Powinno byc: 0,3, -0,4");


            Console.WriteLine("\nEtap 4: czesc 1");
            int[] array = new int[] { 4, 5, 6 };
            PrintArray(FunctionGenerationAndUsage.PascalTriangleGeneration(1, 2, 3)(array));
            Console.WriteLine("Powinno byc: 4 9 11 6");

            Console.WriteLine("\nEtap 4: czesc 2");
            //powinnismy otrzymac
            //1
            //1 1
            //1 2 1
            //1 3 3 1
            //1 4 6 4 1
            //1 5 10 10 5 1

            FunctionGenerationAndUsage.TriangleGeneration(FunctionGenerationAndUsage.PascalTriangleGeneration(1, 1, 1), 6);
            Console.WriteLine(String.Empty);
        }
    }
}
