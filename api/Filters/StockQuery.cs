namespace api.Filters;

using System.Globalization;

public class StockQuery 
{
    // Your properties here
    public string? Symbol { get; set; } = null;
    public string? CompanyName { get; set; } = null;

    public string? SortBy { get; set; } = null;
    public bool isDescending { get; set; }

    public int Page { get; set; }
    public int PageSize { get; set; }

    public StockQuery(string symbol, string companyName,string sortBy,bool _isDescending,int page,int pageSize)=>
    (Symbol, CompanyName,SortBy,isDescending,Page,PageSize)=(symbol,companyName,sortBy,_isDescending,page,pageSize);
}