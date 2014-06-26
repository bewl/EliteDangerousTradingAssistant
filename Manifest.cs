using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteDangerousTradingAssistant
{
    public class Manifest
    {
        private List<Trade> trades;
        private decimal capital;
        private decimal cargoSlots;
        private string limitingFactor;

        public List<Trade> Trades
        {
            get { return trades; }
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
        public string LimitingFactor
        {
            get { return limitingFactor; }
        }
        public decimal Investment
        {
            get
            {
                decimal totalInvestment = 0;

                foreach (Trade trade in trades)
                    totalInvestment += trade.UnitsBought * trade.Commodity.BuyPrice;

                return totalInvestment;
            }
        }
        public decimal Profit
        {
            get
            {
                decimal totalProfit = 0;

                foreach (Trade trade in trades)
                    totalProfit += trade.TotalProfit;

                return totalProfit;
            }
        }
        public decimal ROI
        {
            get { return Investment > 0 ? Profit / Investment : 0; }
        }
        public DateTime OldestDate
        {
            get
            {
                DateTime oldest = DateTime.MaxValue;

                foreach (Trade trade in trades)
                    if (trade.Commodity.LastUpdated < oldest)
                        oldest = trade.Commodity.LastUpdated;

                return oldest;
            }
        }

        public void AddTrade(Trade trade)
        {
            trades.Add(trade);
        }

        public Manifest()
        {
            trades = new List<Trade>();
        }
        public Manifest(Manifest copy)
        {
            trades = new List<Trade>();

            foreach (Trade trade in copy.Trades)
                this.trades.Add(new Trade(trade));

            this.capital = copy.capital;
            this.cargoSlots = copy.cargoSlots;
            this.limitingFactor = copy.limitingFactor;
        }

        public void OptimizeManifest()
        {
            while (capital > 0 && cargoSlots > 0)
            {
                //Score all trades
                foreach (Trade trade in trades)
                    trade.ScoreTrade(capital, cargoSlots);

                //Remove trades with 0 score.
                for (int x = 0; x < trades.Count; x++)
                    if (trades[x].Score <= 0 && trades[x].UnitsBought == 0)
                    {
                        trades.RemoveAt(x);
                        x--;
                    }

                //Find trade with max score that has not already been used for purchase.
                Trade maxScoreTrade = null;

                foreach (Trade trade in trades)
                    if ((maxScoreTrade == null || trade.Score > maxScoreTrade.Score) && trade.UnitsBought == 0)
                        maxScoreTrade = trade;

                //No valid trades exist to make more purchases. This manifest is done.
                if (maxScoreTrade == null)
                    break;

                //Purchase the commodity  and update the available capital and cargo slots.
                maxScoreTrade.UnitsBought = maxScoreTrade.AffordUnits(capital, cargoSlots);
                capital = capital - (maxScoreTrade.UnitsBought * maxScoreTrade.Commodity.BuyPrice);
                cargoSlots = cargoSlots - maxScoreTrade.UnitsBought;
            }

            for (int x = 0; x < trades.Count; x++)
                if (trades[x].UnitsBought == 0)
                {
                    trades.RemoveAt(x);
                    x--;
                }

            if (capital <= 0)
                limitingFactor = "Capital. Try to earn or invest more capital for more lucrative results.";
            else if (cargoSlots <= 0)
                limitingFactor = "Cargo Hold. Try to expand the cargo hold or buy a larger ship for more lucrative results.";
            else
                limitingFactor = "Lack of Trades. Try expanding your known galaxy by adding more systems, stations, and commodities.";
        }

        public bool Equals(Manifest compareTo)
        {
            if (trades.Count != compareTo.trades.Count || capital != compareTo.Capital || cargoSlots != compareTo.cargoSlots || limitingFactor != compareTo.limitingFactor ||
                Investment != compareTo.Investment || Profit != compareTo.Profit)
                return false;

            return true;
        }
    }
}
