using AAUS2_HeapFile.Helpers;
using AAUS2_HeapFile.Interfaces;
using System.Collections;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.File
{
    public class ExtendibleHashing<T> where T : IHashFile<T>
    {
        private HashFile<T> _hashFile;
        private Dictionary<BitArray, long> Directory;
        private int BlockSize { get; set; }
        private int GlobalDepth { get; set; }
        private HashProperty Prop { get; set; } = HashProperty.None;

        public ExtendibleHashing(string hashFileName, int blockSize)
        {
            BlockSize = blockSize;
            GlobalDepth = 1;
            Directory = new Dictionary<BitArray, long>(new BitArrayComparer());

            _hashFile = new HashFile<T>(hashFileName, blockSize);

            for (int i = 0; i < (1 << GlobalDepth); i++)
            {
                var key = new BitArray(BitConverter.GetBytes(i));
                long address = _hashFile.CreateNewBlock();
                var trimmed = TrimHashKey(key, GlobalDepth);
                Directory.Add(trimmed, address);
            }
        }

        public void Insert(T record, HashProperty hashBy)
        {
            if (Prop == HashProperty.None)
                Prop = hashBy;

            var hash = record.GetHash(Prop);
            var address = GetHashAddress(hash);

            var block = _hashFile.GetBlockFromFile(address);
            
            if (block.IsFull())
            {
                if (GlobalDepth == block.LocalDepth)
                {
                    DoubleDirectory();
                    //address = GetHashAddress(hash);
                }

                (block, var newBlock) = SplitBlock(block);

                while (block.IsFull() || newBlock.IsFull())
                {
                    if (GlobalDepth == block.LocalDepth)
                    {
                        DoubleDirectory();
                    }

                    if (block.IsFull())
                        (block, newBlock) = SplitBlock(block);
                    else if (newBlock.IsFull())
                        (newBlock, block) = SplitBlock(newBlock);
                }

                var newHash = TrimHashKey(hash, block.LocalDepth);

                if (newHash[block.LocalDepth - 1])
                {
                    newBlock.Insert(record);
                }
                else
                {
                    block.Insert(record);
                }

                Directory[newHash] = _hashFile.GetFileLength();
                _hashFile.InsertBlockIntoFile(address, block);
                _hashFile.InsertBlockIntoFile(_hashFile.GetFileLength(), newBlock);
            }
            else
            {
                block.Insert(record);
                _hashFile.InsertBlockIntoFile(address, block);
            }
        }

        public T Search(T record, HashProperty hashBy)
        {
            if (Prop == HashProperty.None)
                Prop = hashBy;

            var hash = record.GetHash(Prop);
            var address = GetHashAddress(hash);
            var block = _hashFile.GetBlockFromFile(address);

            return block.Get(record);
        }

        private (HashBlock<T> lastFalse, HashBlock<T> lastTrue) SplitBlock(HashBlock<T> block)
        {
            block.LocalDepth++;
            var newBlock = HashBlock<T>.GetEmptyBlock(BlockSize);
            newBlock.LocalDepth = block.LocalDepth;

            List<T> tmp = new List<T>();

            foreach (var record in block.Records)
            {
                var hash = record.GetHash(Prop);
                var bit = hash[block.LocalDepth - 1];

                if (bit)
                {
                    newBlock.Insert(record);
                    tmp.Add(record);
                }
            } 

            foreach (var record in tmp)
            {
                block.Remove(record);
            }

            return (block, newBlock);
        }

        private void DoubleDirectory()
        {
            GlobalDepth++;
            Dictionary<BitArray, long> newDirectory = new Dictionary<BitArray, long>(new BitArrayComparer());

            foreach (var item in Directory)
            {
                var hash = item.Key;
                var address = item.Value;

                newDirectory.Add(ExtendHashKey(hash, false), address);
                newDirectory.Add(ExtendHashKey(hash, true), address);
            }

            Directory = newDirectory;
        }

        private long GetHashAddress(BitArray hashKey)
        {
            var trimmedHashKey = TrimHashKey(hashKey, GlobalDepth);

            if (Directory.TryGetValue(trimmedHashKey, out var address))
            {
                return address;
            }

            throw new Exception("Hash address not found.");
        }

        private BitArray TrimHashKey(BitArray hashKey, int depth)
        {
            var trimmed = new BitArray(depth);
            for (int i = 0; i < depth; i++)
            {
                trimmed[i] = hashKey[i];
            }
            return trimmed;
        }

        private BitArray ExtendHashKey(BitArray hashKey, bool bitToSet)
        {
            var extended = new BitArray(hashKey.Length + 1);
            for (int i = 0; i < hashKey.Length; i++)
            {
                extended[i] = hashKey[i];
            }
            extended[hashKey.Length] = bitToSet;
            return extended;
        }

        public void Dispose()
        {
            _hashFile.Dispose();
        }
    }
}