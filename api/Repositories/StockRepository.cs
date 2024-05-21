namespace api.Repositories;

public class StockRepository: BaseRepository<Stock,ApplicationDbContext>,IStockRepository
{
    
    public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

}
