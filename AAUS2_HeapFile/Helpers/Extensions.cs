using System.Collections;

namespace AAUS2_HeapFile.Helpers
{
    public static class Extensions
    {
        public static string ToBitString(this BitArray arr) // prebrane zo stack overflow: https://stackoverflow.com/questions/50243582/find-duplicate-of-array-of-bitarray
        {
            return string.Join("", arr.Cast<bool>().Select(bit => bit ? 1 : 0));
        }
    }
}
