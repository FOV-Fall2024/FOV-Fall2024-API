using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.RefundDishUnits.Commands.Create
{
    public class CreateNewRefundDishUnitValidator : AbstractValidator<CreateNewRefundDishUnitCommand>
    {
        public CreateNewRefundDishUnitValidator(
            CheckRefundDishInventoryIdValidator checkIdValidator,
            CheckNameExitValidator checkNameValidator)
        {
            RuleFor(x => x.RefundDishInventoryId)
                .NotEmpty()
                .MustAsync(async (id, token) => await checkIdValidator.CheckId(id, token))
                .WithMessage("ID này không tồn tại trong hệ thống.");

            RuleFor(x => x.ConversionFactor)
                .InclusiveBetween(0, 1000)
                .WithMessage("Hệ số chuyển đổi phải nằm trong khoảng từ 0 đến 1000.");

            RuleFor(x => x.UnitName)
                .MustAsync(async (command, unitName, token) =>
                    await checkNameValidator.CheckName(unitName, command.RefundDishInventoryId, token))
                .WithMessage("Tên đơn vị đã tồn tại cho kho này.");
        }
    }

    public class CheckRefundDishInventoryIdValidator : AbstractValidator<Guid>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CheckRefundDishInventoryIdValidator(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<bool> CheckId(Guid id, CancellationToken token)
        {
            RefundDishInventory? inventory = await _unitOfWorks.RefundDishInventoryRepository.GetByIdAsync(id);
            return inventory != null;
        }
    }

    public sealed class CheckNameExitValidator : AbstractValidator<string>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CheckNameExitValidator(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<bool> CheckName(string name, Guid inventoryId, CancellationToken token)
        {
            RefundDishUnit? unit = await _unitOfWorks.RefundDishUnitRepository
                .FirstOrDefaultAsync(x => x.UnitName == name && x.RefundDishInventoryId == inventoryId);
            return unit == null; // Trả về true nếu tên không tồn tại
        }
    }
}
