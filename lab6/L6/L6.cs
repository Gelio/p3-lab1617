using System.Collections.Generic;

namespace L6
{
    public class L6
    {
        Tier _Tier;
        public List<Hero> Heroes = new List<Hero>();
        public List<Lane> Lanes = new List<Lane>();

        public void SetTier(Tier tier)
        {
            if (!(tier is Tier))
                return;

            this._Tier = tier;
        }

        public bool? AddLane(Lane l)
        {
            if (!(l is Lane))
                return null;

            if (this._Tier?.Name != l.GetTierName())
                return null;

            return this.AddLaneIgnoreConstraints(l);
        }

        public bool AddLaneIgnoreConstraints(Lane l)
        {
            if (this.Lanes.Contains(l))
                return false;

            this.Lanes.Add(l);
            return true;
        }

        public bool? AddHero(Hero h)
        {
            if (!(h is Hero))
                return null;

            if (this._Tier?.Name != h.GetTierName())
                return null;

            bool foundLane = false;
            this.Lanes.ForEach(lane =>
            {
                if (lane.Name == h.GetLaneName())
                    foundLane = true;
            });
            if (!foundLane)
                return null;

            return this.AddHeroIgnoreConstraints(h);
        }

        public bool AddHeroIgnoreConstraints(Hero h)
        {
            if (this.Heroes.Contains(h))
                return false;

            this.Heroes.Add(h);
            return true;
        }

        public bool? AreAllLanesDifferent()
        {
            if (this.Heroes.Count == 0)
                return null;

            foreach (Hero h in this.Heroes)
            {
                foreach (Hero h2 in this.Heroes)
                {
                    if (!h.Equals(h2) && h.GetLaneName() == h2.GetLaneName())
                        return false;
                }
            }

            return true;
        }

    }
}
