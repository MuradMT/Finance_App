namespace api.Services;

public class StockService(IStockRepository _repository, IMapper _mapper) : IStockService
{
    public async Task<StockDto> CreateStockAsync(CreateStockDto stockDto)
    {
        var stock = _mapper.Map<Stock>(stockDto);
        await _repository.AddAsync(stock);
        return _mapper.Map<StockDto>(stock);
    }

    public async Task DeleteStockAsync(int id)
    {
        var stock = await _repository.GetByIdAsync(id);
        if (stock is null)
        {
            throw new StockNotFoundException(Messages.StockNotFound);
        }
        await _repository.DeleteAsync(stock);
    }

    public async Task<List<StockDto>> GetAllStocksAsync()
    {
        var stocks = await _repository.GetAllAsync();
        return _mapper.Map<List<StockDto>>(stocks);
    }

    public async Task<StockDto?> GetStockByIdAsync(int id)
    {
        var stock = await _repository.GetByIdAsync(id);
        return stock is not null ? _mapper.Map<StockDto>(stock) : throw new StockNotFoundException(Messages.StockNotFound);
    }

    public async Task<StockDto> UpdateStockAsync(int id, UpdateStockDto stockDto)
    {
        var stock = await _repository.GetByIdAsync(id);
        if (stock is null)
        {
            throw new StockNotFoundException(Messages.StockNotFound);
        }
        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.Purchase = stockDto.Purchase;
        stock.LastDiv = stockDto.LastDiv;
        stock.Industry = stockDto.Industry;
        stock.MarketCap = stockDto.MarketCap;
        await _repository.UpdateAsync(stock);
        return _mapper.Map<StockDto>(stock);
    }
}
