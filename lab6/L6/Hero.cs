
namespace L6
{
    public class Hero : Lane
    {
        public new readonly string Name;

        public Hero(string Name, string _Lane, string _Tier) : base (_Lane, _Tier)
        {
            this.Name = Name;
        }

        public string GetLaneName()
        {
            return base.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hero))
                return false;

            return base.Equals((Lane)obj) && this.Name == ((Hero)obj).Name;
        }
    }
}
