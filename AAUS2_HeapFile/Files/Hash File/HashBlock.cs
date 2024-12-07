using AAUS2_HeapFile.Interfaces;
using System.Text;

namespace AAUS2_HeapFile.Files
{
    public class HashBlock<T> : IData where T : IRecord<T>
    {
        public int ValidCount { get; private set; } = 0;
        public int TotalCount { get; private set; }
        public int BlockSize { get; set; }
        public int LocalDepth { get; set; } = 1;
        public T[] Records { get; }

        public HashBlock(int blockSize)
        {
            BlockSize = blockSize;
            TotalCount = (blockSize - sizeof(int) - sizeof(int)) / Activator.CreateInstance<T>().GetSize();
            if (TotalCount == 0)
            {
                throw new Exception("Small block size!!!");
            }
            Records = new T[TotalCount];
        }

        public static HashBlock<T> GetEmptyBlock(int blockSize)
        {
            return new HashBlock<T>(blockSize);
        }

        public static int GetBlockFactor(int blockSize)
       {
            return blockSize / Activator.CreateInstance<T>().GetSize();
        }

        #region Overrides
        public void FromByteArray(byte[] byteArray)
        {
            var index = 0;

            LocalDepth = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);
            ValidCount = BitConverter.ToInt32(byteArray, index);
            index += sizeof(int);

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
            var localDepthBytes = BitConverter.GetBytes(LocalDepth);
            var validCountBytes = BitConverter.GetBytes(ValidCount);

            var byteArr = new byte[GetSize()];
            int offset = 0;

            Buffer.BlockCopy(localDepthBytes, 0, byteArr, offset, localDepthBytes.Length);
            offset += localDepthBytes.Length;
            Buffer.BlockCopy(validCountBytes, 0, byteArr, offset, validCountBytes.Length);
            offset += validCountBytes.Length;

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

        public List<T>? GetAll()
        {
            var result = new List<T>();

            for (int i = 0; i < ValidCount; i++)
            {
                result.Add(Records[i]);
            }

            return result;
        }

        public bool IsFull()
        {
            return ValidCount == TotalCount;
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
                throw new Exception("HashBlock is full");
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ValidCount: {ValidCount}");
            sb.AppendLine($"TotalCount: {TotalCount}");
            sb.AppendLine($"BlockSize: {BlockSize}");
            sb.AppendLine($"LocalDepth: {LocalDepth}");
            sb.AppendLine("Records:");

            foreach (var record in Records)
            {
                sb.AppendLine(record?.ToString() ?? "null");
            }

            return sb.ToString();
        }
    }
}
