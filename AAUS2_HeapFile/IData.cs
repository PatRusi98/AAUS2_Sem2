namespace AAUS2_HeapFile
{
    public interface IData
    {
        byte[] ToByteArray();
        void FromByteArray(byte[] byteArray);
        int GetSize();
    }
}
