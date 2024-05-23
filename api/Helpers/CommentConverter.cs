namespace api.Helpers;

public record CommentConverter : IConverter<Comment, UpdateCommentDto>
{
    public void Convert(Comment entity, UpdateCommentDto dto)
    {
        
    }
}
