using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.File;
using System.Diagnostics;

namespace AAUS2_HeapFile.Tester
{
    public class HeapFileTester
    {
        private readonly Random _random;
        private readonly Random _seedGen = new();
        private HeapFile<Person> HeapFile { get; set; }
        public Dictionary<Person, long> TestEntities { get; private set; } = new();
        public Generator _generator = new();

        public HeapFileTester(string filePath)
        {
            var seed = _seedGen.Next();
            _random = new Random(seed);
            Debug.WriteLine("Seed: " + seed);

            HeapFile = new HeapFile<Person>(filePath, 200);
        }

        public void TestInsert(int numberOfEntities, bool clearFile = false)
        {
            for (int i = 0; i < numberOfEntities; i++)
            {
                var person = _generator.GenerateRecords(numberOfEntities);

                foreach (var record in person)
                {
                    var address = HeapFile.Insert(record);
                    TestEntities[record] = address;
                }
            }
        }

        public void TestDelete(int numberOfIterations = 1)
        {
            if (TestEntities.Count == 0)
                return;

            for (int i = 0; i < numberOfIterations; i++)
            {
                var entityToDelete = TestEntities.ElementAt(_random.Next(TestEntities.Count));
                HeapFile.Delete(entityToDelete.Value, entityToDelete.Key);
                TestEntities.Remove(entityToDelete.Key);
            }
        }

        public void TestSearch(int numberOfIterations = 1)
        {
            if (TestEntities.Count == 0)
                return;

            for (int i = 0; i < numberOfIterations; i++)
            {
                var entityToSearch = TestEntities.ElementAt(_random.Next(TestEntities.Count));
                var found = HeapFile.Get(entityToSearch.Value, entityToSearch.Key);

                Debug.WriteLine($"Searched: " + entityToSearch.Key.ToString());
                Debug.WriteLine($"Found: " + found.ToString());
            }
        }

        public void CreateTestCase(
            int numberOfIterations,
            int numberOfItemsToStart,
            double insertProb,
            double searchProb,
            double deleteProb)
        {
            TestEntities = new();

            for (int i = 0; i < numberOfItemsToStart; i++)
            {
                TestInsert(1);
            }

            var totalProb = insertProb + searchProb + deleteProb;
            insertProb /= totalProb;
            searchProb /= totalProb;
            deleteProb /= totalProb;

            for (int i = 0; i < numberOfIterations; i++)
            {
                var operation = _random.NextDouble();
                string op;

                if (operation < insertProb)
                {
                    TestInsert(1);
                    op = "Insert";
                }
                else if (operation < insertProb + searchProb)
                {
                    TestSearch(1);
                    op = "Search";
                }
                else
                {
                    TestDelete(1);
                    op = "Delete";
                }
            }

            HeapFile.Dispose();
        }
    }
}
