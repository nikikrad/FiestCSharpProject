namespace NoBleyzer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        void Create(T item);
        void Delete(int id);
    }
}
