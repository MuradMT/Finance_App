namespace api.Dtos.Comment.Request;

public record UpdateCommentDto():IUpdateRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
}
