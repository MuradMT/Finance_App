namespace api.Interfaces.Repositories;

public interface IPortfolioRepository
{
    Task<List<Stock>> GetUserPortfolio(AppUser user);
}
