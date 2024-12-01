using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.File;
using AAUS2_HeapFile.Tester;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Helpers
{
    public class Handler
    {
        private static Handler? _instance;
        private HeapFile<Vehicle> Data;
        private HashFile<VehicleIDToHashFile> IDAddresses;
        private HashFile<LicencePlateToHashFile> LPAddresses;
        private Random _random = new();
        private Generator _generator = Generator.Instance;

        private Handler()
        {
            Data = new("data.dat", 5000);
            IDAddresses = new("id.dat", 5000);
            LPAddresses = new("lp.dat", 5000);
        }

        public static Handler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new();
                }

                return _instance;
            }
        }

        public void InsertVehicle(Vehicle veh, ServiceRecord sr = null)
        {
            var address = Data.Insert(veh);
            var id = new VehicleIDToHashFile() { ID = veh.ID, Address = address };
            var lp = new LicencePlateToHashFile() { LicencePlate = veh.LicencePlate, Address = address };
        }

        public Vehicle SearchVehicle(HashProperty searchBy, object value)
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle veh, VehicleParams par)
        {
            
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> list = new();

            throw new NotImplementedException();
        }

        public void Test(int numberOfIterationsm, double insertProb, double searchProb)
        {
            //TODO
        }

        public void Dispose()
        {
            Data.Dispose();
            IDAddresses.Dispose();
            LPAddresses.Dispose();
        }

        public void EditServiceRecord(ServiceRecord serviceRecordToEdit, ServiceRecordParams par)
        {
            throw new NotImplementedException();
        }

        internal void InsertServiceRecord(Vehicle veh, ServiceRecord sr)
        {
            throw new NotImplementedException();
        }
    }
}
