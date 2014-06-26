using System.Collections.Generic;

namespace EliteDangerousTradingAssistant
{
    public class Station
    {
        private string name;
        private List<Commodity> commodities;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Commodity> Commodities
        {
            get { return commodities; }
        }

        public Station()
        {
            commodities = new List<Commodity>();
        }
        public Station(Station copy)
        {
            commodities = new List<Commodity>();

            name = copy.Name;

            foreach (Commodity commodity in copy.Commodities)
                commodities.Add(new Commodity(commodity));
        }
    }
}
