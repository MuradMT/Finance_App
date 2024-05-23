namespace api.Dtos.Stock.Request;

public record CreateStockDto:ICreateRequestDto
{
    public string Symbol { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public decimal Purchase { get; set; }
    public decimal LastDiv { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
}
//Alternative record representation
// public record CreateStockDto(decimal Purchase,decimal LastDiv,long MarketCap):ICreateRequestDto;