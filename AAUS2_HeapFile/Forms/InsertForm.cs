using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AAUS2_SemPraca
{
    public partial class InsertForm : Form
    {
        public string VehName { get; private set; }
        public string Surname { get; private set; }
        public string LicencePlate { get; private set; }
        public DateTime ServDate { get; private set; }
        public double Price { get; private set; }
        public string Description { get; private set; }

        public InsertForm()
        {
            InitializeComponent();
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void latitude1_Click(object sender, EventArgs e)
        {

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            VehName = nameInput.Text;
            Surname = surnameInput.Text;
            LicencePlate = licencePlateInput.Text;
            ServDate = dateTimeInput.Value;
            Price = (double)priceInput.Value;
            Description = surnameInput.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void NumberInput_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
