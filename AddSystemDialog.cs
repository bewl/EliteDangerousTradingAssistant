using System;
using System.Drawing;
using System.Windows.Forms;

namespace EliteDangerousTradingAssistant
{
    public partial class AddSystemDialog : Form
    {
        private StarSystem result;

        public StarSystem Result
        {
            get { return result; }
        }

        public AddSystemDialog()
        {
            InitializeComponent();
            this.Icon = new Icon("Graphics\\EliteDangerousIcon.ico");
            result = null;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SystemTextBox.Text))
            {
                MessageBox.Show("Please provide a name for the system.", "Error: System name needed", MessageBoxButtons.OK);
                return;
            }

            result = new StarSystem();
            result.Name = SystemTextBox.Text;
            this.Close();
        }
    }
}
