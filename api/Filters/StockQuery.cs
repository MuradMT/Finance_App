namespace api.Filters;

public record StockQuery
{
    public string? Symbol { get; set; } = null;
    public string? CompanyName { get; set; } = null;

    public StockQuery(string symbol, string companyName)=>(Symbol, CompanyName)=(symbol,companyName);

}
