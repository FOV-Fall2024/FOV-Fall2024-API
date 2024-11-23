using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.WaiterSalaryAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Salaries.Commands.Update;
public sealed record UpdateSalaryCommand(SalaryType SalaryType, decimal BaseSalary) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; init; }
}
public class UpdateSalaryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateSalaryCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
    {
        var salary = await _unitOfWorks.SalaryRepository.GetByIdAsync(request.Id) ?? throw new AppException("Không có Id này");
        salary.UpdateSalary(request.SalaryType, request.BaseSalary);
        _unitOfWorks.SalaryRepository.Update(salary);
        await _unitOfWorks.SaveChangeAsync();
        return salary.Id;
    }
}
