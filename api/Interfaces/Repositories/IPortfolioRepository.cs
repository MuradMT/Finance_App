namespace api.Interfaces.Repositories;

public interface IPortfolioRepository:IRepository<Portfolio>
{
    Task<List<Stock>> GetUserPortfolio(AppUser user);
    Task<Portfolio> DeletePortfolio(AppUser user, string symbol);
}
