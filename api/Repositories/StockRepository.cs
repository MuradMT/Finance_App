

namespace api.Repositories;

public class StockRepository(ApplicationDbContext _context) : BaseRepository<Stock, ApplicationDbContext>(_context), IStockRepository
{

    public async Task<List<Stock>> GetAllWithCommentsAsync(StockQuery stockQuery)
    {
        var stocks = _context.Stocks.Include(p => p.Comments).AsQueryable();
        if (!string.IsNullOrWhiteSpace(stockQuery.CompanyName))
        {
            stocks = stocks.Where(p => p.CompanyName.Contains(stockQuery.CompanyName));
        }
        if (!string.IsNullOrWhiteSpace(stockQuery.Symbol))
        {
            stocks = stocks.Where(p => p.Symbol.Contains(stockQuery.Symbol));
        }
        if (!string.IsNullOrWhiteSpace(stockQuery.SortBy))
        {
            #region StringComparison.OrdinalIgnoreCase 
            //For unicode comparison
            //StringComparison.OrdinalIgnoreCase is an enumeration value that specifies 
            //the type of comparison to perform. 
            //In this case, it indicates that the comparison should be case-insensitive 
            //and based on the ordinal value of the characters.
            #endregion
            if (stockQuery.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQuery.isDescending is true? stocks.OrderByDescending(p => p.Id) : stocks.OrderBy(p => p.Id);
            }
            if (stockQuery.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
            {
                stocks = stockQuery.isDescending is true? stocks.OrderByDescending(p => p.Symbol) : stocks.OrderBy(p => p.Symbol);
            }
        }
        var skip= (stockQuery.Page - 1)* stockQuery.PageSize;
        return await stocks.Skip(skip).Take(stockQuery.PageSize).ToListAsync();
    }

    public async Task<Stock?> GetStockBySymbolAsync(string symbol)
    {
        return await _context.Stocks.FirstOrDefaultAsync(p => p.Symbol == symbol);
    }

    public Task<Stock?> GetWithCommentsByIdAsync(int id)
    {
        return _context.Stocks.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> StockExists(int id)
    {
        return await _context.Stocks.AnyAsync(p => p.Id == id);
    }
}
