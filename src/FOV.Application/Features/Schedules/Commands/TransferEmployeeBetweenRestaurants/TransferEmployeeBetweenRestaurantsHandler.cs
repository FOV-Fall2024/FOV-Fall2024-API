using System;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Schedules.Commands.TransferEmployeeBetweenRestaurants
{
    public record TransferEmployeeBetweenRestaurantsCommand(Guid EmployeeId, Guid SourceRestaurantId, Guid DestinationRestaurantId) : IRequest<Guid>;

    public class TransferEmployeeBetweenRestaurantsHandler : IRequestHandler<TransferEmployeeBetweenRestaurantsCommand, Guid>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly UserManager<User> _userManager;

        public TransferEmployeeBetweenRestaurantsHandler(IUnitOfWorks unitOfWorks,UserManager<User> userManager)
        {
            _unitOfWorks = unitOfWorks;
            _userManager = userManager;
        }

        public async Task<Guid> Handle(TransferEmployeeBetweenRestaurantsCommand request, CancellationToken cancellationToken)
        {
            //var employee = await _unitOfWorks.EmployeeRepository.GetByIdAsync(request.EmployeeId);
            var employee = await _userManager.FindByIdAsync(request.EmployeeId.ToString());
            var fieldErrors = new List<FieldError>();

            #region Validation
            if (employee == null)
            {
                fieldErrors.Add(new FieldError
                {
                    Field = "employeeId",
                    Message = $"Employee with ID {request.EmployeeId} not found."
                });
            }

            var sourceRestaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.SourceRestaurantId);
            if (sourceRestaurant == null)
            {
                fieldErrors.Add(new FieldError
                {
                    Field = "sourceRestaurantId",
                    Message = $"Source restaurant with ID {request.SourceRestaurantId} not found."
                });
            }

            var destinationRestaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.DestinationRestaurantId);
            if (destinationRestaurant == null)
            {
                fieldErrors.Add(new FieldError
                {
                    Field = "destinationRestaurantId",
                    Message = $"Destination restaurant with ID {request.DestinationRestaurantId} not found."
                });
            }

            if (employee.RestaurantId != request.SourceRestaurantId)
            {
                throw new InvalidOperationException($"Employee is not assigned to the source restaurant with ID {request.SourceRestaurantId}.");
            }
            #endregion
            employee.RestaurantId = request.DestinationRestaurantId;
            await _userManager.UpdateAsync(employee);
           // _unitOfWorks.EmployeeRepository.Update(employee);

            await _unitOfWorks.SaveChangeAsync();

            return employee.Id;
        }
    }
}
