namespace api.Helpers;

public  class StockConverter:IConverter<Stock,UpdateStockDto>
{
   public  void Convert(Stock stock,UpdateStockDto stockDto){
    
        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.Purchase = stockDto.Purchase;
        stock.LastDiv = stockDto.LastDiv;
        stock.Industry = stockDto.Industry;
        stock.MarketCap = stockDto.MarketCap;
   }
}
