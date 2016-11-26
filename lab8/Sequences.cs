using System;
using System.Collections;

namespace Lab8a
{
    class Sequences
    {
        static public void PrintN(IEnumerable e, int n)
        {
            int i = 0;
            foreach(var element in e)
            {
                i += 1;
                if (i > n)
                    break;
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }

        static public IEnumerable ArithmeticSequence(int initial, int difference)
        {
            int current = initial;
            while (true)
            {
                yield return current;
                current += difference;
            }
        }

        static public IEnumerable SubtractX(IEnumerable e, int difference)
        {
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
                yield return (int)enumerator.Current - difference;
        }


        static public IEnumerable RepeatNTimes(IEnumerable e, int n)
        {
            for (int i = 0; i < n; i++)
            {
                IEnumerator enumerator = e.GetEnumerator();
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }
        }

        static public IEnumerable LimitSeq(IEnumerable sequence, int n)
        {
            IEnumerator enumerator = sequence.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                i += 1;
                if (i > n)
                    yield break;
                yield return enumerator.Current;
            }
        }

        static public int LastOrDefault(IEnumerable e, int defaultVal)
        {
            int previous = defaultVal;
            IEnumerator enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
                previous = (int)enumerator.Current;
            return previous;
        }
        static public int InnerProduct(IEnumerable e1, IEnumerable e2)
        {
            IEnumerator enumerator1 = e1.GetEnumerator(),
                enumerator2 = e2.GetEnumerator();

            int product = 0;
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
                product += (int)enumerator1.Current * (int)enumerator2.Current;

            return product;
        }

        static public IEnumerable NotDividingNeighboursSubsequence(IEnumerable sequence)
        {
            int previous = -1;
            IEnumerator enumerator = sequence.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (previous < 0)
                {
                    previous = (int)enumerator.Current;
                    yield return enumerator.Current;
                    continue;
                }

                int current = (int)enumerator.Current;
                if (current % previous == 0 || previous % current == 0)
                    continue;
                previous = current;
                yield return current;
            }
        }

        static public IEnumerable Interleave(IEnumerable seq1, IEnumerable seq2)
        {
            IEnumerator e1 = seq1.GetEnumerator(),
                    e2 = seq2.GetEnumerator();
            bool e1NotFinished;

            while ((e1NotFinished = e1.MoveNext()) && e2.MoveNext())
            {
                yield return e1.Current;
                yield return e2.Current;
            }

            if (e1NotFinished)
                yield return e1.Current;

            while (e1.MoveNext())
                yield return e1.Current;

            while (e2.MoveNext())
                yield return e2.Current;
        }

        static public bool IsRecurrenceEquation(IEnumerable sequence, int[] coefficients)
        {
            int n = coefficients.Length;
            int[] lastValues = new int[n];
            int i = 0;
            int sum = 0;

            foreach (int value in sequence)
            {
                if (i >= n)
                {
                    // Sprawdzenie sumy
                    sum = 0;
                    for (int j = 0; j < n; j++)
                        sum += coefficients[j] * lastValues[j];
                    if (sum != value)
                        return false;
                }

                // Dodaj elementy
                for (int j = n-1; j > 0; j--)
                    lastValues[j] = lastValues[j - 1];
                lastValues[0] = value;
                i++;
            }

            return true;
        }

    }
}
