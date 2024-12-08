using AAUS2_HeapFile;
using AAUS2_HeapFile.Entities;

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

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                VehName = NameInput.Text;
                Surname = SurnameInput.Text;
                LicencePlate = DescriptionInput.Text;
                ID = (int)NumberInput.Value;

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

            NameInput.ReadOnly = !EditMode;
            SurnameInput.ReadOnly = !EditMode;
            EditButton.Enabled = EditMode;
            addSRButton.Enabled = EditMode;
            editSRButton.Enabled = EditMode;
            button1.Enabled = EditMode;
        }

        private void DataGridService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addSRButton_Click(object sender, EventArgs e)
        {
            using (var insertSRForm = new InsertSRForm())
            {
                if (insertSRForm.ShowDialog() == DialogResult.OK)
                {
                    var date = insertSRForm.ServDate;
                    var price = insertSRForm.Price;
                    var description = insertSRForm.Description;

                    _project.InsertServiceRecords(SelectedEntity, date, price, description);
                }
            }
        }

        private void editSRButton_Click(object sender, EventArgs e)
        {
            using (var insertSRForm = new InsertSRForm())
            {
                if (insertSRForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedRow = DataGridService.SelectedRows[0];
                    var selectedRecord = SelectedEntity.Records.FirstOrDefault(record =>
                        record.Date == (DateTime)selectedRow.Cells[0].Value &&
                        record.Price == (double)selectedRow.Cells[1].Value &&
                        record.Description == (string)selectedRow.Cells[2].Value);

                    if (selectedRecord != null)
                    {
                        var date = insertSRForm.ServDate;
                        var price = insertSRForm.Price;
                        var description = insertSRForm.Description;

                        _project.EditServiceRecord(SelectedEntity, selectedRecord, date, price, description);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedRow = DataGridService.SelectedRows[0];
            var selectedRecord = SelectedEntity.Records.FirstOrDefault(record =>
                record.Date == (DateTime)selectedRow.Cells[0].Value &&
                record.Price == (double)selectedRow.Cells[1].Value &&
                record.Description == (string)selectedRow.Cells[2].Value);

            if (selectedRecord != null)
            {
                _project.DeleteServiceRecord(SelectedEntity, selectedRecord);
            }
        }
    }
}
