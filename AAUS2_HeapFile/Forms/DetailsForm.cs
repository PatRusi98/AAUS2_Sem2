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

            NumberInput.Value = selected.ID;
            NameInput.Text = selected.Name;
            SurnameInput.Text = selected.Surname;
            DescriptionInput.Text = selected.LicencePlate;

            var dataSource = selected.Records;

            foreach (var record in dataSource)
            {
                if (record != null)
                {
                    int rowIndex = DataGridService.Rows.Add(record.Date, record.Price, record.Description);
                }
            }
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
                NameInput.Controls[0].Show();
                SurnameInput.Controls[0].Show();
                DescriptionInput.Controls[0].Show();
            }
            else
            {
                NumberInput.Controls[0].Hide();
                NameInput.Controls[0].Hide();
                SurnameInput.Controls[0].Hide();
                DescriptionInput.Controls[0].Hide();
            }

            NumberInput.ReadOnly = !EditMode;
            DescriptionInput.ReadOnly = !EditMode;
            NameInput.ReadOnly = !EditMode;
            SurnameInput.ReadOnly = !EditMode;
            EditButton.Enabled = EditMode;
        }
    }
}
