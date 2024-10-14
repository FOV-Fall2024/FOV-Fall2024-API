using FluentValidation;
using FOV.Application.Features.Dishes.Commons.Inactive;

namespace FOV.Application.Features.Dishes.Commons.Update;
public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator(CheckProductIdValidator idChecking)
    {
        RuleFor(x => x.ProductId).SetValidator(idChecking);
    }
}
