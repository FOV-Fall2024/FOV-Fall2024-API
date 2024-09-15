using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Attendances.Commands.GenerateCheckInQRCode;
public record GenerateCheckInQRCodeCommand : IRequest<string>
{
    public Guid EmployeeId { get; set; }
    public DateTime CheckInTime { get; set; }
}
public class GenerateCheckinQRCodeHandler(IUnitOfWorks unitOfWorks, QRCodeGeneratorHandler qRCodeGeneratorHandler) : IRequestHandler<GenerateCheckInQRCodeCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly QRCodeGeneratorHandler _qRCodeGeneratorHandler = qRCodeGeneratorHandler;

    public Task<string> Handle(GenerateCheckInQRCodeCommand request, CancellationToken cancellationToken)
    {
        var employee = _unitOfWorks.EmployeeRepository.GetByIdAsync(request.EmployeeId) ?? throw new Exception("Employee not found!");
        return null;
    } 
}
