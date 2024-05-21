namespace api.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(int id);

}
