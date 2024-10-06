using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.RefundDishUnits.Commands.Remove
{
    public class RemoveNewRefundDishUnitValidator : AbstractValidator<RemoveNewRefundDishUnitCommand>
    {
        private readonly CheckRefundUnitIdValidator _checkIdValidator;

        public RemoveNewRefundDishUnitValidator(CheckRefundUnitIdValidator checkIdValidator)
        {
            _checkIdValidator = checkIdValidator;

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID không được để trống.")
                .MustAsync(async (id, token) => await _checkIdValidator.CheckId(id, token))
                .WithMessage("ID không tồn tại trong hệ thống.");
        }
    }

    public sealed class CheckRefundUnitIdValidator : AbstractValidator<Guid>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CheckRefundUnitIdValidator(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<bool> CheckId(Guid id, CancellationToken token)
        {
            RefundDishUnit? unit = await _unitOfWorks.RefundDishUnitRepository.GetByIdAsync(id);
            return unit != null;
        }
    }
}
