using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_SemPraca.Forms
{
    public partial class SearchForm : Form
    {
        public HashProperty FindBy { get; private set; }
        public int? ID { get; private set; }
        public string? LicencePlate { get; private set; }

        public SearchForm()
        {
            InitializeComponent();

            SearchByInput.Items.AddRange([HashProperty.ID, HashProperty.LicencePlate]);
            SearchByInput.SelectedIndex = 0;
        }

        private bool ValidateInputs()
        {
            if (SearchByInput.SelectedItem == null)
            {
                MessageBox.Show("Prosim, vyberte kluc.", "Neplatny vstup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SearchByInput.Focus();
                return false;
            }

            return true;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                FindBy = (HashProperty)SearchByInput.SelectedItem;
                ID = (int)SearchIDInput.Value;
                LicencePlate = SearchLicencePlate.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
