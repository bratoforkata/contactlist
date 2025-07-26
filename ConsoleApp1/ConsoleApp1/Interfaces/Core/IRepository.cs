namespace ConsoleApp1.Interfaces.Core
{
    public interface IRepository<T>
    {
        void Add(T item);
        T[] GetAll();
        void RemoveAt(int i);
        void ReplaceAt(int i, T item);
    }
}