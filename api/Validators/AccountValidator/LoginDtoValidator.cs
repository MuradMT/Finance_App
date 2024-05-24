namespace api.Validators.AccountValidator;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.UserName_or_Email)
            .NotEmpty().WithMessage(ConstantMessages.Email_Or_UserName_Not_Empty);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(ConstantMessages.Password_Not_Empty);
    }
}