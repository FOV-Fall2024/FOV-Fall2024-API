using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Combos.Queries.GetComboDetail;
public class GetComboDetailValidator : AbstractValidator<GetComboDetailCommand>
{
    public GetComboDetailValidator(ComboIdValidator comboId)
    {
        RuleFor(x => x.Id).SetValidator(comboId);
    }
}

public sealed class ComboIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public ComboIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<bool> CheckId(Guid id, CancellationToken token)
    {
        Combo? combo = await _unitOfWorks.ComboRepository.GetByIdAsync(id);
        return combo != null;
    }
}
