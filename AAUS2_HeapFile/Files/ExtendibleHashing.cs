using AAUS2_HeapFile.Interfaces;
using System;
using System.Collections;
using System.Text;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Files
{
    public class ExtendibleHashing<T> where T : IHashFile<T>
    {
        private HashFile<T> _hashFile;
        private long[] Directory;
        private int BlockSize { get; set; }
        private int GlobalDepth { get; set; }

        public ExtendibleHashing(string hashFileName, string fileName, int blockSize)
        {
            BlockSize = blockSize;
            GlobalDepth = 1;
            Directory = new long[1 << GlobalDepth];

            _hashFile = new HashFile<T>(hashFileName, blockSize);
            var loadedFile = LoadPropsFromFile(fileName);

            if (!loadedFile)
            {
                for (int i = 0; i < Directory.Length; i++)
                {
                    long address = _hashFile.CreateNewBlock();
                    Directory[i] = address;
                }
            }
        }

        public void Insert(T record)
        {
            var hash = record.GetHash();
            var address = GetHashAddress(hash);
            var block = HashBlock<T>.GetEmptyBlock(BlockSize);

            if (address != -1)
            {
                block = _hashFile.GetBlockFromFile(address);
            }
            else
            {
                var trimmedHash = TrimHashKey(hash, GlobalDepth);
                block.LocalDepth = GlobalDepth;
                address = _hashFile.GetFileLength();

                Directory[GetIndexFromHash(trimmedHash)] = address;
            }

            if (block.IsFull())
            {
                if (GlobalDepth == block.LocalDepth)
                {
                    DoubleDirectory();
                }

                (block, var newBlock, var inserted) = SplitBlock(block, record);

                while ((block.IsFull() || newBlock.IsFull()) && !inserted)
                {
                    if (newBlock.IsFull())
                    {
                        var hsh = TrimHashKey(hash, GlobalDepth);
                        var idx = GetIndexFromHash(hsh);
                        var tmpIdx = idx;
                        var oldAddress = Directory[idx];

                        if (newBlock.LocalDepth == GlobalDepth)
                        {
                            if (idx < Directory.Length)
                            {
                                while (Directory[idx] == oldAddress)
                                {
                                    Directory[idx] = -1;
                                    idx++;

                                    if (idx >= Directory.Length)
                                        break;
                                }
                            }
                            Directory[tmpIdx] = _hashFile.GetFileLength();
                        }
                        else
                        {
                            var diff = GlobalDepth - newBlock.LocalDepth;
                            var bitsToHandle = Math.Pow(2, diff);
                            var indexes = GetDirectoryIndexes(address);
                            for (int i = indexes.Count / 2; i < indexes.Count; i++)
                            {
                                Directory[indexes[i]] = _hashFile.GetFileLength();
                            }
                            Console.WriteLine("Rewrite directory");
                        }

                        _hashFile.InsertBlockIntoFile(address, block);
                        _hashFile.InsertBlockIntoFile(_hashFile.GetFileLength(), newBlock);

                        block = newBlock;
                        newBlock = HashBlock<T>.GetEmptyBlock(BlockSize);
                        address = GetHashAddress(hash);
                    }
                    else
                    {
                        RewriteDirectoryToNullAddress(address);
                    }

                    if (GlobalDepth == block.LocalDepth)
                    {
                        DoubleDirectory();
                    }

                    if (block.IsFull())
                        (block, newBlock, inserted) = SplitBlock(block, record);
                    else if (newBlock.IsFull())
                        (newBlock, block, inserted) = SplitBlock(newBlock, record);
                }

                var newHash = TrimHashKey(hash, GlobalDepth);
                var index = GetIndexFromHash(newHash);

                if (newHash[block.LocalDepth - 1] && !inserted)
                {
                    newBlock.Insert(record);
                }
                else if (!inserted)
                {
                    block.Insert(record);
                }

                if (!newHash[newHash.Length - 1])
                    index++;

                if (block.LocalDepth == GlobalDepth)
                {
                    var oldAddress = Directory[index];
                    Directory[index] = _hashFile.GetFileLength();
                    index++;

                    if (index < Directory.Length)
                    {
                        while (Directory[index] == oldAddress && index < Directory.Length)
                        {
                            Directory[index] = -1;
                            index++;

                            if (index >= Directory.Length)
                                break;
                        }
                    }
                }
                else
                {
                    RewriteDirectory(address);
                }

                _hashFile.InsertBlockIntoFile(address, block);
                _hashFile.InsertBlockIntoFile(_hashFile.GetFileLength(), newBlock);
            }
            else
            {
                block.Insert(record);
                _hashFile.InsertBlockIntoFile(address, block);
            }
        }

        public T Search(T record)
        {
            var hash = record.GetHash();
            var address = GetHashAddress(hash);
            var block = _hashFile.GetBlockFromFile(address);

            return block.Get(record);
        }

        private (HashBlock<T> lastFalse, HashBlock<T> lastTrue, bool inserted) SplitBlock(HashBlock<T> block, T recordToInsert)
        {
            block.LocalDepth++;
            var newBlock = HashBlock<T>.GetEmptyBlock(BlockSize);
            newBlock.LocalDepth = block.LocalDepth;

            List<T> tmp = new List<T>();

            foreach (var record in block.Records)
            {
                var hash = record.GetHash();
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

            var inserted = false;
            var newHash = recordToInsert.GetHash();
            var newBit = newHash[block.LocalDepth - 1];

            if (!newBlock.IsFull() && newBit)
            {
                newBlock.Insert(recordToInsert);
                inserted = true;
            }
            else if (!block.IsFull() && !newBit)
            {
                block.Insert(recordToInsert);
                inserted = true;
            }

            return (block, newBlock, inserted);
        }

        private void DoubleDirectory()
        {
            GlobalDepth++;
            var newDirectory = new long[1 << GlobalDepth];

            for (int i = 0; i < Directory.Length; i++)
            {
                newDirectory[2 * i] = Directory[i];
                newDirectory[2 * i + 1] = Directory[i];
            }

            Directory = newDirectory;
        }

        private long GetHashAddress(BitArray hashKey)
        {
            var trimmedHashKey = TrimHashKey(hashKey, GlobalDepth);
            var index = GetIndexFromHash(trimmedHashKey);

            if (index < Directory.Length)
            {
                return Directory[index];
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

        private int GetIndexFromHash(BitArray hashKey)
        {
            int index = 0;
            var inverted = new BitArray(hashKey.Length);
            for (int i = 0; i < hashKey.Length; i++)
            {
                inverted[i] = hashKey[hashKey.Length - i - 1];
            }
            for (int i = 0; i < inverted.Length; i++)
            {
                if (inverted[i])
                {
                    index |= (1 << i);
                }
            }
            return index;
        }

        public void Dispose(string fileName)
        {
            SavePropsIntoFile(fileName);
            _hashFile.Dispose();
        }

        private List<int> GetDirectoryIndexes(long address)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < Directory.Length; i++)
            {
                if (Directory[i] == address)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }

        private void RewriteDirectory(long address)
        {
            var items = GetDirectoryIndexes(address);
            for (int i = (items.Count / 2); i < items.Count; i++)
            {
                Directory[items[i]] = _hashFile.GetFileLength();
            }
        }

        private void RewriteDirectoryToNullAddress(long address)
        {
            var items = GetDirectoryIndexes(address);
            for (int i = (items.Count / 2); i < items.Count; i++)
            {
                Directory[items[i]] = -1;
            }
        }

        public void SavePropsIntoFile(string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine($"GlobalDepth,{GlobalDepth}");
            writer.Write("Directory,");
            for (int i = 0; i < Directory.Length; i++)
            {
                writer.Write($"{Directory[i]}");
                if (i < Directory.Length - 1)
                {
                    writer.Write(";");
                }
            }
            writer.Close();
        }

        public string SequentialToString()
        {
            var address = 0;
            StringBuilder sb = new();

            sb.AppendLine("HEADER:");
            sb.AppendLine("Block size: " + BlockSize);
            sb.AppendLine("Global depth: " + GlobalDepth);
            sb.AppendLine("**********************************************************************************************");

            while (address < _hashFile.GetFileLength())
            {
                sb.AppendLine("BLOCK ADDRESS " + address + ":");
                var block = _hashFile.GetBlockFromFile(address);
                sb.AppendLine(block.ToString());
                sb.AppendLine("**********************************************************************************************");
                address += BlockSize;
            }
            return sb.ToString();
        }

        private bool LoadPropsFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            StreamReader reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line.Split(',');
                if (parts[0] == "GlobalDepth")
                {
                    GlobalDepth = int.Parse(parts[1]);
                }
                else if (parts[0] == "Directory")
                {
                    var dir = parts[1].Split(';');
                    Directory = new long[dir.Length];
                    for (int i = 0; i < dir.Length; i++)
                    {
                        Directory[i] = long.Parse(dir[i]);
                    }
                }
            }
            reader.Close();
            return true;
        }
    }
}