namespace BlazorApp.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task Update( T entity);
        Task Delete(T entity);
    }
}
