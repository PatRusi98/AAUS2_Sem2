using AAUS2_HeapFile.Interfaces;
using System.Collections;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Entities
{
    public class VehicleIDToHashFile : IHashFile<VehicleIDToHashFile>
    {
        public int ID { get; set; }
        public long Address { get; set; }

        public VehicleIDToHashFile() 
        {
            ID = -1;
            Address = -1;
        }

        public BitArray GetHash(HashProperty filter)
        {
            CheckIfNotNull();
            return new BitArray(BitConverter.GetBytes(ID));
        }

        public bool Equals(VehicleIDToHashFile data)
        {
            CheckIfNotNull();
            return ID == data.ID;
        }

        public VehicleIDToHashFile CreateCopy()
        {
            return new VehicleIDToHashFile()
            {
                ID = ID,
                Address = Address
            };
        }

        public byte[] ToByteArray()
        {
            CheckIfNotNull();
            var byteArr = new byte[GetSize()];
            var offset = 0;

            BitConverter.GetBytes(ID).CopyTo(byteArr, offset);
            offset += sizeof(int);
            BitConverter.GetBytes(Address).CopyTo(byteArr, offset);

            return byteArr;
        }

        public void FromByteArray(byte[] byteArray)
        {
            var index = 0;
            ID = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);
            Address = BitConverter.ToInt64(byteArray, index);
        }

        public int GetSize()
        {
            return sizeof(int) + sizeof(long);
        }

        private void CheckIfNotNull()
        {
            if (ID == -1)
            {
                throw new Exception("ID is null");
            }

        }
    }
}
