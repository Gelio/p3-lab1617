using System;
class Zbior
{
    private ulong elementy;

    public Zbior(ulong _elementy)
    {
        elementy = _elementy;
    }

    public Zbior(params int[] _elementy)
    {
        foreach(int element in _elementy)
        {
            if (element < 0 || element > 64)
                continue;

            elementy |= (ulong)Math.Pow(2, element);
        }
    }

    public static explicit operator ulong(Zbior z)
    {
        return z.elementy;
    }

    public static implicit operator Zbior(int element)
    {
        return new Zbior(element);
    }

    public static Zbior operator|(Zbior z1, Zbior z2)
    {
        return new Zbior((ulong)z1 | (ulong)z2);
    }

    public static Zbior operator&(Zbior z1, Zbior z2)
    {
        return new Zbior((ulong)z1 & (ulong)z2);
    }

    public static Zbior operator^(Zbior z1, Zbior z2)
    {
        return new Zbior((ulong)z1 ^ (ulong)z2);
    }

    public static Zbior operator-(Zbior z1, Zbior z2)
    {
        return new global::Zbior((ulong)z1 & ~(ulong)z2);
    }

    public static Zbior operator!(Zbior z)
    {
        return new Zbior(~(ulong)z);
    }

    public static bool operator==(Zbior z1, Zbior z2)
    {
        return z1.elementy == z2.elementy;
    }

    public static bool operator!=(Zbior z1, Zbior z2)
    {
        return !(z1 == z2);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Zbior))
            return false;

        return this == (Zbior)obj;
    }

    public override int GetHashCode()
    {
        return elementy.GetHashCode();
    }

    public bool this[int element]
    {
        get
        {
            return (elementy & (ulong)Math.Pow(2, element)) > 0;
        }

        set
        {
            if (value)
            {
                elementy |= (ulong)Math.Pow(2, element);
            } else
            {
                elementy &= ~(ulong)Math.Pow(2, element);
            }
        }
    }

    public override string ToString()
    {
        string output = "{ ";
        for(int i=0; i < 64; i++)
        {
            if (this[i])
                output += i + " ";
        }
        output += "}";
        return output;
    }

    public int Ile
    {
        get
        {
            int ile = 0;
            for(int i=0; i < 64; i++)
            {
                if (this[i])
                    ile++;
            }

            return ile;
        }
    }

    public int Max
    {
        get
        {
            for (int i = 63; i >= 0; i--)
                if (this[i])
                    return i;

            return -1;
        }
    }

    public static Zbior Pusty
    {
        get
        {
            return new Zbior();
        }
    }

    public static bool operator<=(Zbior z1, Zbior z2)
    {
        return (z1 - z2) == Zbior.Pusty;
    }

    public static bool operator>=(Zbior z1, Zbior z2)
    {
        return z2 <= z1;
    }
}
