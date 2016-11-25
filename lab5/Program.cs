using System;
namespace Lab05a
{
    public abstract class WartoscLogiczna
    {
        public abstract bool ObliczWartosc();
        public abstract WartoscLogiczna KopiujGleboko();
        public void Print()
        {
            Console.WriteLine(ObliczWartosc());
        }
    }
    public class PojedynczaWartoscLogiczna : WartoscLogiczna
    {
        private bool wartosc;
        public PojedynczaWartoscLogiczna(bool war)
        {
            wartosc = war;
        }
        public void SetWartosc(bool arg)
        {
            wartosc = arg;
        }
        public override WartoscLogiczna KopiujGleboko()
        {
            return new PojedynczaWartoscLogiczna(wartosc);
        }
        public override bool ObliczWartosc()
        {
            return wartosc;
        }
    }
    public class Zaprzeczenie : WartoscLogiczna
    {
        private WartoscLogiczna wartosc;
        public Zaprzeczenie(bool war)
        {
            wartosc = new PojedynczaWartoscLogiczna(war);
        }
        public Zaprzeczenie(WartoscLogiczna war)
        {
            wartosc = war;
        }
        public override WartoscLogiczna KopiujGleboko()
        {
            return new Zaprzeczenie(wartosc);
        }
        public override bool ObliczWartosc()
        {
            return !wartosc.ObliczWartosc();
        }
    }
    class And : WartoscLogiczna
    {
        private WartoscLogiczna[] argumenty;
        public And(bool[] tab)
        {
            WartoscLogiczna[] nowa;
            nowa = new WartoscLogiczna[tab.Length];
            for (int i = 0; i < nowa.Length; i++)
            {
                nowa[i] = new PojedynczaWartoscLogiczna(tab[i]);
            }
            argumenty = nowa;
        }
        public And(WartoscLogiczna[] tab)
        {
            WartoscLogiczna[] nowa = new WartoscLogiczna[tab.Length];
            for (int i = 0; i < nowa.Length; i++)
            {
                nowa[i] = tab[i];
            }
            argumenty = nowa;
        }
        public override WartoscLogiczna KopiujGleboko()
        {
            return new And(argumenty);
        }
        public override bool ObliczWartosc()
        {


            for (int i = 0; i < argumenty.Length; i++)
            {
                if (argumenty[i].ObliczWartosc() == false)
                    return false;
            }
            return true;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---ETAP 1 i 2---");
            PojedynczaWartoscLogiczna pwl1 = new PojedynczaWartoscLogiczna(true);
            Console.WriteLine("pwl1:");
            pwl1.Print();
            Console.WriteLine("pwl1 - jej wartosc to {0}, a oczekiwano True", pwl1.ObliczWartosc());
            PojedynczaWartoscLogiczna pwl2 = new PojedynczaWartoscLogiczna(false);
            Console.WriteLine("pwl2:");
            pwl2.Print();
            Console.WriteLine("pwl2 - jej wartosc to {0}, a oczekiwano False", pwl2.ObliczWartosc());

            Console.WriteLine("---ETAP 1 i 2 - kopiowanie---");
            PojedynczaWartoscLogiczna pwl1a = (PojedynczaWartoscLogiczna)pwl1.KopiujGleboko();
            pwl1.SetWartosc(false);
            Console.WriteLine("pwl1:");
            pwl1.Print();
            Console.WriteLine("pwl1a:");
            pwl1a.Print();
            Console.WriteLine("pwl1a - jej wartosc to {0}, a oczekiwano True", pwl1a.ObliczWartosc());

            Console.WriteLine("---ETAP 3---");
            Zaprzeczenie z1 = new Zaprzeczenie(true);
            Console.WriteLine("z1:");
            z1.Print();
            Console.WriteLine("z1 - jej wartosc to {0}, a oczekiwano False", z1.ObliczWartosc());
            Zaprzeczenie z2 = new Zaprzeczenie(false);
            Console.WriteLine("z2:");
            z2.Print();
            Console.WriteLine("z2 - jej wartosc to {0}, a oczekiwano True", z2.ObliczWartosc());
            pwl1.SetWartosc(true);
            Zaprzeczenie z3 = new Zaprzeczenie(pwl1);

            Console.WriteLine("z3:");
            z3.Print();
            Console.WriteLine("z3 - jej wartosc to {0}, a oczekiwano False", z3.ObliczWartosc());
            Zaprzeczenie z4 = new Zaprzeczenie(pwl2);
            Console.WriteLine("z4:");
            z4.Print();
            Console.WriteLine("z4 - jej wartosc to {0}, a oczekiwano True", z4.ObliczWartosc());

            Console.WriteLine("---ETAP 3 - kopiowanie---");
            Zaprzeczenie z3a = z3.KopiujGleboko() as Zaprzeczenie;
            pwl1.SetWartosc(false);
            Console.WriteLine("z3:");
            z3.Print();
            Console.WriteLine("z3a:");
            z3a.Print();
            Console.WriteLine("z3a - jej wartosc to {0}, a oczekiwano False", z3a.ObliczWartosc());

            Console.WriteLine("---ETAP 4---");
            bool[] tabb1 = { true, true, true, true };
            bool[] tabb2 = { true, false, true, true };
            bool[] tabb3 = { false, false, false, false };
            And and1 = new And(tabb1);
            Console.WriteLine("and1:");
            and1.Print();
            Console.WriteLine("and1 - jej wartosc to {0}, a oczekiwano True", and1.ObliczWartosc());
            And and2 = new And(tabb2);
            Console.WriteLine("and2:");
            and2.Print();
            Console.WriteLine("and2 - jej wartosc to {0}, a oczekiwano False", and2.ObliczWartosc());
            And and3 = new And(tabb3);
            Console.WriteLine("and3:");
            and3.Print();
            Console.WriteLine("and3 - jej wartosc to {0}, a oczekiwano False", and3.ObliczWartosc());
            WartoscLogiczna[] tabb4 = { new PojedynczaWartoscLogiczna(true), z3, new PojedynczaWartoscLogiczna(true), new PojedynczaWartoscLogiczna(true) };
            WartoscLogiczna[] tabb5 = { new PojedynczaWartoscLogiczna(true), z3a, new PojedynczaWartoscLogiczna(true), new PojedynczaWartoscLogiczna(true) };
            WartoscLogiczna[] tabb6 = { new PojedynczaWartoscLogiczna(false), new PojedynczaWartoscLogiczna(false), new PojedynczaWartoscLogiczna(false), new PojedynczaWartoscLogiczna(false) };
            And and4 = new And(tabb4);
            Console.WriteLine("and4:");
            and4.Print();
            Console.WriteLine("and4 - jej wartosc to {0}, a oczekiwano True", and4.ObliczWartosc());
            And and5 = new And(tabb5);
            Console.WriteLine("and5:");
            and5.Print();
            Console.WriteLine("and5 - jej wartosc to {0}, a oczekiwano False", and5.ObliczWartosc());
            And and6 = new And(tabb6);
            Console.WriteLine("and6:");
            and6.Print();
            Console.WriteLine("and6 - jej wartosc to {0}, a oczekiwano False", and6.ObliczWartosc());

            Console.WriteLine("---ETAP 4 - kopiowanie ---");
            And and4a = and4.KopiujGleboko() as And;
            (tabb4[0] as PojedynczaWartoscLogiczna).SetWartosc(false);
            Console.WriteLine("and4:");
            and4.Print();
            Console.WriteLine("and4a:");
            and4a.Print();
            Console.WriteLine("and4a - jej wartosc to {0}, a oczekiwano True", and4a.ObliczWartosc());
        }
    }
}