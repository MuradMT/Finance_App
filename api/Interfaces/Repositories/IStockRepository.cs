namespace api.Interfaces.Repositories;

public interface IStockRepository: IRepository<Stock>
{
  Task<List<Stock>> GetAllWithCommentsAsync();
  Task<Stock?> GetWithCommentsByIdAsync(int id);
}
