using AAUS2_HeapFile.Interfaces;
using System.Collections;
using System.Text;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Entities
{
    public class LicencePlateToHashFile : IHashFile<LicencePlateToHashFile>
    {
        private const int _licencePlateLength = 10;
        private string _licencePlate;
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
        public long Address { get; set; }

        public LicencePlateToHashFile()
        {
            _licencePlate = string.Empty.PadRight(_licencePlateLength, '\0');
        }

        public LicencePlateToHashFile CreateCopy()
        {
            return new LicencePlateToHashFile()
            {
                LicencePlate = LicencePlate,
                Address = Address
            };
        }

        public bool Equals(LicencePlateToHashFile data)
        {
            return LicencePlate == data.LicencePlate;
        }

        public void FromByteArray(byte[] byteArray)
        {
            LicencePlateValidLength = BitConverter.ToInt32(byteArray, 0);
            var tmpLP = Encoding.UTF8.GetString(byteArray, sizeof(int), _licencePlateLength);
            LicencePlate = tmpLP.Substring(0, LicencePlateValidLength);
            Address = BitConverter.ToInt64(byteArray, sizeof(int) + _licencePlateLength);
        }

        public BitArray GetHash(HashProperty filter)
        {
            int[] weights = { 31, 37, 41, 43, 47, 47, 43, 41, 37, 31 };
            int hash = 17;
            
            for (int i = 0; i < _licencePlateLength; i++)
            {
                hash = (hash * 31 + _licencePlate[i] * weights[i % weights.Length]) % Int32.MaxValue;
            }

            return new BitArray(BitConverter.GetBytes(hash));
        }

        public int GetSize()
        {
            return sizeof(int) + _licencePlateLength + sizeof(long);
        }

        public byte[] ToByteArray()
        {
            var validLengthBytes = BitConverter.GetBytes(LicencePlateValidLength);
            var licencePlateBytes = Encoding.UTF8.GetBytes(_licencePlate);
            var addressBytes = BitConverter.GetBytes(Address);

            var totalLength = validLengthBytes.Length + licencePlateBytes.Length + addressBytes.Length;
            var byteArr = new byte[totalLength];

            int offset = 0;

            Buffer.BlockCopy(validLengthBytes, 0, byteArr, offset, validLengthBytes.Length);
            offset += validLengthBytes.Length;
            Buffer.BlockCopy(licencePlateBytes, 0, byteArr, offset, licencePlateBytes.Length);
            offset += licencePlateBytes.Length;
            Buffer.BlockCopy(addressBytes, 0, byteArr, offset, addressBytes.Length);

            return byteArr;
        }

        public string ToString()
        {
            return $"Licence plate: {LicencePlate}, Address: {Address}";
        }
    }
}
