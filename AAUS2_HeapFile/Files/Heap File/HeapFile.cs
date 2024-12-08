using AAUS2_HeapFile.Entities;
using AAUS2_HeapFile.Interfaces;
using System.Diagnostics;
using System.Text;

namespace AAUS2_HeapFile.Files
{
    public class HeapFile<T> : IDisposable where T : IRecord<T>
    {
        private int BlocksCount { get; set; }
        private int BlockFactor { get; set; }
        private long EmptyBlockAddress { get; set; }
        private long PartiallyEmptyBlockAddress { get; set; }
        private string FileName { get; set; }
        private int BlockSize { get; set; } = -1;
        private FileStream _file;

        public HeapFile(string fileName, int blockSize)
        {
            FileName = fileName;
            BlockSize = blockSize;

            _file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            if (_file.Length > 0)
            {
                ReadFileHeader();
            }
            else
            {
                BlocksCount = 0;
                EmptyBlockAddress = -1;
                PartiallyEmptyBlockAddress = -1;
                BlockFactor = Block<T>.GetBlockFactor(BlockSize);
            }

            WriteFileHeader();
        }

        public long Insert(T record)
        {
            Block<T> block = new(BlockSize);

            var address = PartiallyEmptyBlockAddress;
            if (PartiallyEmptyBlockAddress == -1)
                address = EmptyBlockAddress;

            if (address == -1)
            {
                var add = BlocksCount * BlockSize + GetFileHeaderSize();
                BlocksCount++;
                block.Insert(record);
                block.PreviousEmptyBlockAddress = -1;
                block.NextEmptyBlockAddress = -1;
                InsertBlockIntoFile(add, block);
                PartiallyEmptyBlockAddress = add;
                return add;
            }

            block = GetBlockFromFile(address);
            block.Insert(record);

            if (block.ValidCount == block.TotalCount) // osetrenie retazenia
            {
                PartiallyEmptyBlockAddress = block.NextEmptyBlockAddress;

                if (PartiallyEmptyBlockAddress != -1)
                {
                    var nextBlock = GetBlockFromFile(PartiallyEmptyBlockAddress);
                    nextBlock.PreviousEmptyBlockAddress = -1;
                    InsertBlockIntoFile(PartiallyEmptyBlockAddress, nextBlock);
                }
            }
            else if (block.ValidCount == 1)
            {
                EmptyBlockAddress = block.NextEmptyBlockAddress;
                if (EmptyBlockAddress != -1)
                {
                    var nextBlock = GetBlockFromFile(EmptyBlockAddress);
                    nextBlock.PreviousEmptyBlockAddress = -1;
                    InsertBlockIntoFile(EmptyBlockAddress, nextBlock);
                }

                PartiallyEmptyBlockAddress = address; // staci takto lebo ked budeme vkladat do prazdneho tak to znamena, ze ciastocne volny neni
            }

            InsertBlockIntoFile(address, block);
            return address;
        }

