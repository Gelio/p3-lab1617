
namespace L6
{
    public class Tier : object
    {
        public readonly string Name;

        public Tier(string name)
        {
            this.Name = name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Tier))
                return false;

            return this.Name == ((Tier)obj).Name;
        }
    }
}
