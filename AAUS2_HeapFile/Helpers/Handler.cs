using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.Files;
using AAUS2_HeapFile.Tester;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Helpers
{
    public class Handler
    {
        private static Handler? _instance;
        private HeapFile<Vehicle> Data;
        private ExtendibleHashing<VehicleIDToHashFile> IDAddresses;
        private ExtendibleHashing<LicencePlateToHashFile> LPAddresses;
        private Random _random = new();
        private Generator _generator = Generator.Instance;

        private Handler()
        {
            Data = new("data.dat", 6000);
            IDAddresses = new("id.dat", 6000);
            IDAddresses.LoadPropsFromFile("id_props.txt");
            LPAddresses = new("lp.dat", 6000);
            LPAddresses.LoadPropsFromFile("lp_props.txt");
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
            IDAddresses.Insert(id, HashProperty.ID);
            LPAddresses.Insert(lp, HashProperty.LicencePlate);
        }

        public Vehicle SearchVehicle(HashProperty searchBy, object value)
        {
            Vehicle veh = new();
            switch (searchBy)
            {
                case HashProperty.ID:
                    veh.ID = (int)value;
                    var id = new VehicleIDToHashFile() { ID = (int)value };
                    var address = IDAddresses.Search(id, HashProperty.ID);
                    veh = Data.Get(address.Address, veh);
                    break;
                case HashProperty.LicencePlate:
                    veh.LicencePlate = (string)value;
                    var lp = new LicencePlateToHashFile() { LicencePlate = (string)value };
                    var lpAddress = LPAddresses.Search(lp, HashProperty.LicencePlate);
                    veh = Data.Get(lpAddress.Address, veh);
                    break;
            }

            return veh;
        }

        public void EditVehicle(Vehicle veh, VehicleParams par)
        {
            if (par.Name != null)
                veh.Name = par.Name;

            if (par.Surname != null)
                veh.Surname = par.Surname;

            var id = new VehicleIDToHashFile() { ID = veh.ID };
            var address = IDAddresses.Search(id, HashProperty.ID);

            Data.Update(veh, address.Address);
        }

        public void EditServiceRecord(Vehicle veh, ServiceRecord serviceRecordToEdit, ServiceRecordParams par)
        {
            if (par.Date != null)
                serviceRecordToEdit.Date = par.Date.Value;

            if (par.Price != null)
                serviceRecordToEdit.Price = par.Price.Value;

            if (par.Description != null)
                serviceRecordToEdit.Description = par.Description;

            for (int i = 0; i < veh.Records.Count; i++)
            {
                if (veh.Records[i].Equals(serviceRecordToEdit))
                {
                    veh.Records[i] = serviceRecordToEdit;
                    break;
                }
            }

            var id = new VehicleIDToHashFile() { ID = veh.ID };
            var address = IDAddresses.Search(id, HashProperty.ID);

            Data.Update(veh, address.Address);
        }

        public void InsertServiceRecord(Vehicle veh, ServiceRecord sr)
        {
            veh.Records.Add(sr);

            var id = new VehicleIDToHashFile() { ID = veh.ID };
            var address = IDAddresses.Search(id, HashProperty.ID);

            Data.Update(veh, address.Address);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return Data.GetAllSequential();
        }

        public void Test(int numberOfIterations, double insertProb, double searchProb)
        {
            _generator.Random = _random;
            var tester = new SemTester();
            tester.CreateTestCase(numberOfIterations,0 , insertProb, searchProb);
        }

        public void Dispose()
        {
            Data.Dispose();
            IDAddresses.Dispose("id_props.txt");
            LPAddresses.Dispose("lp_props.txt");
        }
    }
}
