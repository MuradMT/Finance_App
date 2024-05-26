namespace api.Interfaces.Repositories;

public interface IStockRepository: IRepository<Stock>
{
  Task<List<Stock>> GetAllWithCommentsAsync(StockQuery stockQuery);
  Task<Stock?> GetWithCommentsByIdAsync(int id);
  Task<Stock?> GetStockBySymbolAsync(string symbol);
  Task<bool> StockExists(int id);
}
