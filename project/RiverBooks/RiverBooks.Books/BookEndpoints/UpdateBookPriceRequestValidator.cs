using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.BookEndpoints;

public class UpdateBookPriceRequestValidator : Validator<UpdateBookPriceRequest>
{
    public UpdateBookPriceRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty)
            .WithMessage("Invalid Book Id.");
        
        RuleFor(x => x.NewPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Book Price must be greater than or equal to 0.");
    }
}
