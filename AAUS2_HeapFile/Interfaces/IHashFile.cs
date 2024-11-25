using System.Collections;

namespace AAUS2_HeapFile.Interfaces
{
    public interface IHashFile<T> : IRecord<T>
    {
        public BitArray GetHash();
    }
}
