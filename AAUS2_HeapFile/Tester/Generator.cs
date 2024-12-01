using AAUS2_HeapFile.Entities;

namespace AAUS2_HeapFile.Tester
{
    public class Generator
    {
        private static Generator? _instance = null;
        public Random Random { get; set; }
        private int _id = 0;
        private List<string> UsedLPs { get; set; } = new();

        private Generator() 
        {

        }

        public static Generator Instance
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

        public List<Vehicle> GenerateRecords(int count)
        {
            if (count < 1)
                return new();

            List<Vehicle> records = new();

            for (int i = 0; i < count; i++)
            {
                records.Add(new Vehicle
                {
                    Name = Name(),
                    Surname = Surname(),
                    LicencePlate = LicencePlate().ToString(),
                    Records = Records(Random.Next(1, 5))
                });
            }

            return records;
        }

        private string Name()
        {
            string[] names = { "John", "Jane", "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Heidi", "Isabella",
                "Jack", "Kate", "Liam", "Mia", "Noah", "Olivia", "Peter", "Quinn", "Rose" };
            return names[Random.Next(names.Length)];
        }

        private string Surname()
        {
            string[] surnames = { "Doe", "Smith", "Johnson", "Brown", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson",
                "Harris", "Clark", "Lewis", "Young", "Walker", "Hall", "Allen", "King", "Baker", "Wright" };
            return surnames[Random.Next(surnames.Length)];
        }

        private string LicencePlate()
        {
            string licencePlate = "";

            int characters = Random.Next(5, 11);

            for (int j = 0; j < characters; j++)
            {
                var number = Random.NextDouble();

                if (number > 0.5)
                {
                    licencePlate += Random.Next(0, 10).ToString();
                }
                else
                {
                    char randomChar = (char)Random.Next(65, 91);
                    licencePlate += randomChar;
                }
            }

            if (UsedLPs.Contains(licencePlate))
            {
                return LicencePlate();
            }
            else
            {
                UsedLPs.Add(licencePlate);
                return licencePlate;
            }
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
                    Description = Description()
                });
            }
            return records;
        }

        private string Description()
        {
            int wordCount = Random.Next(1, 11);
            string description = "";

            for (int i = 0; i < wordCount; i++)
            {
                int wordLength = Random.Next(1, 21);
                string word = "";

                for (int j = 0; j < wordLength; j++)
                {
                    char randomChar = (char)Random.Next(65, 91);
                    word += randomChar;
                }

                description += word + " ";
            }

            return description.Trim();
        }

        private DateTime Date()
        {
            DateTime start = new(2010, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Random.Next(range));
        }

        private double Price()
        {
            return Math.Round(Random.NextDouble() * 1000, 2);
        }
    }
}
