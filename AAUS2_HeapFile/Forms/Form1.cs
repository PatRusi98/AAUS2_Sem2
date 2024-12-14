using AAUS2_HeapFile;
using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.Forms;
using AAUS2_SemPraca.Forms;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_SemPraca
{
    public partial class Form1 : Form
    {
        private readonly SemProject _project;

        public Form1()
        {
            InitializeComponent();
            _project = SemProject.Instance;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            _project.Dispose();
            Application.Exit();
        }

        private void FindAllVehicles_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();

            var dataSource = _project.GetAllVehicles();

            foreach (var vehicle in dataSource)
            {
                if (vehicle != null)
                {
                    int rowIndex = DataGrid.Rows.Add(vehicle.Name, vehicle.Surname, vehicle.ID, vehicle.LicencePlate, "Details");
                    DataGrid.Rows[rowIndex].Tag = vehicle;
                    DataGrid.Rows[rowIndex].Cells["Details"].Value = "Action";
                }
            }
        }

        private void RandomOperations_Click(object sender, EventArgs e)
        {
            using (var testerForm = new TesterForm())
            {
                if (testerForm.ShowDialog() == DialogResult.OK)
                {
                    var numberOfOperations = testerForm.NumberOfOperations;
                    var insertProb = testerForm.InsertProbability;
                    var searchProb = testerForm.SearchProbability;

                    _project.Test(numberOfOperations, insertProb, searchProb);
                }
            }
        }

        private void InsertVehicle_Click(object sender, EventArgs e)
        {
            using (var insertForm = new InsertForm())
            {
                if (insertForm.ShowDialog() == DialogResult.OK)
                {
                    var name = insertForm.VehName;
                    var surname = insertForm.Surname;
                    var licencePlate = insertForm.LicencePlate;
                    var date = insertForm.ServDate;
                    var price = insertForm.Price;
                    var description = insertForm.Description;

                    _project.InsertVehicle(name, surname, licencePlate, date, price, description);
                }
            }
        }

        private void SearchVehicle_Click(object sender, EventArgs e)
        {
            DataGrid.Rows.Clear();
            using (var searchForm = new SearchForm())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    var searchBy = searchForm.FindBy;
                    var id = searchForm.ID;
                    var licencePlate = searchForm.LicencePlate;

                    object prop = searchBy == HashProperty.ID ? id : licencePlate;

                    var dataSource = _project.SearchVehicle(searchBy, prop);
                    int rowIndex = DataGrid.Rows.Add(dataSource.Name, dataSource.Surname, dataSource.ID, dataSource.LicencePlate, dataSource);
                    DataGrid.Rows[rowIndex].Tag = dataSource;
                    DataGrid.Rows[rowIndex].Cells["Details"].Value = "Action";
                }
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataGrid.Columns["Details"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = DataGrid.Rows[e.RowIndex];
                Vehicle vehicle = selectedRow.Tag as Vehicle;

                using (var detailsForm = new DetailsForm(selectedRow, vehicle))
                {
                    if (detailsForm.ShowDialog() == DialogResult.OK)
                    {
                        var name = detailsForm.VehName;
                        var surname = detailsForm.Surname;
                        var id = detailsForm.ID;
                        var licencePlate = detailsForm.LicencePlate;

                        selectedRow.Cells["NameColumn"].Value = name;
                        selectedRow.Cells["SurnameColumn"].Value = surname;
                        selectedRow.Cells["IDColumn"].Value = id;
                        selectedRow.Cells["LicencePlateColumn"].Value = licencePlate;

                        _project.EditVehicle(vehicle, name, surname);
                    }
                }
            }
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var generatorForm = new GeneratorForm())
            {
                if (generatorForm.ShowDialog() == DialogResult.OK)
                {
                    var numberOfVehicles = generatorForm.NumberOfObjects;
                    _project.GenerateRandomVehicles(numberOfVehicles);
                }
            }
        }

        private void iDHashFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var hashForm = new Sequential(_project.SequentialID()))
            {
                if (hashForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private void dataHeapFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var hashForm = new Sequential(_project.SequentialData()))
            {
                if (hashForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private void licencePlatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var hashForm = new Sequential(_project.SequentialLP()))
            {
                if (hashForm.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
    }
}
