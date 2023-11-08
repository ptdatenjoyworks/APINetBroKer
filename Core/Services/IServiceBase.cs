namespace Core.Services
{
    public interface IServiceBase<T,M>
    {
        Task<List<T>> GetAll();
        Task<T> Create(M entity);
        Task Update(M entity);
        Task<bool> Delete(int id);
    }
}
