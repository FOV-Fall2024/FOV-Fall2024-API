using FluentValidation;
using FOV.Application.Features.Authorize.Commands.CreateEmployee;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Employees.Commands.CreateEmployee;
public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    //public CreateEmployeeValidator(RestaurantValidator validations)
    //{

    //    RuleFor(x => x.RoleId)
    //    .NotEmpty()
    //    .When(x => x.RoleId >= 1 && x.RoleId <= 3);
    //    RuleFor(x => x.Email)
    //         .NotNull()
    //         .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
    //         .WithMessage("Email không hợp lệ.");
    //    RuleFor(x => x.RestaurantId).SetValidator(validations);


    //}
}


public sealed class RestaurantValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public RestaurantValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(id => id).MustAsync(CheckIsExistId).WithMessage("Không tìm thấy nhà hàng");
    }

    private async Task<bool> CheckIsExistId(Guid restaurantId, CancellationToken token)
    {
        Restaurant? restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(restaurantId);
        return restaurant != null;
    }
}


