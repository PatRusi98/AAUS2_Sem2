using AAUS2_HeapFile.Entities;

namespace AAUS2_HeapFile.Tester
{
    public class Generator
    {
        private Random _random = new();

        public Generator() { }

        public List<Person> GenerateRecords(int count)
        {
            if (count < 1)
                return new();

            List<Person> records = new();

            for (int i = 0; i < count; i++)
            {
                records.Add(new Person
                {
                    Name = Name(),
                    Surname = Surname(),
                    ID = _random.Next(1, 1000),
                    LicencePlate = LicencePlate().ToString()
                    //RecordsList = Records(_random.Next(1, 5))
                });
            }

            return records;
        }

        private string Name()
        {
            string[] names = { "John", "Jane", "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Heidi", "Isabella",
                "Jack", "Kate", "Liam", "Mia", "Noah", "Olivia", "Peter", "Quinn", "Rose" };
            return names[_random.Next(names.Length)];
        }

        private string Surname()
        {
            string[] surnames = { "Doe", "Smith", "Johnson", "Brown", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson",
                "Harris", "Clark", "Lewis", "Young", "Walker", "Hall", "Allen", "King", "Baker", "Wright" };
            return surnames[_random.Next(surnames.Length)];
        }

        private char[] LicencePlate()
        {
            char[] licencePlate = new char[10];
            for (int i = 0; i < licencePlate.Length; i++)
            {
                licencePlate[i] = (char)_random.Next(65, 90);
            }
            return licencePlate;
        }

        private List<ServiceRecord> Records(int count)
        {
            List<ServiceRecord> records = new();

            for (int i = 0; i < count; i++)
            {
                records.Add(new ServiceRecord
                {
                    Date = Date(),
                    Price = Price(),
                    //Description = Description()
                });
            }
            return records;
        }

        private char[] Description()
        {
            char[] description = new char[20];
            for (int i = 0; i < description.Length; i++)
            {
                description[i] = (char)_random.Next(65, 90);
            }
            return description;
        }

        private DateTime Date()
        {
            DateTime start = new(2010, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_random.Next(range));
        }

        private double Price()
        {
            return Math.Round(_random.NextDouble() * 1000, 2);
        }
    }
}
