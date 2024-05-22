namespace api.Helpers;

public  class StockConverter:IConverter<Stock,UpdateStockDto>
{
   public  void Convert(Stock entity,UpdateStockDto dto){
    
        entity.Symbol = dto.Symbol;
        entity.CompanyName = dto.CompanyName;
        entity.Purchase = dto.Purchase;
        entity.LastDiv = dto.LastDiv;
        entity.Industry = dto.Industry;
        entity.MarketCap = dto.MarketCap;
   }
}
