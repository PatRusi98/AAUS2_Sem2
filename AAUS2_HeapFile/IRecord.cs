namespace AAUS2_HeapFile
{
    public interface IRecord<T> : IData
    {
        bool Equals(T data);
        T CreateCopy();
    }
}
