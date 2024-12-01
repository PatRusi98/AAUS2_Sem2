using System.Collections;
using System.Diagnostics;

namespace AAUS2_HeapFile.Helpers
{
    public class BitArrayComparer : IEqualityComparer<BitArray> // prebrane zo stack overflow: https://stackoverflow.com/questions/50243582/find-duplicate-of-array-of-bitarray
    {
        public bool Equals(BitArray a, BitArray b)
        {
            var result = a.ToBitString() == b.ToBitString();
            //Debug.WriteLine("Result: " + result + " A: " + a.ToBitString() + " B: " + b.ToBitString());
            return result;
        }

        public int GetHashCode(BitArray o)
        {
            var hashCode = o.ToBitString().GetHashCode();
            return hashCode;
        }
    }
}
