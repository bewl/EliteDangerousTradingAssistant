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
    public partial class RouteEditorDialog : Form
    {
        private Route route;
        private DataTable manifestsBindingTable;

        private EditorMode mode;

        public RouteEditorDialog(Route route, EditorMode mode = EditorMode.View)
        {
            InitializeComponent();
            this.Icon = new Icon("Graphics\\EliteDangerousIcon.ico");

            this.route = route;
            this.mode = mode;

            if (mode == EditorMode.View)
                SetUpViewer();
        }

        private void SetUpViewer()
        {
            this.Text = "Route Viewer";

            SetComboBoxViewText(CenterSystemComboBox, route.Manifests[0].Trades[0].StartSystem.Name);
            SetComboBoxViewText(CenterStationComboBox, route.Manifests[0].Trades[0].StartStation.Name);

            TripsTextBox.Enabled = false;
            TripsTextBox.Text = route.Trips.ToString();
            ProfitTextBox.Enabled = false;
            ProfitTextBox.Text = route.Profit.ToString();
            AverageProfitTextBox.Enabled = false;
            AverageProfitTextBox.Text = decimal.Floor(route.AverageProfitPerTrip).ToString();

            SetUpManifestBindingTable();

            OldestDataTextBox.Text = route.OldestDate.ToString();
        }
        private void SetUpManifestBindingTable()
        {
            manifestsBindingTable = new DataTable();

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

            foreach(Manifest manifest in route.Manifests)
            {
                DataRow newRow = manifestsBindingTable.NewRow();

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

            ManifestGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ManifestGrid.DataSource = manifestsBindingTable;
            ManifestGrid.AllowUserToAddRows = false;
            ManifestGrid.AllowUserToDeleteRows = false;

            ManifestGrid.Columns["Index"].Visible = false;

            DataGridViewButtonColumn newColumn = new DataGridViewButtonColumn();
            newColumn.Name = "View";
            newColumn.HeaderText = "ViewManifest";
            newColumn.Text = "View Manifest";
            newColumn.UseColumnTextForButtonValue = true;
            ManifestGrid.Columns.Insert(0, newColumn);
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

        private void ManifestGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ManifestGrid.Columns[e.ColumnIndex].Name != "View")
                return;

            string resultIndex = ManifestGrid.Rows[e.RowIndex].Cells["Index"].Value.ToString();
            int sourceIndex = int.Parse(resultIndex);

            Manifest selectedManifest = route.Manifests[sourceIndex];

            ManifestEditorDialog dialog = new ManifestEditorDialog(selectedManifest);
            dialog.ShowDialog();
        }
    }
}
