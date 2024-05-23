namespace api.Helpers;

public record CommentConverter : IConverter<Comment, UpdateCommentDto>
{
    public void Convert(Comment entity, UpdateCommentDto dto)
    {
        entity.Title = dto.Title;
        entity.Content = dto.Content;
    }
}
