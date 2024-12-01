using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.Helpers;
using AAUS2_HeapFile.Tester;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile
{
    public class SemProject
    {
        private static SemProject? _instance;
        private Handler Handler { get; set; }
        private Generator Generator { get; set; }

        private SemProject()
        {
            //Handler = ;
            //Generator = Generator.Instance;
        }

        public static SemProject Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SemProject();
                }

                return _instance;
            }
        }

        public Vehicle SearchVehicle(HashProperty searchBy, object value)
        {
            throw new NotImplementedException();
        }

        public void InsertVehicle(string name, string surname, string licencePlate, DateTime date, double place, string description)
        {
            throw new NotImplementedException();
        }

        public void InsertServiceRecords(DateTime date, double price, string description)
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle vehicleToEdit, VehicleParams par)
        {
            throw new NotImplementedException();
        }
        
        public void EditServiceRecord(ServiceRecord serviceRecordToEdit, ServiceRecordParams par)
        {
            throw new NotImplementedException();
        }

        public void GenerateRandomVehicles(int number)
        {
            if (number < 1)
                return;

            for (int i = 0; i < number; i++)
            {
                var vehicleToAdd = Generator.GenerateRecords(1);

                //TODO
            }
        }

        public void Test(int number, double insertProb, double searchProb)
        {
            if (number < 1);

            // TODO
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException(); 
        }

        public void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                // TODO
            }
        }

        public void LoadFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                // TODO
            }
        }

        public void Dispose()
        {
            Handler.Dispose();
        }
    }
}
