using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAllAsync();
        IQueryable<T> FindAllAsync(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        IQueryable<T> FindByConditionAsyncs(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        Task<T> Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        Task<T> FindById(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
        Task<IEnumerable<M>> FindByConditionWithoutSaveAsync<M>(Expression<Func<T, bool>> expression, Expression<Func<T, M>> selector, params Expression<Func<T, object>>[] includes);


    }
}
