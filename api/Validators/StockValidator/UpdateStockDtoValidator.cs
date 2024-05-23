namespace api.Validators.StockValidator;

public class UpdateStockDtoValidator:AbstractValidator<UpdateStockDto>
{
      public UpdateStockDtoValidator()
      {
         RuleFor(x => x.Symbol)
            .NotEmpty().WithMessage(ConstantMessages.Symbol_Not_Empty)
            .MaximumLength(10).WithMessage(ConstantMessages.Symbol_Max_Length);

        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage(ConstantMessages.Company_Name_Not_Empty)
            .MaximumLength(10).WithMessage(ConstantMessages.Company_Name_Max_Length);

        RuleFor(x => x.Purchase)
            .NotEmpty().WithMessage(ConstantMessages.Purchase_Not_Empty)
            .InclusiveBetween(1, 1000000000).WithMessage(ConstantMessages.Purchase_Range);

        RuleFor(x => x.LastDiv)
            .NotEmpty().WithMessage(ConstantMessages.Last_Div_Not_Empty)
            .InclusiveBetween(0.001m, 100m).WithMessage(ConstantMessages.Last_Div_Range);

        RuleFor(x => x.Industry)
            .NotEmpty().WithMessage(ConstantMessages.Industry_Not_Empty)
            .MaximumLength(10).WithMessage(ConstantMessages.Industry_Max_Length);

        RuleFor(x => x.MarketCap)
            .NotEmpty().WithMessage(ConstantMessages.Market_Cap_Not_Empty)
            .InclusiveBetween(1, 5000000000).WithMessage(ConstantMessages.Market_Cap_Range);
      }
}
