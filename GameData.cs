using System.Collections.Generic;

namespace EliteDangerousTradingAssistant
{
    public enum EditorMode
    {
        View, Edit
    }

    public class GameData
    {
        private List<StarSystem> starSystems;
        private List<Trade> trades;
        private List<Manifest> optimalManifests;
        private List<Manifest> userManifests;
        private List<Route> optimalRoutes;
        private List<Route> userRoutes;

        private decimal capital;
        private decimal cargoSlots;

        public List<StarSystem> StarSystems
        {
            get { return starSystems; }
        }
        public List<Trade> Trades
        {
            get { return trades; }
        }
        public List<Manifest> OptimalManifests
        {
            get { return optimalManifests; }
        }
        public List<Manifest> UserManifests
        {
            get { return userManifests; }
        }
        public List<Route> OptimalRoutes
        {
            get { return optimalRoutes; }
        }
        public List<Route> UserRoutes
        {
            get { return userRoutes; }
        }

        public decimal Capital
        {
            get { return capital; }
            set { capital = value; }
        }
        public decimal CargoSlots
        {
            get { return cargoSlots; }
            set { cargoSlots = value; }
        }

        public GameData()
        {
            starSystems = new List<StarSystem>();
            trades = new List<Trade>();
            optimalManifests = new List<Manifest>();
            userManifests = new List<Manifest>();
            optimalRoutes = new List<Route>();
            userRoutes = new List<Route>();
        }
    }
}
