using System.Text;
using AAUS2_HeapFile.Interfaces;

namespace AAUS2_HeapFile.Entities
{
    public class Person : IRecord<Person>
    {
        private const int _nameLength = 15;
        private const int _surnameLength = 20;
        private const int _licencePlateLength = 10;
        private const int _recordsCount = 5;
        private string _name;
        private string _surname;
        private string _licencePlate;
        private int _recordSize;

        public string Name
        {
            get => _name.PadRight(_nameLength, '\0');
            set => _name = value.Length > _nameLength
                ? value.Substring(0, _nameLength)
                : value.PadRight(_nameLength, '\0');
        }
        public string Surname
        {
            get => _surname.PadRight(_surnameLength, '\0');
            set => _surname = value.Length > _surnameLength
                ? value.Substring(0, _surnameLength)
                : value.PadRight(_surnameLength, '\0');
        }
        public string LicencePlate
        {
            get => _licencePlate.PadRight(_licencePlateLength, '\0');
            set => _licencePlate = value.Length > _licencePlateLength
                ? value.Substring(0, _licencePlateLength)
                : value.PadRight(_licencePlateLength, '\0');
        }
        public int ID { get; set; }
        public ServiceRecord[] Records { get; set; } = new ServiceRecord[5];
        public List<ServiceRecord> RecordsList { get; set; } = new();

        public Person()
        {
            _name = string.Empty.PadRight(_nameLength, '\0');
            _surname = string.Empty.PadRight(_surnameLength, '\0');
            _licencePlate = string.Empty.PadRight(_licencePlateLength, '\0');
        }

        public Person CreateCopy()
        {
            var person = new Person
            {
                Name = Name,
                Surname = Surname,
                ID = ID,
                LicencePlate = LicencePlate
            };

            for (int i = 0; i < Records.Length; i++)
            {
                person.Records[i] = Records[i].CreateCopy();
            }

            return person;
        }

        public bool Equals(Person? data)
        {
            if (data == null) return false;

            return ID == data.ID;
        }


        public void FromByteArray(byte[] byteArray)
        {
            var index = 0;

            Name = Encoding.UTF8.GetString(byteArray, index, _nameLength).TrimEnd();
            index += _nameLength;

            Surname = Encoding.UTF8.GetString(byteArray, index, _surnameLength).TrimEnd();
            index += _surnameLength;

            ID = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);

            LicencePlate = Encoding.UTF8.GetString(byteArray, index, _licencePlateLength).TrimEnd();
            index += _licencePlateLength;

            //for (int i = 0; i < Records.Length; i++)
            //{
            //    var record = new ServiceRecord();
            //    var recordSize = record.GetSize();
            //    var recordBytes = byteArray.Skip(index).Take(recordSize).ToArray();
            //    record.FromByteArray(recordBytes);
            //    Records[i] = record;
            //    index += recordSize;
            //}

            //RecordsList = Records.ToList();
        }

        public byte[] ToByteArray()
        {
            var nameBytes = Encoding.UTF8.GetBytes(Name);
            var surnameBytes = Encoding.UTF8.GetBytes(Surname);
            var idBytes = BitConverter.GetBytes(ID);
            var licencePlateBytes = Encoding.UTF8.GetBytes(LicencePlate);

            var totalLength = nameBytes.Length + surnameBytes.Length + idBytes.Length + licencePlateBytes.Length;
            var byteArr = new byte[totalLength];

            int offset = 0;

            Buffer.BlockCopy(nameBytes, 0, byteArr, offset, nameBytes.Length);
            offset += nameBytes.Length;

            Buffer.BlockCopy(surnameBytes, 0, byteArr, offset, surnameBytes.Length);
            offset += surnameBytes.Length;

            Buffer.BlockCopy(idBytes, 0, byteArr, offset, idBytes.Length);
            offset += idBytes.Length;

            Buffer.BlockCopy(licencePlateBytes, 0, byteArr, offset, licencePlateBytes.Length);

            return byteArr;
        }

        public int GetSize()
        {
            return _nameLength + _surnameLength + sizeof(int) + _licencePlateLength; //+ (_recordsCount * _recordSize)
        }
    }
}
