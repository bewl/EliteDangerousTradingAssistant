using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EliteDangerousTradingAssistant
{
    public partial class TradesManifestsRoutesDialog : Form
    {
        private GameData gameData;

        private DataTable tradesBindingTable;
        private DataTable tradesViewTable;
        private string tradesRowFilter;

        private DataTable manifestsBindingTable;
        private DataTable manifestsViewTable;
        private string manifestsRowFilter;

        private DataTable routesBindingTable;
        private DataTable routesViewTable;
        private string routesRowFilter;

        public TradesManifestsRoutesDialog(GameData gameData)
        {
            InitializeComponent();
            this.Icon = new Icon("Graphics\\EliteDangerousIcon.ico");

            this.gameData = gameData;

            BindData();
        }

        private void BindData()
        {
            LoadFilters();

            BindTradesData();
            SetTradesView();

            BindManifestsData();
            SetManifestsView();

            BindRoutesData();
            SetRoutesView();
        }

        private void LoadFilters()
        {
            List<string> uniqueCommodities = new List<string>();
            List<string> uniqueStartSystems = new List<string>();
            List<string> uniqueEndSystems = new List<string>();
            List<string> uniqueStartStations = new List<string>();
            List<string> uniqueEndStations = new List<string>();

            foreach (Trade trade in gameData.Trades)
            {
                if (uniqueCommodities.Contains(trade.Commodity.Name) == false)
                    uniqueCommodities.Add(trade.Commodity.Name);

                if (uniqueStartSystems.Contains(trade.StartSystem.Name) == false)
                    uniqueStartSystems.Add(trade.StartSystem.Name);

                if (uniqueEndSystems.Contains(trade.EndSystem.Name) == false)
                    uniqueEndSystems.Add(trade.EndSystem.Name);

                if (uniqueStartStations.Contains(trade.StartStation.Name) == false)
                    uniqueStartStations.Add(trade.StartStation.Name);

                if (uniqueEndStations.Contains(trade.EndStation.Name) == false)
                    uniqueEndStations.Add(trade.EndStation.Name);
            }

            CommodityComboBox.Items.Add("All");
            uniqueCommodities.Sort();
            foreach (string commodity in uniqueCommodities)
                CommodityComboBox.Items.Add(commodity);
            CommodityComboBox.SelectedIndex = 0;

            StartSystemFilterComboBox.Items.Add("All");
            uniqueStartSystems.Sort();
            foreach (string startSystem in uniqueStartSystems)
                StartSystemFilterComboBox.Items.Add(startSystem);
            StartSystemFilterComboBox.SelectedIndex = 0;

            EndSystemFilterComboBox.Items.Add("All");
            uniqueEndSystems.Sort();
            foreach (string endSystem in uniqueEndSystems)
                EndSystemFilterComboBox.Items.Add(endSystem);
            EndSystemFilterComboBox.SelectedIndex = 0;

            StartStationFilterComboBox.Items.Add("All");
            uniqueStartStations.Sort();
            foreach (string station in uniqueStartStations)
                StartStationFilterComboBox.Items.Add(station);
            StartStationFilterComboBox.SelectedIndex = 0;

            EndStationFilterComboBox.Items.Add("All");
            uniqueEndStations.Sort();
            foreach (string station in uniqueEndStations)
                EndStationFilterComboBox.Items.Add(station);
            EndStationFilterComboBox.SelectedIndex = 0;

            LoadFilterOperators(BuyPriceFilterOperatorComboBox);
            LoadFilterOperators(SellPriceFilterOperatorComboBox);
            LoadFilterOperators(InvestmentFilterOperatorComboBox);
            LoadFilterOperators(ProfitFilterOperatorComboBox);
            LoadFilterOperators(ROIFilterOperatorComboBox);
        }
        private void LoadFilterOperators(ComboBox comboBox)
        {
            comboBox.Items.Add("=");
            comboBox.Items.Add(">");
            comboBox.Items.Add(">=");
            comboBox.Items.Add("<");
            comboBox.Items.Add("<=");
            comboBox.Items.Add("<>");
            comboBox.SelectedIndex = 0;
        }

        private void SetView()
        {
            SetTradesView();
            SetManifestsView();
        }

        private void BindTradesData()
        {
            tradesBindingTable = new DataTable();

            tradesBindingTable.Columns.Add("Commodity");
            tradesBindingTable.Columns.Add("StartSystem");
            tradesBindingTable.Columns.Add("StartStation");
            tradesBindingTable.Columns.Add("EndSystem");
            tradesBindingTable.Columns.Add("EndStation");
            tradesBindingTable.Columns.Add("BuyPrice");
            tradesBindingTable.Columns.Add("Supply");
            tradesBindingTable.Columns.Add("SellPrice");
            tradesBindingTable.Columns.Add("Profit");
            tradesBindingTable.Columns.Add("ROI");

            tradesBindingTable.Columns["BuyPrice"].DataType = System.Type.GetType("System.Decimal");
            tradesBindingTable.Columns["Supply"].DataType = System.Type.GetType("System.Decimal");
            tradesBindingTable.Columns["SellPrice"].DataType = System.Type.GetType("System.Decimal");
            tradesBindingTable.Columns["Profit"].DataType = System.Type.GetType("System.Decimal");
            tradesBindingTable.Columns["ROI"].DataType = System.Type.GetType("System.Decimal");

            foreach (Trade trade in gameData.Trades)
            {
                DataRow newRow = tradesBindingTable.NewRow();

                newRow["Commodity"] = trade.Commodity.Name;
                newRow["StartSystem"] = trade.StartSystem.Name;
                newRow["StartStation"] = trade.StartStation.Name;
                newRow["EndSystem"] = trade.EndSystem.Name;
                newRow["EndStation"] = trade.EndStation.Name;
                newRow["BuyPrice"] = trade.Commodity.BuyPrice;
                newRow["Supply"] = trade.Commodity.Supply;
                newRow["SellPrice"] = trade.Commodity.SellPrice;
                newRow["Profit"] = trade.ProfitPerUnit;
                newRow["ROI"] = decimal.Round(trade.ROI, 2, MidpointRounding.AwayFromZero);

                tradesBindingTable.Rows.Add(newRow);
            }
        }
        private void SetTradesView()
        {
            tradesRowFilter = string.Empty;

            try
            {
                if (CommodityComboBox.SelectedItem.ToString() != "All" && CommodityComboBox.SelectedItem != null)
                    AddTradesRowFilter(string.Concat("Commodity = '", CommodityComboBox.SelectedItem.ToString(), "'"));
                if (StartSystemFilterComboBox.SelectedItem.ToString() != "All" && StartSystemFilterComboBox.SelectedItem != null)
                    AddTradesRowFilter(string.Concat("StartSystem = '", StartSystemFilterComboBox.SelectedItem.ToString(), "'"));
                if (EndSystemFilterComboBox.SelectedItem.ToString() != "All" && EndSystemFilterComboBox.SelectedItem != null)
                    AddTradesRowFilter(string.Concat("EndSystem = '", EndSystemFilterComboBox.SelectedItem.ToString(), "'"));
                if (StartStationFilterComboBox.SelectedItem.ToString() != "All" && StartStationFilterComboBox.SelectedItem != null)
                    AddTradesRowFilter(string.Concat("StartStation = '", StartStationFilterComboBox.SelectedItem.ToString(), "'"));
                if (EndStationFilterComboBox.SelectedItem.ToString() != "All" && EndStationFilterComboBox.SelectedItem != null)
                    AddTradesRowFilter(string.Concat("EndStation = '", EndStationFilterComboBox.SelectedItem.ToString(), "'"));

                decimal buyPriceFilter = 0;
                decimal.TryParse(BuyPriceFilterTextBox.Text, out buyPriceFilter);
                if (buyPriceFilter > 0)
                    AddTradesRowFilter(string.Concat("BuyPrice ", BuyPriceFilterOperatorComboBox.SelectedItem.ToString(), " ", buyPriceFilter.ToString()));

                decimal sellPriceFilter = 0;
                decimal.TryParse(SellPriceFilterTextBox.Text, out sellPriceFilter);
                if (sellPriceFilter > 0)
                    AddTradesRowFilter(string.Concat("SellPrice ", SellPriceFilterOperatorComboBox.SelectedItem.ToString(), " ", sellPriceFilter.ToString()));

                decimal profitFilter = 0;
                decimal.TryParse(ProfitFilterTextBox.Text, out profitFilter);
                if (profitFilter > 0)
                    AddTradesRowFilter(string.Concat("Profit ", ProfitFilterOperatorComboBox.SelectedItem.ToString(), " ", profitFilter.ToString()));

                decimal ROIFilter = 0;
                decimal.TryParse(ROIFilterTextBox.Text, out ROIFilter);
                if (ROIFilter > 0)
                    AddTradesRowFilter(string.Concat("ROI ", ROIFilterOperatorComboBox.SelectedItem.ToString(), " ", ROIFilter.ToString()));

                tradesBindingTable.DefaultView.RowFilter = tradesRowFilter;
            }
            catch { }

            if (tradesBindingTable == null)
                return;

            TradesGrid.Columns.Clear();

            TradesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tradesViewTable = tradesBindingTable.DefaultView.ToTable();
            TradesGrid.DataSource = tradesViewTable;
        }
        private void AddTradesRowFilter(string filter)
        {
            tradesRowFilter = string.IsNullOrEmpty(tradesRowFilter) ? string.Concat("(", filter, ")") : string.Concat(tradesRowFilter, " AND (", filter, ")");
        }

        private void BindManifestsData()
        {
            manifestsBindingTable = new DataTable();

            manifestsBindingTable.Columns.Add("Source");
            manifestsBindingTable.Columns.Add("Index");
            manifestsBindingTable.Columns.Add("StartSystem");
            manifestsBindingTable.Columns.Add("StartStation");
            manifestsBindingTable.Columns.Add("EndSystem");
            manifestsBindingTable.Columns.Add("EndStation");
            manifestsBindingTable.Columns.Add("Investment");
            manifestsBindingTable.Columns.Add("Profit");
            manifestsBindingTable.Columns.Add("ROI");

            manifestsBindingTable.Columns["Index"].DataType = System.Type.GetType("System.Decimal");
            manifestsBindingTable.Columns["Investment"].DataType = System.Type.GetType("System.Decimal");
            manifestsBindingTable.Columns["Profit"].DataType = System.Type.GetType("System.Decimal");
            manifestsBindingTable.Columns["ROI"].DataType = System.Type.GetType("System.Decimal");

            int index = 0;

            foreach(Manifest manifest in gameData.OptimalManifests)
            {
                DataRow newRow = manifestsBindingTable.NewRow();

                newRow["Source"] = "Optimal";
                newRow["Index"] = index;
                newRow["StartSystem"] = manifest.Trades[0].StartSystem.Name;
                newRow["StartStation"] = manifest.Trades[0].StartStation.Name;
                newRow["EndSystem"] = manifest.Trades[0].EndSystem.Name;
                newRow["EndStation"] = manifest.Trades[0].EndStation.Name;
                newRow["Investment"] = manifest.Investment;
                newRow["Profit"] = manifest.Profit;
                newRow["ROI"] = decimal.Round(manifest.ROI, 2, MidpointRounding.AwayFromZero);

                manifestsBindingTable.Rows.Add(newRow);

                index++;
            }
        }
        private void SetManifestsView()
        {
            manifestsRowFilter = string.Empty;

            try
            {
                if (StartSystemFilterComboBox.SelectedItem.ToString() != "All" && StartSystemFilterComboBox.SelectedItem != null)
                    AddManifestsRowFilter(string.Concat("StartSystem = '", StartSystemFilterComboBox.SelectedItem.ToString(), "'"));
                if (EndSystemFilterComboBox.SelectedItem.ToString() != "All" && EndSystemFilterComboBox.SelectedItem != null)
                    AddManifestsRowFilter(string.Concat("EndSystem = '", EndSystemFilterComboBox.SelectedItem.ToString(), "'"));
                if (StartStationFilterComboBox.SelectedItem.ToString() != "All" && StartStationFilterComboBox.SelectedItem != null)
                    AddManifestsRowFilter(string.Concat("StartStation = '", StartStationFilterComboBox.SelectedItem.ToString(), "'"));
                if (EndStationFilterComboBox.SelectedItem.ToString() != "All" && EndStationFilterComboBox.SelectedItem != null)
                    AddManifestsRowFilter(string.Concat("EndStation = '", EndStationFilterComboBox.SelectedItem.ToString(), "'"));

                decimal investmentFilter = 0;
                decimal.TryParse(InvestmentFilterTextBox.Text, out investmentFilter);
                if (investmentFilter > 0)
                    AddManifestsRowFilter(string.Concat("Investment ", InvestmentFilterOperatorComboBox.SelectedItem.ToString(), " ", investmentFilter.ToString()));

                decimal profitFilter = 0;
                decimal.TryParse(ProfitFilterTextBox.Text, out profitFilter);
                if (profitFilter > 0)
                    AddManifestsRowFilter(string.Concat("Profit ", ProfitFilterOperatorComboBox.SelectedItem.ToString(), " ", profitFilter.ToString()));

                decimal ROIFilter = 0;
                decimal.TryParse(ROIFilterTextBox.Text, out ROIFilter);
                if (ROIFilter > 0)
                    AddManifestsRowFilter(string.Concat("ROI ", ROIFilterOperatorComboBox.SelectedItem.ToString(), " ", ROIFilter.ToString()));

                manifestsBindingTable.DefaultView.RowFilter = manifestsRowFilter;
            }
            catch { }

            if (manifestsBindingTable == null)
                return;

            ManifestsGrid.Columns.Clear();

            ManifestsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            manifestsViewTable = manifestsBindingTable.DefaultView.ToTable();
            ManifestsGrid.DataSource = manifestsViewTable;

            DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
            newColumn.Name = "View";
            newColumn.HeaderText = "View";
            newColumn.Text = "View Manifest";
            newColumn.UseColumnTextForButtonValue = true;
            ManifestsGrid.Columns.Insert(2, newColumn);

            ManifestsGrid.Columns["Source"].Visible = false;
            ManifestsGrid.Columns["Index"].Visible = false;
        }
        private void AddManifestsRowFilter(string filter)
        {
            manifestsRowFilter = string.IsNullOrEmpty(manifestsRowFilter) ? string.Concat("(", filter, ")") : string.Concat(manifestsRowFilter, " AND (", filter, ")");
        }

        private void BindRoutesData()
        {
            routesBindingTable = new DataTable();

            routesBindingTable.Columns.Add("Source");
            routesBindingTable.Columns.Add("Index");
            routesBindingTable.Columns.Add("CenterSystem");
            routesBindingTable.Columns.Add("CenterStation");
            routesBindingTable.Columns.Add("Trips");
            routesBindingTable.Columns.Add("TotalProfit");
            routesBindingTable.Columns.Add("AvgProfitPerTrip");

            routesBindingTable.Columns["Index"].DataType = System.Type.GetType("System.Decimal");
            routesBindingTable.Columns["Trips"].DataType = System.Type.GetType("System.Decimal");
            routesBindingTable.Columns["TotalProfit"].DataType = System.Type.GetType("System.Decimal");
            routesBindingTable.Columns["AvgProfitPerTrip"].DataType = System.Type.GetType("System.Decimal");

            int index = 0;

            foreach(Route route in gameData.OptimalRoutes)
            {
                DataRow newRow = routesBindingTable.NewRow();

                newRow["Source"] = "Optimal";
                newRow["Index"] = index;
                newRow["CenterSystem"] = route.Manifests[0].Trades[0].StartSystem.Name;
                newRow["CenterStation"] = route.Manifests[0].Trades[0].StartStation.Name;
                newRow["Trips"] = route.Trips;
                newRow["TotalProfit"] = route.Profit;
                newRow["AvgProfitPerTrip"] = route.AverageProfitPerTrip;

                routesBindingTable.Rows.Add(newRow);

                index++;
            }
        }
        private void SetRoutesView()
        {
            routesRowFilter = string.Empty;

            try
            {
                //Filters
            }
            catch { }

            if (routesBindingTable == null)
                return;

            RoutesGridView.Columns.Clear();

            RoutesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            routesViewTable = routesBindingTable.DefaultView.ToTable();
            RoutesGridView.DataSource = routesViewTable;

            DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
            newColumn.Name = "View";
            newColumn.HeaderText = "View";
            newColumn.Text = "View Route";
            newColumn.UseColumnTextForButtonValue = true;
            RoutesGridView.Columns.Insert(2, newColumn);

            RoutesGridView.Columns["Source"].Visible = false;
            RoutesGridView.Columns["Index"].Visible = false;
        }
        private void AddRoutesRowFilter(string filter)
        {
            routesRowFilter = string.IsNullOrEmpty(routesRowFilter) ? string.Concat("(", filter, ")") : string.Concat(routesRowFilter, " AND (", filter, ")");
        }

        private void CommodityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void StartSystemFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void EndSystemFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void StartStationFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void EndStationFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void BuyPriceFilterOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void BuyPriceFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void SellPriceFilterOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void SellPriceFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void InvestmentFilterOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void InvestmentFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void ProfitFilterOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void ProfitFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void ROIFilterOperatorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetView();
        }
        private void ROIFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            SetView();
        }

        private void ManifestsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ManifestsGrid.Columns[e.ColumnIndex].Name != "View")
                return;

            string resultIndex = ManifestsGrid.Rows[e.RowIndex].Cells["Index"].Value.ToString();
            int sourceIndex = int.Parse(resultIndex);

            Manifest selectedManifest = gameData.OptimalManifests[sourceIndex];

            ManifestEditorDialog dialog = new ManifestEditorDialog(selectedManifest);
            dialog.ShowDialog();
        }
        private void RoutesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RoutesGridView.Columns[e.ColumnIndex].Name != "View")
                return;

            string resultIndex = RoutesGridView.Rows[e.RowIndex].Cells["Index"].Value.ToString();
            int sourceIndex = int.Parse(resultIndex);

            Route selectedRoute = gameData.OptimalRoutes[sourceIndex];

            RouteEditorDialog dialog = new RouteEditorDialog(selectedRoute);
            dialog.ShowDialog();
        }
    }
}
