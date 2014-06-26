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
    public partial class ChooseExistingCommodityDialog : Form
    {
        private List<StarSystem> systems;
        private string result;
        private List<string> uniqueCommodityNames;

        public string Result
        {
            get { return result; }
        }

        public ChooseExistingCommodityDialog(List<StarSystem> systems)
        {
            InitializeComponent();
            this.Icon = new Icon("Graphics\\EliteDangerousIcon.ico");

            this.systems = systems;
            result = string.Empty;
            uniqueCommodityNames = new List<string>();

            foreach (StarSystem system in systems)
                foreach(Station station in system.Stations)
                    foreach(Commodity commodity in station.Commodities)
                        if (uniqueCommodityNames.Contains(commodity.Name) == false)
                            uniqueCommodityNames.Add(commodity.Name);

            if (uniqueCommodityNames.Count == 0)
            {
                MessageBox.Show("No commodities have been found. Please add some commodities to systems and stations.", "Error: No commodities found.", MessageBoxButtons.OK);
                this.Close();
            }

            CommodityComboBox.Items.Add("Please select one...");

            uniqueCommodityNames.Sort();

            foreach (string uniqueCommodityName in uniqueCommodityNames)
                CommodityComboBox.Items.Add(uniqueCommodityName);

            CommodityComboBox.SelectedIndex = 0;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (CommodityComboBox.SelectedIndex == 0)
                return;

            result = CommodityComboBox.SelectedItem.ToString();

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
