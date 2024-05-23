namespace api.Filters;

using System.Globalization;

public class StockQuery 
{
    // Your properties here
    public string? Symbol { get; set; } = null;
    public string? CompanyName { get; set; } = null;

    public string? SortBy { get; set; } = null;
    public bool isDescending { get; set; } = false;

    public StockQuery(string symbol, string companyName,string sortBy,bool _isDescending)=>
    (Symbol, CompanyName,SortBy,isDescending)=(symbol,companyName,sortBy,_isDescending);
}