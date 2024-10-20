using FOV.Domain.DTOs;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Queries.GetComboDetail;
public sealed record GetComboDetailCommand(Guid Id) : IRequest<GetComboDetailResponse>;

public class GetComboDetailHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetComboDetailCommand, GetComboDetailResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetComboDetailResponse> Handle(GetComboDetailCommand request, CancellationToken cancellationToken)
    {

        return await _unitOfWorks.ComboRepository.GetComboDetail(request.Id);
    }
}