        public void Delete(long address, T record)
        {
            var block = GetBlockFromFile(address);
            var deletedLast = false;
            block.Remove(record);

            if (block.ValidCount == 0) // osetrenie zretazenia
            {
                if (PartiallyEmptyBlockAddress != address)
                {
                    var prevBlock = GetBlockFromFile(block.PreviousEmptyBlockAddress);
                    prevBlock.NextEmptyBlockAddress = block.NextEmptyBlockAddress;
                    InsertBlockIntoFile(block.PreviousEmptyBlockAddress, prevBlock);

                    if (block.NextEmptyBlockAddress != -1)
                    {
                        var nextBlock = GetBlockFromFile(block.NextEmptyBlockAddress);
                        nextBlock.PreviousEmptyBlockAddress = block.PreviousEmptyBlockAddress;
                        InsertBlockIntoFile(block.NextEmptyBlockAddress, nextBlock);
                    }
                }
                else
                {
                    PartiallyEmptyBlockAddress = block.NextEmptyBlockAddress;
                    if (PartiallyEmptyBlockAddress != -1)
                    {
                        var nextBlock = GetBlockFromFile(PartiallyEmptyBlockAddress);
                        nextBlock.PreviousEmptyBlockAddress = -1;
                        InsertBlockIntoFile(PartiallyEmptyBlockAddress, nextBlock);
                    }
                }

                if (_file.Length == address + BlockSize) // skratenie suboru ak zmazeme posledny blok
                {
                    BlocksCount--;

                    var empty = true;
                    while (empty)
                    {
                        if (BlocksCount < 1)
                            break;

                        var lastBlock = GetBlockFromFile(BlocksCount * BlockSize + GetFileHeaderSize());
                        if (lastBlock.ValidCount == 0)
                        {
                            if (lastBlock.NextEmptyBlockAddress != -1)
                            {
                                var nextBlock = GetBlockFromFile(lastBlock.NextEmptyBlockAddress);
                                nextBlock.PreviousEmptyBlockAddress = lastBlock.PreviousEmptyBlockAddress;
                                InsertBlockIntoFile(lastBlock.NextEmptyBlockAddress, nextBlock);
                            }

                            if (lastBlock.PreviousEmptyBlockAddress != -1)
                            {
                                var prevBlock = GetBlockFromFile(lastBlock.PreviousEmptyBlockAddress);
                                prevBlock.NextEmptyBlockAddress = lastBlock.NextEmptyBlockAddress;
                                InsertBlockIntoFile(lastBlock.PreviousEmptyBlockAddress, prevBlock);
                            }

                            BlocksCount--;
                        }
                        else
                        {
                            empty = false;
                        }
                    }

                    deletedLast = true;
                    _file.SetLength(BlocksCount * BlockSize + GetFileHeaderSize());
                }

                if (EmptyBlockAddress != -1)
                {
                    var emptyBlock = GetBlockFromFile(EmptyBlockAddress);
                    emptyBlock.PreviousEmptyBlockAddress = address;
                    InsertBlockIntoFile(EmptyBlockAddress, emptyBlock);
                }

                if (!deletedLast)
                {
                    block.NextEmptyBlockAddress = EmptyBlockAddress;
                    EmptyBlockAddress = address;
                }
            }
            else if (block.TotalCount - block.ValidCount == 1)
            {
                if (PartiallyEmptyBlockAddress != -1)
                {
                    var prevBlock = GetBlockFromFile(PartiallyEmptyBlockAddress);
                    prevBlock.PreviousEmptyBlockAddress = address;
                    InsertBlockIntoFile(PartiallyEmptyBlockAddress, prevBlock);
                }

                block.NextEmptyBlockAddress = PartiallyEmptyBlockAddress;
                PartiallyEmptyBlockAddress = address;
            }

            if (!deletedLast)
                InsertBlockIntoFile(address, block);
        }

        public T? Get(long address, T record)
        {
            var block = GetBlockFromFile(address);
            return block.Get(record);
        }

        private Block<T> GetBlockFromFile(long address)
        {
            EnsureBlockSize();

            _file.Seek(address, SeekOrigin.Begin);
            byte[] blockData = new byte[BlockSize];
            _file.Read(blockData, 0, BlockSize);

            Block<T> block = new Block<T>(BlockSize);
            block.FromByteArray(blockData);

            return block;
        }

        private void InsertBlockIntoFile(long address, Block<T> block)
        {
            EnsureBlockSize();

            _file.Seek(address, SeekOrigin.Begin);
            byte[] blockData = block.ToByteArray();
            _file.Write(blockData, 0, BlockSize);
            _file.Flush();
        }

        private void EnsureBlockSize()
        {
            if (BlockSize < 0)
                BlockSize = Block<T>.GetEmptyBlock(BlockFactor).GetSize();
        }

