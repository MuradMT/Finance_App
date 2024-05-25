namespace api.Models;
[Table("Comments")]

public class Comment:IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    [Column(TypeName = "datetime2(7)")]
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? StockId { get; set; }
    public Stock? Stock { get; set; }

    
}
