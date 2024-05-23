namespace api.Interfaces.Repositories;

public interface IStockRepository: IRepository<Stock>
{
  Task<List<Stock>> GetAllWithCommentsAsync(StockQuery stockQuery);
  Task<Stock?> GetWithCommentsByIdAsync(int id);
  Task<bool> StockExists(int id);
}
