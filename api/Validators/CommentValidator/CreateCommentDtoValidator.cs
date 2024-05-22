namespace api.Validators.CommentValidator;

public class CreateCommentDtoValidator:AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator()
    {
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x=>x.Content).MinimumLength(3).WithMessage("Content length must be at least 3 characters");
    }
}
