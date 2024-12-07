using System.Collections;
using System.ComponentModel;

namespace AAUS2_HeapFile.Helpers
{
    public static class Extensions
    {
        public static string ToBitString(this BitArray arr) // prebrane zo stack overflow: https://stackoverflow.com/questions/50243582/find-duplicate-of-array-of-bitarray
        {
            return string.Join("", arr.Cast<bool>().Select(bit => bit ? 1 : 0));
        }

        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
