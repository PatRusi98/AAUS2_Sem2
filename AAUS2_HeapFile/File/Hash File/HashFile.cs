using AAUS2_HeapFile.Interfaces;
using System.Diagnostics;

namespace AAUS2_HeapFile.File
{
    public class HashFile<T> : IDisposable where T : IHashFile<T>
    {
        private int BlocksCount { get; set; }
        private int BlockFactor { get; set; }
        private string FileName { get; set; }
        private int BlockSize { get; set; } = -1;
        private FileStream _file;

        public HashFile(string fileName, int blockSize)
        {
            FileName = fileName;
            BlockSize = blockSize;

            _file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            if (_file.Length > 0)
            {
                // TODO nacitaj file
            }
            else
            {
                BlocksCount = 0;
                BlockFactor = HashBlock<T>.GetBlockFactor(BlockSize);
            }
        }

        public long Insert(T record, long address)
        {
            var block = GetBlockFromFile(address);
            block.Insert(record);

            InsertBlockIntoFile(address, block);
            return address;
        }

        //public void Delete(long address, T record)
        //{
        //    // TODO
        //    var block = GetBlockFromFile(address);
        //    block.Remove(record);
        //    InsertBlockIntoFile(address, block);
        //}

        public T? Get(long address, T record)
        {
            var block = GetBlockFromFile(address);
            return block.Get(record);
        }

        public List<T>? GetAllFromBlock(long address)
        {
            var block = GetBlockFromFile(address);
            return block.GetAll();
        }

        public HashBlock<T> GetBlockFromFile(long address)
        {
            EnsureBlockSize();

            _file.Seek(address, SeekOrigin.Begin);
            byte[] blockData = new byte[BlockSize];
            _file.Read(blockData, 0, BlockSize);

            HashBlock<T> block = new HashBlock<T>(BlockSize);
            block.FromByteArray(blockData);

            return block;
        }

        public void InsertBlockIntoFile(long address, HashBlock<T> block)
        {
            EnsureBlockSize();

            _file.Seek(address, SeekOrigin.Begin);
            byte[] blockData = block.ToByteArray();
            _file.Write(blockData, 0, BlockSize);
            _file.Flush();
        }

        public long CreateNewBlock()
        {
            long address = BlocksCount * BlockSize;
            var block = HashBlock<T>.GetEmptyBlock(BlockSize);
            InsertBlockIntoFile(address, block);
            BlocksCount++;

            return address;
        }

        private void EnsureBlockSize()
        {
            if (BlockSize < 0)
                BlockSize = HashBlock<T>.GetEmptyBlock(BlockSize).GetSize();
        }

        public void Dispose()
        {
            _file.Close();
            _file.Dispose();
        }
        
        public long GetFileLength()
        {
            return _file.Length;
        }

        public List<T> GetAllSequential(bool consolePrint = true)
        {
            List<T> records = new();
            for (int i = 0; i < BlocksCount; i++)
            {
                var block = GetBlockFromFile(i * BlockSize);

                if (consolePrint)
                    Debug.WriteLine(block.ToString());

                records.AddRange(block.GetAll());
            }

            return records;
        }
    }
}