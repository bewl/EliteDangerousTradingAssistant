using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EliteDangerousTradingAssistant
{
    public partial class Main : Form
    {
        private GameData gameData;

        private DataTable bindingTable;

        public Main()
        {
            InitializeComponent();
            this.Icon = new Icon("Graphics\\EliteDangerousIcon.ico");

            gameData = new GameData();

            SystemComboBox.Items.Clear();
            StationComboBox.Items.Clear();
        }

        private void AddSystemButton_Click(object sender, System.EventArgs e)
        {
            AddSystemDialog dialog = new AddSystemDialog();
            dialog.ShowDialog();

            if (dialog.Result == null)
                return;

            StarSystem newSystem = dialog.Result;
            gameData.StarSystems.Add(newSystem);
            SystemComboBox.Items.Add(newSystem.Name);
            SystemComboBox.SelectedIndex = SystemComboBox.Items.Count - 1;
        }
        private void RemoveSystemButton_Click(object sender, System.EventArgs e)
        {
            if (gameData.StarSystems.Count == 0)
                return;

            int selectedIndex = SystemComboBox.SelectedIndex;

            SystemComboBox.Items.RemoveAt(selectedIndex);
            gameData.StarSystems.RemoveAt(selectedIndex);

            if (gameData.StarSystems.Count > 0)
                SystemComboBox.SelectedIndex = Math.Min(selectedIndex, Math.Max(gameData.StarSystems.Count - 1, 0));
            else
            {
                SystemComboBox.Text = string.Empty;
                StationComboBox.Items.Clear();
                StationComboBox.Text = string.Empty;
                BindCommodities();
            }
        }
        private void SystemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SystemComboBox.SelectedIndex < 0)
                return;

            StarSystem selectedSystem = gameData.StarSystems[SystemComboBox.SelectedIndex];

            StationComboBox.Items.Clear();

            foreach (Station station in selectedSystem.Stations)
                StationComboBox.Items.Add(station.Name);

            if (StationComboBox.Items.Count > 0)
                StationComboBox.SelectedIndex = 0;
            else
            {
                StationComboBox.Text = string.Empty;
                BindCommodities();
            }
        }

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            if (SystemComboBox.Items.Count == 0)
                return;

            AddStationDialog dialog = new AddStationDialog(gameData.StarSystems[SystemComboBox.SelectedIndex].Name);
            dialog.ShowDialog();

            if (dialog.Result == null)
                return;

            gameData.StarSystems[SystemComboBox.SelectedIndex].Stations.Add(dialog.Result);
            StationComboBox.Items.Add(dialog.Result.Name);

            StationComboBox.SelectedIndex = StationComboBox.Items.Count - 1;
        }
        private void RemoveStationButton_Click(object sender, EventArgs e)
        {
            if (gameData.StarSystems.Count == 0 || gameData.StarSystems[SystemComboBox.SelectedIndex].Stations.Count == 0)
                return;

            int selectedStationIndex = StationComboBox.SelectedIndex;
            StarSystem selectedSystem = gameData.StarSystems[SystemComboBox.SelectedIndex];

            StationComboBox.Items.RemoveAt(selectedStationIndex);
            selectedSystem.Stations.RemoveAt(selectedStationIndex);

            if (selectedSystem.Stations.Count > 0)
                StationComboBox.SelectedIndex = Math.Min(selectedStationIndex, Math.Max(selectedSystem.Stations.Count - 1, 0));
            else
            {
                StationComboBox.Text = string.Empty;
                BindCommodities();
            }
        }
        private void StationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCommodities();
        }

        private void BindCommodities()
        {
            bindingTable = new DataTable();

            bindingTable.Columns.Add("Index");
            bindingTable.Columns.Add("Commodity");
            bindingTable.Columns.Add("SellPrice");
            bindingTable.Columns.Add("BuyPrice");
            bindingTable.Columns.Add("Supply");
            bindingTable.Columns.Add("LastUpdated");

            bindingTable.Columns["Index"].DataType = System.Type.GetType("System.Decimal");
            bindingTable.Columns["SellPrice"].DataType = System.Type.GetType("System.Decimal");
            bindingTable.Columns["BuyPrice"].DataType = System.Type.GetType("System.Decimal");
            bindingTable.Columns["Supply"].DataType = System.Type.GetType("System.Decimal");
            bindingTable.Columns["Supply"].DataType = System.Type.GetType("System.Decimal");
            bindingTable.Columns["LastUpdated"].DataType = System.Type.GetType("System.DateTime");

            CommoditiesGrid.Columns.Clear();

            if (SystemComboBox.SelectedIndex < 0 || gameData.StarSystems.Count == 0)
                return;

            StarSystem selectedSystem = gameData.StarSystems[SystemComboBox.SelectedIndex];

            if (StationComboBox.SelectedIndex < 0 || selectedSystem.Stations.Count == 0)
                return;

            Station selectedStation = selectedSystem.Stations[StationComboBox.SelectedIndex];

            int index = 0;

            foreach (Commodity commodity in selectedStation.Commodities)
            {
                DataRow newRow = bindingTable.NewRow();

                newRow["Index"] = index;
                newRow["Commodity"] = commodity.Name;
                newRow["BuyPrice"] = commodity.BuyPrice;
                newRow["SellPrice"] = commodity.SellPrice;
                newRow["Supply"] = commodity.Supply;
                newRow["LastUpdated"] = commodity.LastUpdated;

                bindingTable.Rows.Add(newRow);
                index++;
            }

            CommoditiesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CommoditiesGrid.DataSource = bindingTable;

            CommoditiesGrid.Columns["Index"].Visible = false;

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "Delete";
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.UseColumnTextForButtonValue = true;
            CommoditiesGrid.Columns.Insert(0, deleteColumn);

            DataGridViewButtonColumn upColumn = new DataGridViewButtonColumn();
            upColumn.Name = "Up";
            upColumn.HeaderText = "Up";
            upColumn.Text = "▲";
            upColumn.UseColumnTextForButtonValue = true;
            CommoditiesGrid.Columns.Insert(7, upColumn);

            DataGridViewButtonColumn downColumn = new DataGridViewButtonColumn();
            downColumn.Name = "Down";
            downColumn.HeaderText = "Down";
            downColumn.Text = "▼";
            downColumn.UseColumnTextForButtonValue = true;
            CommoditiesGrid.Columns.Insert(8, downColumn);
        }

        private void AddCommodityButton_Click(object sender, EventArgs e)
        {
            if (gameData.StarSystems.Count == 0 || gameData.StarSystems[SystemComboBox.SelectedIndex].Stations.Count == 0)
                return;

            StarSystem selectedSystem = gameData.StarSystems[SystemComboBox.SelectedIndex];
            Station selectedStation = selectedSystem.Stations[StationComboBox.SelectedIndex];

            AddEditCommodityDialog dialog = new AddEditCommodityDialog(selectedSystem.Name, selectedStation.Name, gameData.StarSystems);
            dialog.ShowDialog();

            if (dialog.Result == null)
                return;

            Commodity newCommodity = dialog.Result;
            
            newCommodity.LastUpdated = DateTime.Now;

            selectedStation.Commodities.Add(newCommodity);
            BindCommodities();
        }
        private void CommoditiesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch(CommoditiesGrid.Columns[e.ColumnIndex].Name)
            {
                case "Commodity":
                case "BuyPrice":
                case "SellPrice":
                case "Supply":
                    UpdateSelectedCommodity(CommoditiesGrid.Rows[e.RowIndex]);
                    break;
            }
        }

        private void CalculateAllTradesManifestsAndRoutesButton_Click(object sender, EventArgs e)
        {
            gameData.Capital = CapitalNumericUpDown.Value;
            gameData.CargoSlots = CargoSlotsNumericUpDown.Value;

            if (gameData.Capital <= 0 || gameData.CargoSlots <= 0)
            {
                MessageBox.Show("Please provide your available capital and cargo slots.", "Error", MessageBoxButtons.OK);
                return;
            }

            Adviser.CalculateAll(gameData);

            if (gameData.Trades.Count > 0)
            {
                TradesManifestsRoutesDialog dialog = new TradesManifestsRoutesDialog(gameData);
                dialog.Show();
            }
            else
                MessageBox.Show("No trades found. Make sure more than one system is up to date. Check your spelling on the commodities.", "Error: No trades found.", MessageBoxButtons.OK);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".edassistant";
            saveFileDialog.InitialDirectory = string.Concat(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"\SaveData");
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Elite: Dangerous Assistant (.edassistant)|*.edassistant";
            saveFileDialog.FilterIndex = 0;
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = saveFileDialog.OpenFile();
                XmlSerializer serializer = new XmlSerializer(typeof(GameData));
                serializer.Serialize(fileStream, gameData);
                fileStream.Close();
            }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = ".edassistant";
            openFileDialog.InitialDirectory = string.Concat(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"\SaveData");
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Elite: Dangerous Assistant (.edassistant)|*.edassistant";
            openFileDialog.FilterIndex = 0;

            TryOpenSaveFile_Current(openFileDialog);
        }

        private void TryOpenSaveFile_Current(OpenFileDialog openFileDialog)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = openFileDialog.OpenFile();
                    XmlSerializer serializer = new XmlSerializer(typeof(GameData));
                    gameData = serializer.Deserialize(fileStream) as GameData;

                    if (gameData == null)
                        throw new Exception();

                    SystemComboBox.Items.Clear();
                    StationComboBox.Items.Clear();

                    foreach (StarSystem starSystem in gameData.StarSystems)
                        SystemComboBox.Items.Add(starSystem.Name);

                    SystemComboBox.SelectedIndex = 0;
                }

            }
            catch
            {
                TryOpenSaveFile_0004(openFileDialog);
            }
        }
        private void TryOpenSaveFile_0004(OpenFileDialog openFileDialog)
        {
            try
            {
                Stream fileStream = openFileDialog.OpenFile();
                XmlSerializer serializer = new XmlSerializer(typeof(List<StarSystem>));
                List<StarSystem> starSystems = serializer.Deserialize(fileStream) as List<StarSystem>;

                if (starSystems == null || starSystems.Count == 0)
                    throw new Exception();

                gameData = new GameData();

                SystemComboBox.Items.Clear();
                StationComboBox.Items.Clear();

                foreach (StarSystem starSystem in starSystems)
                {
                    SystemComboBox.Items.Add(starSystem.Name);
                    gameData.StarSystems.Add(starSystem);
                }

                SystemComboBox.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("The save file selected cannot be loaded. There are two possible reasons:\n\n1. It is corrupted\n2. It is from a version earlier than 0.5 and is not compatible.", "Error", MessageBoxButtons.OK);
            }
        }

        private void UpdateSelectedCommodity(DataGridViewRow commodity)
        {
            if (gameData.StarSystems.Count == 0 || SystemComboBox.SelectedIndex < 0)
                return;

            StarSystem selectedSystem = gameData.StarSystems[SystemComboBox.SelectedIndex];

            if (selectedSystem.Stations.Count == 0 || StationComboBox.SelectedIndex < 0)
                return;

            Station selectedStation = selectedSystem.Stations[StationComboBox.SelectedIndex];

            int editedCommodityIndex = -1;
            int.TryParse(commodity.Cells["Index"].Value.ToString(), out editedCommodityIndex);

            if (editedCommodityIndex < 0)
                return;

            Commodity editedCommodity = selectedStation.Commodities[editedCommodityIndex];

            string editedName = (string)commodity.Cells["Commodity"].Value;
            decimal editedBuy = (decimal)commodity.Cells["BuyPrice"].Value;
            decimal editedSell = (decimal)commodity.Cells["SellPrice"].Value;
            decimal editedSupply = (decimal)commodity.Cells["Supply"].Value;

            editedCommodity.Name = editedName;
            editedCommodity.BuyPrice = editedBuy;
            editedCommodity.SellPrice = editedSell;
            editedCommodity.Supply = editedSupply;
            editedCommodity.LastUpdated = DateTime.Now;

            commodity.Cells["LastUpdated"].Value = editedCommodity.LastUpdated;
        }

        private void CommoditiesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CommoditiesGrid.Columns[e.ColumnIndex].Name != "Delete" &&
                CommoditiesGrid.Columns[e.ColumnIndex].Name != "Up" &&
                CommoditiesGrid.Columns[e.ColumnIndex].Name != "Down")
                return;

            int selectedSystemIndex = SystemComboBox.SelectedIndex;
            int selectedStationIndex = StationComboBox.SelectedIndex;
            int selectedCommodityIndex = int.Parse(CommoditiesGrid.Rows[e.RowIndex].Cells["Index"].Value.ToString());

            switch (CommoditiesGrid.Columns[e.ColumnIndex].Name.ToString())
            {
                case "Delete":
                    gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities.RemoveAt(selectedCommodityIndex);
                    break;
                case "Up":
                    if (selectedCommodityIndex > 0)
                    {
                        Commodity temp = gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex - 1];
                        gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex - 1] = gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex];
                        gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex] = temp;
                    }
                    break;
                case "Down":
                    if (selectedCommodityIndex < gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities.Count - 1)
                    {
                        Commodity temp = gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex];
                        gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex] = gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex + 1];
                        gameData.StarSystems[selectedSystemIndex].Stations[selectedStationIndex].Commodities[selectedCommodityIndex + 1] =  temp;
                    }
                    break;
                default:
                    break;
            }

            BindCommodities();
        }
    }
}
