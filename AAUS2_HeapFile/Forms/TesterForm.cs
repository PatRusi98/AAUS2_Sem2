namespace AAUS2_SemPraca.Forms
{
    public partial class TesterForm : Form
    {
        public int NumberOfOperations { get; private set; }
        public double InsertProbability { get; private set; }
        public double SearchProbability { get; private set; }

        public TesterForm()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            if (NumberInput.Value < NumberInput.Minimum || NumberInput.Value > NumberInput.Maximum)
            {
                MessageBox.Show($"Enter number between {NumberInput.Minimum} and {NumberInput.Maximum}.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NumberInput.Focus();
                return false;
            }

            if (InsertInput.Value < InsertInput.Minimum || InsertInput.Value > InsertInput.Maximum)
            {
                MessageBox.Show($"Enter number between {InsertInput.Minimum} and {InsertInput.Maximum}.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InsertInput.Focus();
                return false;
            }

            if (SearchInput.Value < SearchInput.Minimum || SearchInput.Value > SearchInput.Maximum)
            {
                MessageBox.Show($"Enter number between {SearchInput.Minimum} and {SearchInput.Maximum}.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SearchInput.Focus();
                return false;
            }

            return true;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                NumberOfOperations = (int)NumberInput.Value;
                InsertProbability = (double)InsertInput.Value;
                SearchProbability = (double)SearchInput.Value;

                Close();
            }
        }
    }
}
