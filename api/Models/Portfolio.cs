namespace api.Models;

[Table("Portfolios")]
public class Portfolio:IEntity
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public int StockId { get; set; }
     
    public Stock Stock { get; set; }

}
