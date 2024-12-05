using System.Collections;
using System.Text;
using AAUS2_HeapFile.Interfaces;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Entities
{
    public class Vehicle : IHashFile<Vehicle>
    {
        private static int LastId = 0;
        private const int _nameLength = 15;
        private const int _surnameLength = 20;
        private const int _licencePlateLength = 10;
        private const int _recordsCount = 5;
        private string _name;
        private string _surname;
        private string _licencePlate;
        private int _recordSize;

        public int NameValidLength;
        public string Name
        {
            get
            {
                return _name.Substring(0, NameValidLength);
            }

            set
            {
                if (value.Length > _nameLength)
                {
                    _name = value.Substring(0, _nameLength);
                    NameValidLength = _nameLength;
                }
                else
                {
                    _name = value.PadRight(_nameLength, '\0');
                    NameValidLength = value.Length;
                }
            }
        }
        public int SurnameValidLength;
        public string Surname
        {
            get
            {
                return _surname.Substring(0, SurnameValidLength);
            }

            set
            {
                if (value.Length > _surnameLength)
                {
                    _surname = value.Substring(0, _surnameLength);
                    SurnameValidLength = _surnameLength;
                }
                else
                {
                    _surname = value.PadRight(_surnameLength, '\0');
                    SurnameValidLength = value.Length;
                }
            }
        }
        public int LicencePlateValidLength;
        public string LicencePlate
        {
            get
            {
                return _licencePlate.Substring(0, LicencePlateValidLength);
            }

            set
            {
                if (value.Length > _licencePlateLength)
                {
                    _licencePlate = value.Substring(0, _licencePlateLength);
                    LicencePlateValidLength = _licencePlateLength;
                }
                else
                {
                    _licencePlate = value.PadRight(_licencePlateLength, '\0');
                    LicencePlateValidLength = value.Length;
                }
            }
        }
        public int ID { get; set; }
        public List<ServiceRecord> Records { get; set; } = new();

        public Vehicle()
        {
            //ID = GenerateId();
            _name = string.Empty.PadRight(_nameLength, '\0');
            _surname = string.Empty.PadRight(_surnameLength, '\0');
            _licencePlate = string.Empty.PadRight(_licencePlateLength, '\0');
        }

        public Vehicle CreateCopy()
        {
            var vehicle = new Vehicle
            {
                Name = Name,
                Surname = Surname,
                ID = ID,
                LicencePlate = LicencePlate
            };

            foreach (var item in Records)
            {
                vehicle.Records.Add(item.CreateCopy());
            }

            return vehicle;
        }

        public bool Equals(Vehicle? data)
        {
            if (data == null) return false;

            if (data.ID == 0)
            {
                return LicencePlate == data.LicencePlate;
            }

            return ID == data.ID;
        }


        public void FromByteArray(byte[] byteArray)
        {
            var index = 0;

            NameValidLength = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);
            _name = Encoding.UTF8.GetString(byteArray, index, _nameLength);
            index += _nameLength;
            SurnameValidLength = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);
            _surname = Encoding.UTF8.GetString(byteArray, index, _surnameLength);
            index += _surnameLength;
            ID = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);
            LicencePlateValidLength = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);
            _licencePlate = Encoding.UTF8.GetString(byteArray, index, _licencePlateLength);
            index += _licencePlateLength;
            var recCount = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);

            for (int i = 0; i < recCount; i++)
            {
                var record = new ServiceRecord();
                var recordSize = record.GetSize();
                var recordBytes = byteArray[index..(index + recordSize)];
                record.FromByteArray(recordBytes);
                Records.Add(record);
                index += recordSize;
            }
        }

        public byte[] ToByteArray()
        {
            var nameValidBytes = BitConverter.GetBytes(NameValidLength);
            var nameBytes = Encoding.UTF8.GetBytes(_name);
            var surnameValidBytes = BitConverter.GetBytes(SurnameValidLength);
            var surnameBytes = Encoding.UTF8.GetBytes(_surname);
            var idBytes = BitConverter.GetBytes(ID);
            var licencePlateValidBytes = BitConverter.GetBytes(LicencePlateValidLength);
            var licencePlateBytes = Encoding.UTF8.GetBytes(_licencePlate);
            var recCountBytes = BitConverter.GetBytes(Records.Count);
            var recLength = Activator.CreateInstance<ServiceRecord>().GetSize() * _recordsCount;
            var recBytes = new byte[recLength];
            var index = 0;

            foreach (var record in Records)
            {
                var recordBytes = record.ToByteArray();
                Buffer.BlockCopy(recordBytes, 0, recBytes, index, recordBytes.Length);
                index += recordBytes.Length;
            }

            for (int i = Records.Count; i < _recordsCount; i++)
            {
                var recordBytes = new byte[Activator.CreateInstance<ServiceRecord>().GetSize()];
                Buffer.BlockCopy(recordBytes, 0, recBytes, index, recordBytes.Length);
                index += recordBytes.Length;
            }

            var totalLength = nameValidBytes.Length + nameBytes.Length + surnameValidBytes.Length + surnameBytes.Length + idBytes.Length + licencePlateValidBytes.Length + licencePlateBytes.Length + recCountBytes.Length + recBytes.Length;
            var byteArr = new byte[totalLength];

            int offset = 0;

            Buffer.BlockCopy(nameValidBytes, 0, byteArr, offset, nameValidBytes.Length);
            offset += nameValidBytes.Length;

            Buffer.BlockCopy(nameBytes, 0, byteArr, offset, nameBytes.Length);
            offset += nameBytes.Length;

            Buffer.BlockCopy(surnameValidBytes, 0, byteArr, offset, surnameValidBytes.Length);
            offset += surnameValidBytes.Length;

            Buffer.BlockCopy(surnameBytes, 0, byteArr, offset, surnameBytes.Length);
            offset += surnameBytes.Length;

            Buffer.BlockCopy(idBytes, 0, byteArr, offset, idBytes.Length);
            offset += idBytes.Length;

            Buffer.BlockCopy(licencePlateValidBytes, 0, byteArr, offset, licencePlateValidBytes.Length);
            offset += licencePlateValidBytes.Length;

            Buffer.BlockCopy(licencePlateBytes, 0, byteArr, offset, licencePlateBytes.Length);
            offset += licencePlateBytes.Length;

            Buffer.BlockCopy(recCountBytes, 0, byteArr, offset, recCountBytes.Length);
            offset += recCountBytes.Length;

            Buffer.BlockCopy(recBytes, 0, byteArr, offset, recBytes.Length);

            return byteArr;
        }

        public int GetSize()
        {
            return (5 * sizeof(int)) + _nameLength + _surnameLength + _licencePlateLength + (Activator.CreateInstance<ServiceRecord>().GetSize() * _recordsCount);
        }

        public BitArray GetHash(HashProperty filter)
        {
            if (filter == HashProperty.ID)
            {
                return GetIDHash();
            }
            else if (filter == HashProperty.LicencePlate)
            {
                return GetLicencePlateHash();
            }

            throw new Exception("Invalid filter.");
        }

        public string ToString()
        {
            var str = $"ID: {ID}, Name: {Name}, Surname: {Surname}, Licence Plate: {LicencePlate}";
            foreach (var record in Records)
            {
                str += $"\n{record.ToString()}";
            }

            return str;
        }

        private BitArray GetIDHash()
        {
            return new BitArray(BitConverter.GetBytes(ID));
        }

        private BitArray GetLicencePlateHash()
        {
            int[] weigths = { 2, 3, 5, 7, 11, 11, 7, 5, 3, 2 };
            long hash = 0;

            for (int i = 0; i < _licencePlateLength; i++)
            {
                hash = (hash + (_licencePlate[i] * weigths[i])) % long.MaxValue;  // zabranenie longu pretiect
            }

            return new BitArray(BitConverter.GetBytes(hash));
        }

        public static int GenerateId()                      // stack overflow kod: https://stackoverflow.com/questions/51641722/create-a-c-sharp-method-to-generate-auto-increment-id
        {
            return Interlocked.Increment(ref LastId);
        }
    }
}
