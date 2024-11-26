using AAUS2_HeapFile.Interfaces;

namespace AAUS2_HeapFile.File
{
    public class Block<T> : IData where T : IRecord<T>
    {
        public int ValidCount { get; private set; } = 0;
        public int TotalCount { get; private set; }
        public long NextEmptyBlockAddress { get; set; } = -1;
        public long PreviousEmptyBlockAddress { get; set; } = -1;
        public int BlockSize { get; set; }
        public T[] Records { get; }
        private static int HeaderSize { get; set; } = sizeof(int) + sizeof(long) * 2;

        public Block(int blockSize)
        {
            HeaderSize = sizeof(int) + sizeof(long) * 2;
            BlockSize = blockSize;
            TotalCount = (blockSize - HeaderSize) / Activator.CreateInstance<T>().GetSize();
            if (TotalCount == 0)
            {
                throw new Exception("Small block size!!!");
            }
            Records = new T[TotalCount];
        }

        public static Block<T> GetEmptyBlock(int blockFactor)
        {
            return new Block<T>(blockFactor);
        }

        public static int GetBlockFactor(int blockSize)
        {
            return (blockSize - HeaderSize) / Activator.CreateInstance<T>().GetSize();
        }

        #region Overrides
        public void FromByteArray(byte[] byteArray)
        {
            var index = 0;

            ValidCount = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);

            NextEmptyBlockAddress = BitConverter.ToInt64(byteArray, index);
            index += sizeof(long);

            PreviousEmptyBlockAddress = BitConverter.ToInt64(byteArray, index);
            index += sizeof(long);

            for (int i = 0; i < ValidCount; i++)
            {
                var record = Activator.CreateInstance<T>(); // vytvorenie instancie recordu pomocou bezparametrickeho konstruktora
                record.FromByteArray(byteArray[index..]);
                Records[i] = record;
                index += record.GetSize();
            }

            for (int i = ValidCount; i < TotalCount; i++)
            {
                Records[i] = default!;
            }
        }

        public byte[] ToByteArray()
        {
            var validCountBytes = BitConverter.GetBytes(ValidCount);
            var nextEmptyAddressBytes = BitConverter.GetBytes(NextEmptyBlockAddress);
            var previousEmptyAddressBytes = BitConverter.GetBytes(PreviousEmptyBlockAddress);

            var byteArr = new byte[GetSize()];
            int offset = 0;

            Buffer.BlockCopy(validCountBytes, 0, byteArr, offset, validCountBytes.Length);
            offset += validCountBytes.Length;

            Buffer.BlockCopy(nextEmptyAddressBytes, 0, byteArr, offset, nextEmptyAddressBytes.Length);
            offset += nextEmptyAddressBytes.Length;

            Buffer.BlockCopy(previousEmptyAddressBytes, 0, byteArr, offset, previousEmptyAddressBytes.Length);
            offset += previousEmptyAddressBytes.Length;

            foreach (var record in Records)
            {
                byte[] recordBytes;
                if (record == null)
                    recordBytes = new byte[Activator.CreateInstance<T>().GetSize()];
                else
                    recordBytes = record.ToByteArray();

                Buffer.BlockCopy(recordBytes, 0, byteArr, offset, recordBytes.Length);
                offset += recordBytes.Length;
            }

            for (int i = offset; i < byteArr.Length; i++)
            {
                byteArr[i] = 0;
            }

            return byteArr;
        }

        public int GetSize()
        {
            return BlockSize;
        }
        #endregion

        public T? Get(T record)
        {
            foreach (var item in Records)
            {
                if (item != null && item.Equals(record))
                {
                    return item;
                }
            }

            return default;
        }

        public void Insert(T record)
        {
            if (ValidCount < TotalCount)
            {
                Records[ValidCount] = record;
                ValidCount++;
            }
            else
            {
                throw new Exception("Block is full");
            }
        }

        public void Remove(T record)
        {
            for (int i = 0; i < ValidCount; i++)
            {
                if (Records[i] != null && Records[i].Equals(record))
                {
                    for (int j = i; j < ValidCount - 1; j++)
                    {
                        Records[j] = Records[j + 1];
                    }

                    Records[ValidCount - 1] = default!;
                    ValidCount--;
                    return;
                }
            }

            throw new Exception("Record not found");
        }
    }
}
