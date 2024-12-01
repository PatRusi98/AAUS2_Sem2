namespace AAUS2_SemPraca.Forms
{
    public partial class GeneratorForm : Form
    {
        public int NumberOfObjects { get; private set; }
        public int IntersectionProbability { get; private set; }
        public GeneratorForm()
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

            if (IntersectionInput.Value < IntersectionInput.Minimum || IntersectionInput.Value > IntersectionInput.Maximum)
            {
                MessageBox.Show($"Enter number between {IntersectionInput.Minimum} and {IntersectionInput.Maximum}.", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IntersectionInput.Focus();
                return false;
            }

            return true;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                NumberOfObjects = (int)NumberInput.Value;
                IntersectionProbability = (int)IntersectionInput.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
