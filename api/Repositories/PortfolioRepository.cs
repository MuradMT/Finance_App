
namespace api.Repositories;

public class PortfolioRepository(ApplicationDbContext _context) : IPortfolioRepository
{
    public async Task<List<Stock>> GetUserPortfolio(AppUser user)
    {
        return await _context.Portfolios.Where(p=>p.AppUserId==user.Id)
        .Select(stock=> 
            new Stock(){
                Id=stock.StockId,
                Symbol=stock.Stock.Symbol,
                CompanyName=stock.Stock.CompanyName,
                Purchase=stock.Stock.Purchase,
                LastDiv=stock.Stock.LastDiv,
                Industry=stock.Stock.Industry,
                MarketCap=stock.Stock.MarketCap
        }).ToListAsync();

    }
}
