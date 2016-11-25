
namespace L6
{
    public class Lane : Tier
    {
        public readonly new string Name;

        public Lane(string Name, string _Tier) : base(_Tier)
        {
            this.Name = Name;
        }

        public string GetTierName()
        {
            return base.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Lane))
                return false;

            return base.Equals((Tier)obj) && this.Name == ((Lane)obj).Name;
        }
    }
}
