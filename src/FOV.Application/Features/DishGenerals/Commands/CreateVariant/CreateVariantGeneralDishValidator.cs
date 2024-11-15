using Elastic.Clients.Elasticsearch;
using FluentValidation;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.CreateVariant;
public class CreateVariantGeneralDishValidator : AbstractValidator<CreateVariantGeneralDishCommand>
{
    public CreateVariantGeneralDishValidator(CheckDishGeneralId idRule)
    {
        RuleFor(command => command.GeneralDishId)
         .NotEmpty().WithMessage("ID là bắt buộc.")
         .SetValidator(idRule);
    }
}

public sealed class CheckDishGeneralId : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckDishGeneralId(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(id => id).MustAsync(CheckId).WithMessage("Không tìm thấy Id trong hệ thống");
    }

    private async Task<bool> CheckId(Guid id,CancellationToken token)
    {
        DishGeneral? dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(id);
        return dishGeneral != null;
    }
}
