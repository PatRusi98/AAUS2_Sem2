using System.Collections;

namespace AAUS2_HeapFile.Helpers
{
    public class BitArrayComparer : IEqualityComparer<BitArray> // prebrane zo stack overflow: https://stackoverflow.com/questions/50243582/find-duplicate-of-array-of-bitarray
    {
        public bool Equals(BitArray a, BitArray b)
        {
            return a.ToBitString() == b.ToBitString();
        }

        public int GetHashCode(BitArray o)
        {
            return o.ToBitString().GetHashCode();
        }
    }
}
