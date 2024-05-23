
namespace api.Repositories;

public class StockRepository(ApplicationDbContext _context) : BaseRepository<Stock, ApplicationDbContext>(_context), IStockRepository
{

    public async Task<List<Stock>> GetAllWithCommentsAsync(StockQuery stockQuery)
    {
        var stocks = _context.Stocks.Include(p => p.Comments).AsQueryable();
        if (!string.IsNullOrWhiteSpace(stockQuery.CompanyName))
        {
            stocks = stocks.Where(p => p.CompanyName == stockQuery.CompanyName);
        }
        if (!string.IsNullOrWhiteSpace(stockQuery.Symbol))
        {
            stocks = stocks.Where(p => p.Symbol == stockQuery.Symbol);
        }
        return await stocks.ToListAsync();
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
