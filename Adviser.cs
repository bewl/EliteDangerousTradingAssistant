using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteDangerousTradingAssistant
{
    public static class Adviser
    {
        static Adviser()
        {
        }

        public static void CalculateAll(GameData gameData)
        {
            CalculateAllTrades(gameData);
            CalculateOptimalManifests(gameData);
            CalculateOptimalRoutes(gameData);
        }

        private static void CalculateAllTrades(GameData gameData)
        {
            gameData.Trades.Clear();

            for (int x = 0; x < gameData.StarSystems.Count - 1; x++)
                for (int y = x + 1; y < gameData.StarSystems.Count; y++)
                {
                    StarSystem system1 = gameData.StarSystems[x];
                    StarSystem system2 = gameData.StarSystems[y];

                    foreach (Station station1 in system1.Stations)
                        foreach (Station station2 in system2.Stations)
                            foreach (Commodity commodity1 in station1.Commodities)
                                foreach (Commodity commodity2 in station2.Commodities)
                                    if (commodity1.Name == commodity2.Name)
                                    {
                                        if (commodity1.BuyPrice > 0 && commodity1.Supply > 0 && commodity1.BuyPrice < commodity2.SellPrice)
                                        {
                                            Trade newTrade = new Trade();
                                            newTrade.Commodity.Name = commodity1.Name;
                                            newTrade.Commodity.BuyPrice = commodity1.BuyPrice;
                                            newTrade.Commodity.Supply = commodity1.Supply;
                                            newTrade.Commodity.SellPrice = commodity2.SellPrice;
                                            newTrade.Commodity.LastUpdated = commodity1.LastUpdated <= commodity2.LastUpdated ? commodity1.LastUpdated : commodity2.LastUpdated;
                                            newTrade.StartSystem = system1;
                                            newTrade.EndSystem = system2;
                                            newTrade.StartStation = station1;
                                            newTrade.EndStation = station2;
                                            gameData.Trades.Add(newTrade);
                                        }

                                        if (commodity2.BuyPrice > 0 && commodity2.Supply > 0 && commodity2.BuyPrice < commodity1.SellPrice)
                                        {
                                            Trade newTrade = new Trade();
                                            newTrade.Commodity.Name = commodity1.Name;
                                            newTrade.Commodity.BuyPrice = commodity2.BuyPrice;
                                            newTrade.Commodity.Supply = commodity2.Supply;
                                            newTrade.Commodity.SellPrice = commodity1.SellPrice;
                                            newTrade.Commodity.LastUpdated = commodity1.LastUpdated <= commodity2.LastUpdated ? commodity1.LastUpdated : commodity2.LastUpdated;
                                            newTrade.StartSystem = system2;
                                            newTrade.EndSystem = system1;
                                            newTrade.StartStation = station2;
                                            newTrade.EndStation = station1;
                                            gameData.Trades.Add(newTrade);
                                        }
                                    }
                }
        }

        private static void CalculateOptimalManifests(GameData gameData)
        {
            gameData.OptimalManifests.Clear();

            foreach(Trade trade in gameData.Trades)
                if (TradePartOfExistingManifest(gameData, trade) == false)
                {
                    Manifest newManifest = new Manifest();
                    newManifest.Capital = gameData.Capital;
                    newManifest.CargoSlots = gameData.CargoSlots;
                    newManifest.AddTrade(trade);
                    gameData.OptimalManifests.Add(newManifest);
                }

            for (int x = 0; x < gameData.OptimalManifests.Count; x++)
            {
                Manifest manifest = gameData.OptimalManifests[x];

                manifest.OptimizeManifest();

                if (manifest.Profit == 0 || manifest.Trades.Count == 0)
                {
                    gameData.OptimalManifests.RemoveAt(x);
                    x--;
                }
            }
        }
        private static bool TradePartOfExistingManifest(GameData gameData, Trade trade)
        {
            foreach (Manifest manifest in gameData.OptimalManifests)
                if (manifest.Trades[0].StartSystem.Name == trade.StartSystem.Name &&
                    manifest.Trades[0].EndSystem.Name == trade.EndSystem.Name &&
                    manifest.Trades[0].StartStation.Name == trade.StartStation.Name &&
                    manifest.Trades[0].EndStation.Name == trade.EndStation.Name)
                {
                    manifest.AddTrade(trade);
                    return true;
                }

            return false;
        }

        private static void CalculateOptimalRoutes(GameData gameData)
        {
            gameData.OptimalRoutes.Clear();

            foreach (Manifest manifest in gameData.OptimalManifests)
            {
                Route start = new Route();
                start.Manifests.Add(new Manifest(manifest));

                List<Manifest> candidates = new List<Manifest>();
                List<Manifest> used = new List<Manifest>();
                used.Add(new Manifest(manifest));

                foreach (Manifest candidate in gameData.OptimalManifests)
                    AddManifestToLists(candidate, candidates, used);

                bool routeCalculationFinished = false;

                Route baseRoute = new Route(start);

                while (routeCalculationFinished == false)
                {
                    Manifest lastBaseManifest = baseRoute.Manifests[baseRoute.Manifests.Count - 1];

                    //Find a return route.
                    bool foundReturnRoute = false;
                    int returnIndex = -1;

                    for (int x = 0; x < candidates.Count; x++)
                    {
                        Manifest candidate = new Manifest(candidates[x]);

                        if (candidate.Trades[0].EndSystem.Name == start.Manifests[0].Trades[0].StartSystem.Name &&
                            candidate.Trades[0].EndStation.Name == start.Manifests[0].Trades[0].StartStation.Name &&
                            candidate.Trades[0].StartSystem.Name == lastBaseManifest.Trades[0].EndSystem.Name &&
                            candidate.Trades[0].StartStation.Name == lastBaseManifest.Trades[0].EndStation.Name)
                        {
                            foundReturnRoute = true;
                            returnIndex = x;
                            break;
                        }
                    }

                    if (foundReturnRoute)
                    {
                        Manifest returnManifest = new Manifest(candidates[returnIndex]);
                        candidates.RemoveAt(returnIndex);
                        used.Add(returnManifest);

                        Route returnRoute = new Route(baseRoute);
                        returnRoute.Manifests.Add(returnManifest);

                        gameData.OptimalRoutes.Add(new Route(returnRoute));
                    }

                    //Find a new route.
                    bool foundNewRoute = false;
                    int newIndex = -1;
                    decimal newProfit = 0;

                    for (int x = 0; x < candidates.Count; x++)
                    {
                        Manifest candidate = new Manifest(candidates[x]);

                        if (candidate.Trades[0].StartSystem.Name == lastBaseManifest.Trades[0].EndSystem.Name &&
                            candidate.Trades[0].StartStation.Name == lastBaseManifest.Trades[0].EndStation.Name &&
                            newProfit < candidate.Profit)
                        {
                            foundNewRoute = true;
                            newIndex = x;
                            newProfit = candidate.Profit;
                        }
                    }

                    if (foundNewRoute)
                    {
                        Manifest newManifest = new Manifest(candidates[newIndex]);
                        candidates.RemoveAt(newIndex);
                        used.Add(newManifest);

                        baseRoute.Manifests.Add(newManifest);
                    }

                    routeCalculationFinished = (foundReturnRoute == false && foundNewRoute == false);
                }
            }

            //Check for duplicates and remove them.
            for (int x = 0; x < gameData.OptimalRoutes.Count; x++)
                for (int y = x + 1; y < gameData.OptimalRoutes.Count; y++)
                    if (gameData.OptimalRoutes[x].Equals(gameData.OptimalRoutes[y]))
                    {
                        gameData.OptimalRoutes.RemoveAt(y);
                        y--;
                    }
        }
        private static void AddManifestToLists(Manifest candidate, List<Manifest> candidates, List<Manifest> used)
        {
            bool isUsed = false;

            for (int x = 0; x < used.Count; x++)
                if (used[x].Equals(candidate))
                    isUsed = true;

            if (isUsed)
                used.Add(candidate);
            else
                candidates.Add(candidate);
        }
    }
}