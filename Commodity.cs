using System;

namespace EliteDangerousTradingAssistant
{

    public class Commodity
    {
        private string name;
        private decimal buyPrice;
        private decimal sellPrice;
        private decimal supply;
        private DateTime lastUpdated;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal BuyPrice
        {
            get { return buyPrice; }
            set { buyPrice = value; }
        }
        public decimal SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }
        public decimal Supply
        {
            get { return supply; }
            set { supply = value; }
        }
        public DateTime LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }

        public Commodity()
        {
        }
        public Commodity(Commodity copy)
        {
            name = copy.Name;
            buyPrice = copy.BuyPrice;
            sellPrice = copy.SellPrice;
            supply = copy.supply;
            lastUpdated = copy.LastUpdated;
        }

        public bool Equals(Commodity compareTo)
        {
            if (name != compareTo.Name || buyPrice != compareTo.BuyPrice || sellPrice != compareTo.SellPrice || supply != compareTo.Supply)
                return false;

            return true;
        }
    }
}
