namespace AAUS2_HeapFile.Interfaces
{
    public interface IData
    {
        byte[] ToByteArray();
        void FromByteArray(byte[] byteArray);
        int GetSize();
    }
}
