namespace Core.Services
{
    public interface IServiceBase<T>
    {
        Task<List<T>> GetAll();
        Task<T> Create(T entity);
        Task Update(T entity);
        Task<bool> Delete(int id);
    }
}
