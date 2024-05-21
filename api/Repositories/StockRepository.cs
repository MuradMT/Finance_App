using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class StockRepository: BaseRepository<Stock,ApplicationDbContext>,IStockRepository
{
    
    public StockRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

}
