using System;
using System.Collections;

namespace Lab8a
{
class MainClass
    {
        public static void Main (string[] args)
            {
            IEnumerable seq1 = Sequences.ArithmeticSequence(2, 3);
            IEnumerable seq2 = Sequences.ArithmeticSequence(1, 1);
            Console.Out.WriteLine("Etap 1:");
            Sequences.PrintN(new int[] { 1, 2, 3, 4 }, 4);
            Sequences.PrintN(new int[] { 1, 2, 3, 4 }, 2);
            Sequences.PrintN(new int[] { 1, 2, 3, 4 }, 10);
            Sequences.PrintN(seq1, 10);
            Sequences.PrintN(seq1, 10);
            Sequences.PrintN(seq2, 20);
            Sequences.PrintN(Sequences.SubtractX(seq1, 8), 10);
            Sequences.PrintN(Sequences.SubtractX(new int[] { -2, 2, -2, 2 }, 8), 10);

            Console.Out.WriteLine("\nEtap 2:");
            Sequences.PrintN(Sequences.RepeatNTimes(new int[] { 1, 2, 3 }, 3), 20);
            Sequences.PrintN(Sequences.RepeatNTimes(seq1, 3), 20);
            Sequences.PrintN(Sequences.RepeatNTimes(seq2, 3), 20);
            Console.Out.WriteLine("LastOrDefault:");
            Console.Out.WriteLine(Sequences.LastOrDefault(new int[] { 1, 2, 3 }, 0));
            Console.Out.WriteLine(Sequences.LastOrDefault(new int[] { }, 0));
            Console.Out.WriteLine("LimitSeq:");
            Sequences.PrintN(Sequences.LimitSeq(seq1, 10), 20);
            Sequences.LastOrDefault(Sequences.LimitSeq(seq1, 10), -1024);

            Console.Out.WriteLine("\nEtap 3:");
            Console.Out.WriteLine(Sequences.InnerProduct(new int[] { 1, 2, 3 }, new int[] { 0, 5, 1 }));
            Console.Out.WriteLine(Sequences.InnerProduct(new int[] { 1, 2, 3, 1, 1, 1, 1 }, new int[] { 0, 5, 1 }));
            Console.Out.WriteLine(Sequences.InnerProduct(new int[] { 1, 2, 3 }, seq1));
            Console.Out.WriteLine(Sequences.InnerProduct(new int[] { }, seq1));
            Console.Out.WriteLine(Sequences.InnerProduct(seq1, new int[] { }));

            Console.Out.WriteLine("NotDividingNeighboursSubsequence");
            Sequences.PrintN(Sequences.NotDividingNeighboursSubsequence(seq1), 10);
            Sequences.PrintN(Sequences.NotDividingNeighboursSubsequence(new int[] { 2, 4, 2, 4, 2, 4, 2, 4, 5, 13, 26, 2 }), 10);
            Sequences.PrintN(Sequences.NotDividingNeighboursSubsequence(new int[] { }), 10);
            Sequences.PrintN(Sequences.NotDividingNeighboursSubsequence(new int[] { 2 }), 10);

            Console.Out.WriteLine("\nEtap 4:");
            Sequences.PrintN(Sequences.Interleave(new int[] { 1, 2, 3, 4 }, new int[] { -1, -2, -3, -4 }), 20);
            Sequences.PrintN(Sequences.Interleave(new int[] { }, new int[] { }), 20);
            Sequences.PrintN(Sequences.Interleave(seq1, seq2), 20);
            Sequences.PrintN(Sequences.Interleave(seq1, new int[] { }), 20);
            Sequences.PrintN(Sequences.Interleave(new int[] { }, seq1), 20);
            Sequences.PrintN(Sequences.Interleave(new int[] { -1, -2, -3 }, seq1), 20);
            Sequences.PrintN(Sequences.Interleave(seq1, new int[] { -1, -2, -3, -4 }), 20);

            Console.Out.WriteLine("\nEtap 5:");
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { -1, 1, -1, 1, -1, 1, -1, 1 }, new int[] { -1 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { -1, 1, -1, 1, -2, 1, -1, 1 }, new int[] { -1 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { -1, 2, -1, 1, -1, 1, -1, 1 }, new int[] { -1 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, -18, 27 }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5 }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 0, 1, -2, 7, 0, 13, -18, 27 }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, 18, 27 }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 0, 1, -2, 7, 0, 13, -18, 27 }, new int[] { 0, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, -18, 27 }, new int[] { 1, 1, -2, 2 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, -2, 7, 0, 13, 18, 27 }, new int[] { 0, 0, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 1, 3, 5, 2, 1, 3, 5, 2, 1, 3, 5, 2, 1, 3, 5, 2, 1, 3, 5, 2, 1, 3, 5, 2, 1, 3, 5, 2 }, new int[] { 0, 0, 0, 1 }));
            Console.Out.WriteLine(Sequences.IsRecurrenceEquation(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }));
        }
    }
}

