using System;

namespace EliteDangerousTradingAssistant
{
    public class Trade
    {
        private Commodity commodity;
        private StarSystem startSystem;
        private StarSystem endSystem;
        private Station startStation;
        private Station endStation;
        private decimal unitsBought = 0;
        private decimal score = 0;

        public Commodity Commodity
        {
            get { return commodity; }
            set { commodity = value; }
        }
        public StarSystem StartSystem
        {
            get { return startSystem; }
            set { startSystem = value; }
        }
        public StarSystem EndSystem
        {
            get { return endSystem; }
            set { endSystem = value; }
        }
        public Station StartStation
        {
            get { return startStation; }
            set { startStation = value; }
        }
        public Station EndStation
        {
            get { return endStation; }
            set { endStation = value; }
        }
        public decimal ProfitPerUnit
        {
            get { return commodity.SellPrice - commodity.BuyPrice; }
        }
        public decimal ROI
        {
            get { return commodity.BuyPrice > 0 ? ProfitPerUnit / commodity.BuyPrice : 0; }
        }
        public decimal UnitsBought
        {
            get { return unitsBought; }
            set { unitsBought = value; }
        }
        public decimal TotalProfit
        {
            get { return ProfitPerUnit * unitsBought; }
        }
        public decimal Score
        {
            get { return score; }
        }

        public Trade()
        {
            commodity = new Commodity();
        }
        public Trade(Trade copy)
        {
            commodity = new Commodity(copy.Commodity);
            startSystem = new StarSystem(copy.StartSystem);
            endSystem = new StarSystem(copy.EndSystem);
            startStation = new Station(copy.StartStation);
            endStation = new Station(copy.EndStation);
            unitsBought = copy.UnitsBought;
            score = copy.Score;
        }

        public decimal AffordUnits(decimal credits, decimal cargoSlots)
        {
            decimal afford = commodity.BuyPrice > 0 ? Math.Floor(credits / commodity.BuyPrice) : 0;

            return Math.Min(Math.Min(afford, commodity.Supply), cargoSlots);
        }
        public void ScoreTrade(decimal credits, decimal cargoSlots)
        {
            decimal affordUnits = AffordUnits(credits, cargoSlots);

            if (unitsBought == 0)
                score = Math.Min(affordUnits * ProfitPerUnit, cargoSlots * ProfitPerUnit);
        }

        public bool Equals(Trade compareTo)
        {
            if (commodity.Equals(compareTo.Commodity) == false)
                return false;

            if (startSystem.Name != compareTo.StartSystem.Name || endSystem.Name != compareTo.EndSystem.Name || 
                startStation.Name != compareTo.StartStation.Name || endStation.Name != compareTo.EndStation.Name ||
                unitsBought != compareTo.UnitsBought || score != compareTo.Score)
                return false;

            return true;
        }
    }
}
