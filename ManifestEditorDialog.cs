using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteDangerousTradingAssistant
{
    public partial class ManifestEditorDialog : Form
    {
        private Manifest manifest;
        private DataTable cargoBindingTable;

        private EditorMode mode;

        public ManifestEditorDialog(Manifest manifest, EditorMode mode = EditorMode.View)
        {
            InitializeComponent();
            this.Icon = new Icon("Graphics\\EliteDangerousIcon.ico");

            this.manifest = manifest;
            this.mode = mode;

            if (mode == EditorMode.View)
                SetUpViewer();
        }

        private void SetUpViewer()
        {
            this.Text = "Manifest Viewer";
            
            SetComboBoxViewText(StartSystemComboBox, manifest.Trades[0].StartSystem.Name);
            SetComboBoxViewText(StartStationComboBox, manifest.Trades[0].StartStation.Name);
            SetComboBoxViewText(EndSystemComboBox, manifest.Trades[0].EndSystem.Name);
            SetComboBoxViewText(EndStationComboBox, manifest.Trades[0].EndStation.Name);

            InvestmentTextBox.Text = manifest.Investment.ToString();
            ProfitTextBox.Text = manifest.Profit.ToString();
            ROITextBox.Text = decimal.Round(manifest.ROI, 2, MidpointRounding.AwayFromZero).ToString("p2");

            SetUpCargoBindingTable();

            OldestDataTextBox.Text = manifest.OldestDate.ToString();
        }
        private void SetUpCargoBindingTable()
        {
            cargoBindingTable = new DataTable();

            cargoBindingTable.Columns.Add("UnitsBought");
            cargoBindingTable.Columns.Add("Commodity");
            cargoBindingTable.Columns.Add("BuyPrice");
            cargoBindingTable.Columns.Add("SellPrice");
            cargoBindingTable.Columns.Add("ProfitPerUnit");

            cargoBindingTable.Columns["UnitsBought"].DataType = System.Type.GetType("System.Decimal");
            cargoBindingTable.Columns["BuyPrice"].DataType = System.Type.GetType("System.Decimal");
            cargoBindingTable.Columns["SellPrice"].DataType = System.Type.GetType("System.Decimal");
            cargoBindingTable.Columns["ProfitPerUnit"].DataType = System.Type.GetType("System.Decimal");

            foreach (Trade trade in manifest.Trades)
            {
                DataRow newRow = cargoBindingTable.NewRow();

                newRow["UnitsBought"] = trade.UnitsBought;
                newRow["Commodity"] = trade.Commodity.Name;
                newRow["BuyPrice"] = trade.Commodity.BuyPrice;
                newRow["SellPrice"] = trade.Commodity.SellPrice;
                newRow["ProfitPerUnit"] = trade.ProfitPerUnit;

                cargoBindingTable.Rows.Add(newRow);
            }

            CargoGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargoGrid.DataSource = cargoBindingTable;
            CargoGrid.AllowUserToAddRows = false;
            CargoGrid.AllowUserToDeleteRows = false;
        }

        private void SetComboBoxViewText(ComboBox comboBox, string item)
        {
            comboBox.Enabled = true;
            comboBox.Items.Clear();
            comboBox.Items.Add(item);
            comboBox.SelectedIndex = 0;
            comboBox.Enabled = false;
        }

        private void SetUpEditor()
        {

        }
    }
}
