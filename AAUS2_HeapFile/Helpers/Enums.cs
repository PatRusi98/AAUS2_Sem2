using System.ComponentModel;

namespace AAUS2_HeapFile.Helpers
{
    public static class Enums
    {
        public enum HashProperty : short
        {
            [Description("None")]
            None = 0,
            [Description("ID")]
            ID = 1,
            [Description("Licence Plate")]
            LicencePlate = 2
        }
    }
}
