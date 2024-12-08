using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AAUS2_SemPraca
{
    public partial class InsertSRForm : Form
    {
        public DateTime ServDate { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public InsertSRForm()
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
            ServDate = dateTimeInput.Value;
            Price = (double)priceInput.Value;
            Description = descriptionInput.Text;

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
