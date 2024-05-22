


namespace api.Services.UnitOfWork;
public class UnitOfWork<TEntity, TContext>(TContext _context) : IUnitOfWork<TEntity,TContext>
    where TEntity : class, IEntity
    where TContext : DbContext
{
    IRepository<TEntity> _repository;
    public IRepository<TEntity> Repository => _repository ??= new BaseRepository<TEntity, TContext>(_context);

    public void Dispose()
    {
        _context.Dispose();
    }
}

