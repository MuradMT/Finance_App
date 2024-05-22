namespace api.Helpers;

public class CommentConverter : IConverter<Comment, UpdateCommentDto>
{
    public void Convert(Comment entity, UpdateCommentDto dto)
    {
        entity.StockId = dto.StockId;
        entity.Content = dto.Content;
        entity.CreatedOn = dto.CreatedOn;
        entity.Title = dto.Title;
    }
}
