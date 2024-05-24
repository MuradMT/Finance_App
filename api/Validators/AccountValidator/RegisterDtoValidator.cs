namespace api.Validators.AccountValidator;

public class RegisterDtoValidator:AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage(ConstantMessages.UserName_Not_Empty);
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ConstantMessages.Email_Not_Empty)
            .EmailAddress().WithMessage(ConstantMessages.Email_Format_Is_Not_Valid);

         RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ConstantMessages.Password_Not_Empty)
                .MinimumLength(12).WithMessage(ConstantMessages.Password_Min_Length)
                .Matches("[0-9]").WithMessage(ConstantMessages.Password_Require_Digit)
                .Matches("[a-z]").WithMessage(ConstantMessages.Password_Require_Lowercase)
                .Matches("[A-Z]").WithMessage(ConstantMessages.Password_Require_Uppercase)
                .Matches("[^a-zA-Z0-9]").WithMessage(ConstantMessages.Password_Require_NonAlphanumeric);
    }
}
