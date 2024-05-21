using api.Dtos.Stock.Request;
using api.Dtos.Stock.Response;

namespace api.Interfaces.Services;

public interface IStockService
{
    Task<List<StockDto>> GetAllStocksAsync();
    Task<StockDto?> GetStockByIdAsync(int id);

    Task<StockDto> CreateStockAsync(CreateStockDto stockDto);
    Task<StockDto> UpdateStockAsync(int id, UpdateStockDto stockDto);
    Task DeleteStockAsync(int id);
}
