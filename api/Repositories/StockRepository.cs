
namespace api.Repositories;

public class StockRepository(ApplicationDbContext _context): BaseRepository<Stock,ApplicationDbContext>(_context),IStockRepository
{
    
    public async Task<List<Stock>> GetAllWithCommentsAsync()
    {
       return await _context.Stocks.Include(p=>p.Comments).ToListAsync();
    }

    public Task<Stock?> GetWithCommentsByIdAsync(int id)
    {
        return _context.Stocks.Include(p=>p.Comments).FirstOrDefaultAsync(p=>p.Id==id);
    }
}
