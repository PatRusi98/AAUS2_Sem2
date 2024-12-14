using System.Collections;
using static AAUS2_HeapFile.Helpers.Enums;

namespace AAUS2_HeapFile.Interfaces
{
    public interface IHashFile<T> : IRecord<T>
    {
        public BitArray GetHash();
    }
}
