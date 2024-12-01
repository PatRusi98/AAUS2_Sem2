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
        private Random _random = new();

        private SemProject()
        {
            Handler = Handler.Instance;
            Generator = Generator.Instance;
            Generator.Random = _random;
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
            return Handler.SearchVehicle(searchBy, value);
        }

        public void InsertVehicle(string name, string surname, string licencePlate, DateTime date, double price, string description)
        {
            var veh = new Vehicle()
            {
                Name = name,
                Surname = surname,
                LicencePlate = licencePlate
            };
            var sr = new ServiceRecord()
            {
                Date = date,
                Price = price,
                Description = description
            };

            Handler.InsertVehicle(veh, sr);
        }

        public void InsertServiceRecords(Vehicle veh, DateTime date, double price, string description)
        {
            var sr = new ServiceRecord()
            {
                Date = date,
                Price = price,
                Description = description
            };

            Handler.InsertServiceRecord(veh, sr);
        }

        public void EditVehicle(Vehicle vehicleToEdit, VehicleParams par)
        {
            Handler.EditVehicle(vehicleToEdit, par);
        }
        
        public void EditServiceRecord(ServiceRecord serviceRecordToEdit, ServiceRecordParams par)
        {
            Handler.EditServiceRecord(serviceRecordToEdit, par);
        }

        public void GenerateRandomVehicles(int number)
        {
            if (number < 1)
                return;

            for (int i = 0; i < number; i++)
            {
                var vehicleToAdd = Generator.GenerateRecords(1);
                foreach (var record in vehicleToAdd)
                {
                    Handler.InsertVehicle(record);
                }
            }
        }

        public void Test(int number, double insertProb, double searchProb)
        {
            if (number < 1)
                return;

            Handler.Test(number, insertProb, searchProb);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return Handler.GetAllVehicles();
        }

        public void Dispose()
        {
            Handler.Dispose();
        }
    }
}
