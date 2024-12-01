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
            int[] weigths = { 2, 3, 5, 7, 11, 11, 7, 5, 3, 2 };
            long hash = 0;

            for (int i = 0; i < _licencePlateLength; i++)
            {
                hash = (hash + (_licencePlate[i] * weigths[i])) % long.MaxValue;  // zabranenie longu pretiect
            }

            return new BitArray(BitConverter.GetBytes(hash));

            //// Veľké prvočísla pre váhy
            //int[] weights = { 257, 263, 269, 271, 277, 281, 283, 293, 307, 311 };

            //ulong hash = 0;

            //for (int i = 0; i < _licencePlateLength; i++)
            //{
            //    // Rotácia bitov namiesto jednoduchého posunu
            //    ulong rotated = RotateLeft((ulong)_licencePlate[i] * (ulong)weights[i % weights.Length], i % 32);

            //    // Kombinácia aktuálneho hashu so spracovaným znakom
            //    hash ^= rotated;

            //    // Modulárne delenie a premiešavanie
            //    hash = (hash * 6364136223846793005L + 1442695040888963407L) % 1000000007;
            //}

            //// Záverečné miešanie pre lepšiu distribúciu
            //hash ^= (hash >> 33);
            //hash ^= (hash >> 17);
            //hash ^= (hash >> 7);

            //// Konvertujeme na BitArray
            //return new BitArray(BitConverter.GetBytes(hash));
        }

        //// Pomocná funkcia pre rotáciu bitov doľava
        //private static ulong RotateLeft(ulong value, int count)
        //{
        //    return (value << count) | (value >> (64 - count));
        //}

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
    }
}
