using System;
using System.Collections.Generic;

namespace EliteDangerousTradingAssistant
{
    public class StarSystem
    {
        private string name;
        private List<Station> stations;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Station> Stations
        {
            get { return stations; }
        }

        public StarSystem()
        {
            stations = new List<Station>();
        }
        public StarSystem(StarSystem copy)
        {
            stations = new List<Station>();

            name = copy.Name;

            foreach (Station station in copy.Stations)
                stations.Add(new Station(station));
        }
    }
}
