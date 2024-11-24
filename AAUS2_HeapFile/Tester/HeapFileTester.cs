using System.Diagnostics;
using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.File;

namespace AAUS2_HeapFile.Tester
{
    public class HeapFileTester
    {
        private readonly Random _random;
        private readonly Random _seedGen = new();
        private HeapFile<Person> TestFile { get; set; }
        public List<Person> TestEntities { get; private set; } = new();

        public HeapFileTester(string filePath)
        {
            var seed = _seedGen.Next();
            _random = new Random(seed);
            Debug.WriteLine("Seed: " + seed);

            TestFile = new HeapFile<Person>(filePath);
        }

        public void TestInsert(int numberOfEntities, bool clearFile = false)
        {
            if (clearFile)
                ClearFile();

            for (int i = 0; i < numberOfEntities; i++)
            {
                var person = GenerateRandomPerson();
                TestFile.Insert(person);
                TestEntities.Add(person);
            }

            Debug.WriteLine($"Inserted {numberOfEntities} entities.");
        }

        public void TestDelete(int numberOfIterations = 1)
        {
            if (TestEntities.Count == 0)
                return;

            for (int i = 0; i < numberOfIterations; i++)
            {
                var entityToDelete = TestEntities[_random.Next(TestEntities.Count)];
                TestFile.Delete(entityToDelete);
                TestEntities.Remove(entityToDelete);
            }

            Debug.WriteLine($"Deleted {numberOfIterations} entities.");
        }

        public void TestSearch(int numberOfIterations = 1)
        {
            if (TestEntities.Count == 0)
                return;

            for (int i = 0; i < numberOfIterations; i++)
            {
                var entityToSearch = TestEntities[_random.Next(TestEntities.Count)];
                var found = TestFile.Search(entityToSearch);

                if (!found)
                {
                    Debug.WriteLine($"Search failed for entity: {entityToSearch}");
                }
            }

            Debug.WriteLine($"Performed {numberOfIterations} search operations.");
        }

        public void CreateTestCase(
            int numberOfIterations,
            int numberOfItemsToStart,
            double insertProb,
            double searchProb,
            double deleteProb)
        {
            ClearFile();
            TestEntities = new();

            // Initialize file with data
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

                Debug.WriteLine($"Iteration {i + 1}: {op}");
                Debug.WriteLine($"Number of items in file: {TestFile.ItemCount}");
                Debug.WriteLine($"Number of items in List: {TestEntities.Count}");
                Debug.WriteLine("--------------------------------------");

                if (TestEntities.Count != TestFile.ItemCount)
                {
                    throw new InvalidOperationException("Mismatch between file and list entity count.");
                }
            }
        }

        #region Private Helpers

        private void ClearFile()
        {
            TestFile.Dispose();
            TestFile = new HeapFile<Person>(TestFile.FilePath);
            TestEntities.Clear();
        }

        private Person GenerateRandomPerson()
        {
            var name = GenerateRandomString(10);
            var surname = GenerateRandomString(15);
            var id = _random.Next(1, 10000);

            return new Person(id, name, surname);
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        #endregion
    }
}
