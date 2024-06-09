


namespace api.Repositories;

public class FMPRepository(HttpClient httpClient,IConfiguration configuration,IMapper _mapper) : IFMPRepository
{
    public async Task<Stock> FindStockBySymbol(string symbol)
    {
       try
       {
           var result=await httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={configuration["FMPKey"]}");
           if(result.IsSuccessStatusCode){
              var response=await result.Content.ReadAsStringAsync();
              var tasks= JsonSerializer.Deserialize<FMPStockDto[]>(response);
              var stock=tasks[0];
              if(stock is not null){
                 return _mapper.Map<Stock>(stock);
              }
              return null;
           }
           return null;
       }
       catch (Exception ex)
       {
          Console.WriteLine(ex);
          return null;
       }
    }
}
