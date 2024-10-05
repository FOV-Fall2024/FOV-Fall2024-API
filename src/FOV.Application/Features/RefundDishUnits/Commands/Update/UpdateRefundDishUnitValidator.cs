using FluentValidation;
using FOV.Application.Features.RefundDishUnits.Commands.Create;
using FOV.Application.Features.RefundDishUnits.Commands.Remove;

namespace FOV.Application.Features.RefundDishUnits.Commands.Update;
public class UpdateRefundDishUnitValidator : AbstractValidator<UpdateRefundUnitCommand>
{
    public UpdateRefundDishUnitValidator(CheckNameExitValidator nameCheck, CheckRefundUnitIdValidator idCheck)
    {

        RuleFor(x => x.ConversionFactor)
               .InclusiveBetween(0, 1000)
               .WithMessage("Hệ số chuyển đổi phải nằm trong khoảng từ 0 đến 1000.");
        RuleFor(x => x.Id)
              .NotEmpty().WithMessage("ID không được để trống.")
              .MustAsync(async (id, token) => await idCheck.CheckId(id, token))
              .WithMessage("ID không tồn tại trong hệ thống.");
    }
}
