﻿namespace api.Interfaces.Repositories;

public interface IRepository<T> where T : class,IEntity
{
    Task<List<T>> GetAllAsync();
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task AddAsync(T entity);
    Task<T?> GetByIdAsync(int id);

}
