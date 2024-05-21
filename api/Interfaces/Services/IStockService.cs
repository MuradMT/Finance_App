namespace api.Interfaces.Services;

public interface IStockService:IService<CreateStockDto, StockDto>
{
    
    Task<StockDto> UpdateStockAsync(int id, UpdateStockDto stockDto);
    
}