        public List<T> GetAllSequential(bool consolePrint = true)
        {
            List<T> records = new();
            for (int i = 0; i < BlocksCount; i++)
            {
                var block = GetBlockFromFile(i * BlockSize + GetFileHeaderSize());

                if (consolePrint)
                    Debug.WriteLine(block.ToString());

                records.AddRange(block.GetAll());
            }

            return records;
        }

        public void Update(T obj, long address)
        {
            var block = GetBlockFromFile(address);

            for (int i = 0; i < block.Records.Length; i++)
            {
                if (block.Records[i] != null && block.Records[i].Equals(obj))
                {
                    block.Records[i] = obj;
                    break;
                }
            }

            InsertBlockIntoFile(address, block);
        }

        public void Dispose()
        {
            WriteFileHeader();
            _file.Close();
            _file.Dispose();
        }

        public string SequentialToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("FILE HEADER:");
            sb.AppendLine("BlocksCount: " + BlocksCount);
            sb.AppendLine("BlockFactor: " + BlockFactor);
            sb.AppendLine("BlockSize: " + BlockSize);
            sb.AppendLine("EmptyBlockAddress: " + EmptyBlockAddress);
            sb.AppendLine("PartiallyEmptyBlockAddress: " + PartiallyEmptyBlockAddress);
            sb.AppendLine("**********************************************************************************************");

            for (int i = 1; i <= BlocksCount; i++)
            {
                sb.AppendLine("BLOCK " + i + ":");
                var block = GetBlockFromFile(i * BlockSize);
                sb.AppendLine(block.ToString());
                sb.AppendLine("**********************************************************************************************");
            }
            return sb.ToString();
        }

        #region File Header
        private void ReadFileHeader()
        {
            _file.Seek(0, SeekOrigin.Begin);
            byte[] headerData = new byte[GetFileHeaderSize()];
            _file.Read(headerData, 0, headerData.Length);

            int offset = 0;
            BlocksCount = BitConverter.ToInt32(headerData, offset);
            offset += sizeof(int);
            BlockFactor = BitConverter.ToInt32(headerData, offset);
            offset += sizeof(int);
            BlockSize = BitConverter.ToInt32(headerData, offset);
            offset += sizeof(int);
            EmptyBlockAddress = BitConverter.ToInt64(headerData, offset);
            offset += sizeof(long);
            PartiallyEmptyBlockAddress = BitConverter.ToInt64(headerData, offset);
        }

        private void WriteFileHeader()
        {
            byte[] headerData = new byte[GetFileHeaderSize()];

            int offset = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(BlocksCount), 0, headerData, offset, sizeof(int));
            offset += sizeof(int);
            Buffer.BlockCopy(BitConverter.GetBytes(BlockFactor), 0, headerData, offset, sizeof(int));
            offset += sizeof(int);
            Buffer.BlockCopy(BitConverter.GetBytes(BlockSize), 0, headerData, offset, sizeof(int));
            offset += sizeof(int);
            Buffer.BlockCopy(BitConverter.GetBytes(EmptyBlockAddress), 0, headerData, offset, sizeof(long));
            offset += sizeof(long);
            Buffer.BlockCopy(BitConverter.GetBytes(PartiallyEmptyBlockAddress), 0, headerData, offset, sizeof(long));
            offset += sizeof(long);

            for (int i = offset; i < headerData.Length; i++)
            {
                headerData[i] = 0;
            }

            _file.Seek(0, SeekOrigin.Begin);
            _file.Write(headerData, 0, headerData.Length);
            _file.Flush();
        }

        private int GetFileHeaderSize()
        {
            var headerDataSize = 3 * sizeof(int) + 2 * sizeof(long);
            var multiplier = 1;
            var canFit = false;
            while (!canFit)
            {
                canFit = headerDataSize < BlockSize * multiplier;

                if (!canFit)
                    multiplier++;
            }

            return multiplier * BlockSize;
        }
        #endregion
    }
}