namespace api.Interfaces.Repositories;

public interface IFMPRepository
{ 
     Task<Stock> FindStockBySymbol(string symbol);
}
