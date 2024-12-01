using AAUS2_HeapFile;
using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.Helpers;

namespace AAUS2_SemPraca
{
    public partial class DetailsForm : Form
    {
        public int ID { get; private set; }
        public string LicencePlate { get; private set; }
        public string VehName { get; private set; }
        public string Surname { get; private set; }
        private bool EditMode { get; set; }
        private Vehicle SelectedEntity { get; set; }
        private readonly SemProject _project;

        public DetailsForm(DataGridViewRow selectedRow, Vehicle selected)
        {
            InitializeComponent();
            _project = SemProject.Instance;
            
            EditButton.Enabled = false;

            SelectedEntity = selected;
        }

        private bool ValidateInputs()
        {
            

            return true;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                VehName = NameInput.Text;
                Surname = SurnameInput.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
        }

        private void EditCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EditMode = EditCheckBox.Checked;

            if (EditMode)
            {
                NumberInput.Controls[0].Show();
                Latitude1Input.Controls[0].Show();
                Longitude1Input.Controls[0].Show();
                Latitude2Input.Controls[0].Show();
                Longitude2Input.Controls[0].Show();
            }
            else
            {
                NumberInput.Controls[0].Hide();
                Latitude1Input.Controls[0].Hide();
                Longitude1Input.Controls[0].Hide();
                Latitude2Input.Controls[0].Hide();
                Longitude2Input.Controls[0].Hide();
            }

            NumberInput.ReadOnly = !EditMode;
            DescriptionInput.ReadOnly = !EditMode;
            Latitude1Input.ReadOnly = !EditMode;
            Lat1CoordInput.Enabled = EditMode;
            Longitude1Input.ReadOnly = !EditMode;
            Long1CoordInput.Enabled = EditMode;
            Latitude2Input.ReadOnly = !EditMode;
            Lat2CoordInput.Enabled = EditMode;
            Longitude2Input.ReadOnly = !EditMode;
            Long2CoordInput.Enabled = EditMode;
            EditButton.Enabled = EditMode;
        }
    }
}
