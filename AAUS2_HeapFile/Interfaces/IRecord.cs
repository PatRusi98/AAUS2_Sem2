namespace AAUS2_HeapFile.Interfaces
{
    public interface IRecord<T> : IData
    {
        bool Equals(T data);
        T CreateCopy();
    }
}
