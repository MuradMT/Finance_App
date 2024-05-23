namespace api.Validators.CommentValidator;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    public UpdateCommentDtoValidator()
    {
        RuleFor(x => x.Content).NotEmpty().WithMessage(ConstantMessages.Content_Not_Empty);
        RuleFor(x => x.Content).MinimumLength(5).WithMessage(ConstantMessages.Content_Min_Length);
        RuleFor(x => x.Content).MaximumLength(280).WithMessage(ConstantMessages.Content_Max_Length);

        RuleFor(x => x.Title).NotEmpty().WithMessage(ConstantMessages.Title_Not_Empty);
        RuleFor(x => x.Title).MinimumLength(5).WithMessage(ConstantMessages.Title_Min_Length);
        RuleFor(x => x.Title).MaximumLength(280).WithMessage(ConstantMessages.Title_Max_Length);
    }
}
