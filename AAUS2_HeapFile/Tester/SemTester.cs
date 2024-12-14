using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.Files;
using System.Diagnostics;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Tester
{
    public class SemTester
    {
        private readonly Random _random;
        private readonly Random _seedGen = new();
        private HeapFile<Vehicle> HeapFile { get; set; }
        private ExtendibleHashing<VehicleIDToHashFile> IDAddresses { get; set; }
        private ExtendibleHashing<LicencePlateToHashFile> LicencePlateAddresses { get; set; }
        private Generator _generator;
        private List<Vehicle> vehicles = new();

        public SemTester()
        {
            var seed = _seedGen.Next();
            _random = new Random(seed);
            //_random = new Random(527168037); // seed co mam na papieri rozkresleny
            //_random = new Random(1141471009); // TU PREPISUJ SEED KED TREBA
            _generator = Generator.Instance;
            _generator.Random = _random;
            //Debug.WriteLine("Seed: " + seed);

            HeapFile = new HeapFile<Vehicle>("data_" + seed + ".dat", 5000);
            IDAddresses = new ExtendibleHashing<VehicleIDToHashFile>("id_" + seed + ".dat", "id_" + seed + "_props.txt", 70);
            LicencePlateAddresses = new ExtendibleHashing<LicencePlateToHashFile>("licencePlate_" + seed + ".dat", "lp_" + seed + "_props.txt", 70);
        }

        public void TestInsert(int numberOfEntities, bool clearFile = false)
        {
            for (int i = 0; i < numberOfEntities; i++)
            {
                //Debug.WriteLine("Iteracia: " + i);
                var person = _generator.GenerateRecords(1);

                foreach (var record in person)
                {
                    var address = HeapFile.Insert(record);
                    var id = new VehicleIDToHashFile() { ID = record.ID, Address = address };
                    var licencePlate = new LicencePlateToHashFile() { LicencePlate = record.LicencePlate, Address = address };
                    IDAddresses.Insert(id);
                    LicencePlateAddresses.Insert(licencePlate);
                    vehicles.Add(record);
                }
            }
        }

        public void TestSearch(int numberOfIterations = 1)
        {
            for (int i = 0; i < numberOfIterations; i++)
            {
                foreach (var vehicle in vehicles)
                {
                    var idSearchResult = IDAddresses.Search(new VehicleIDToHashFile { ID = vehicle.ID });
                    var licencePlateSearchResult = LicencePlateAddresses.Search(new LicencePlateToHashFile { LicencePlate = vehicle.LicencePlate });
                    if (licencePlateSearchResult != null)
                    {
                        var veh = HeapFile.Get(licencePlateSearchResult.Address, new Vehicle());
                    }
                    else
                    {
                        //Debug.WriteLine($"tu brejkac");
                    }
                }
            }
        }

        public void CreateTestCase(
            int numberOfIterations,
            int numberOfItemsToStart,
            double insertProb,
            double searchProb)
        {

            for (int i = 0; i < numberOfItemsToStart; i++)
            {
                TestInsert(1);
            }

            var totalProb = insertProb + searchProb;
            insertProb /= totalProb;
            searchProb /= totalProb;

            for (int i = 0; i < numberOfIterations; i++)
            {
                var operation = _random.NextDouble();
                string op;

                if (operation < insertProb)
                {
                    TestInsert(1);
                    op = "Insert";
                }
                else
                {
                    TestSearch(1);
                    op = "Search";
                }
            }

            HeapFile.Dispose();
            IDAddresses.Dispose("id_props_test.txt");
            LicencePlateAddresses.Dispose("lp_props_test.txt");
        }
    }
}
