﻿namespace api.Dtos.Comment.Request;

public class CreateCommentDto:ICreateRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
