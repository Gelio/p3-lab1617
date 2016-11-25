
using System;

public class Program
    {

    public static void Main()
        {
        Zbior z;
        ulong a;

        Console.WriteLine();
        Console.WriteLine("*****   ETAP I  (1.5 pkt.)   *****");
        Console.WriteLine();

        Zbior z0 = new Zbior(0x5AUL);
        a = (ulong)z0;
        Console.WriteLine("wartosc liczbowa z0 to {0} (powinno byc 90)", a);
        Console.WriteLine();

        Zbior z1 = 1;
        a = (ulong)z1;
        Console.WriteLine("wartosc liczbowa z1 to {0} (powinno byc 2)", a);
        Console.WriteLine();

        Zbior z2 = new Zbior(1, 3, 4, 6);
        Zbior z3 = new Zbior(2, 4);
        a = (ulong)z3;
        Console.WriteLine("wartosc liczbowa z3 to {0} (powinno byc 20)", a);
        Console.WriteLine();

        z = z1 | z3;
        a = (ulong)z;
        Console.WriteLine("wartosc liczbowa z to {0} (powinno byc 22)", a);
        Console.WriteLine();

        z -= z3;
        a = (ulong)z;
        Console.WriteLine("wartosc liczbowa z to {0} (powinno byc 2)", a);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("*****   ETAP II  (1.5 pkt.)   *****");
        Console.WriteLine();

        Console.WriteLine("czy z == z1 ? {0} (powinno byc True)", z == z1);
        Console.WriteLine("a teraz czy z == z1 ? {0} (powinno byc True)", z.Equals(z1));
        Console.WriteLine("czy z == z2 ? {0} (powinno byc False)", z == z2);
        Console.WriteLine("skrot (hash) z3 to {0} (powinno byc 20)", z3.GetHashCode());
        Console.WriteLine();

        Console.WriteLine("czy 3 nalezy do z2 ? {0} (powinno byc True)", z2[3]);
        Console.WriteLine("czy 9 nalezy do z2 ? {0} (powinno byc False)", z2[9]);
        z2[9] = true;
        Console.WriteLine("czy teraz 9 nalezy do z2 ? {0} (powinno byc True)", z2[9]);
        z2[9] = false;
        Console.WriteLine("a teraz 9 nalezy do z2 ? {0} (powinno byc False)", z2[9]);
        Console.WriteLine();

        Console.WriteLine("zbior z2 to {0} (powinno byc {{ 1 3 4 6 }})", z2);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("*****   ETAP III  (1.0 pkt.)   *****");
        Console.WriteLine();

        Console.WriteLine("iloczyn z2 i z3 to {0} (powinno byc {{ 4 }})", z2 & z3);
        Console.WriteLine("roznica z2 i z3 to {0} (powinno byc {{ 1 3 6 }})", z2 - z3);
        Console.WriteLine("roznica z3 i z2 to {0} (powinno byc {{ 2 }})", z3 - z2);
        Console.WriteLine();

        Console.WriteLine("czy z2 zawiera się w z3 ? {0} (powinno byc False)", z2 <= z3);
        Console.WriteLine("czy z2 zawiera w sobie z3 ? {0} (powinno byc False)", z2 >= z3);
        Console.WriteLine("czy z1 zawiera się w z2 ? {0} (powinno byc True)", z1 <= z2);
        z = z2;
        Console.WriteLine("czy z2 zawiera się w z2 ? {0} (powinno byc True)", z2 <= z);
        Console.WriteLine();

        z = new Zbior(0xCFFUL);
        Console.WriteLine("test dopelnienia i iloczynu {0} (powinno byc {{ 0 2 5 7 10 11 }})", z & !z2);
        Console.WriteLine();

        Console.WriteLine("z2 ma {0} elementy (powinno byc 4)", z2.Ile);
        Console.WriteLine("najwiekszy element z2 to {0} (powinno byc 6)", z2.Max);
        Console.WriteLine("najwiekszy element zbioru pustego to {0} (powinno byc -1)", Zbior.Pusty.Max);
        Console.WriteLine();

        Console.WriteLine("czy iloczyn zbiorow z1 i z3 jest pusty ? {0} (powinno True)", (z1 & z3) == Zbior.Pusty);
        Console.WriteLine();

        z = z1;
        z[8] = true;
        Console.WriteLine("jeszcze jeden test rownosci {0} (powinno False)", z == z1);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("*****   ETAP IV  (1.0 pkt.)   *****");
        Console.WriteLine();

        //Console.WriteLine("wszystkie podzbiory zbioru {0} to:",z2);
        //Zbior[] tab = z2.Podzbiory();
        //for ( int i=0 ; i<tab.Length ; ++ i )
        //    Console.WriteLine(" {0,2}:  {1}",i,tab[i]);
        //Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("*****   KONIEC   *****");
        Console.WriteLine();

        }

    }