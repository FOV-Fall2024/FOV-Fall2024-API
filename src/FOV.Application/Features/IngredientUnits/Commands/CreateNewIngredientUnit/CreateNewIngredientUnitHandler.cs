using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientUnits.Commands.CreateNewIngredientUnit;

public sealed record CreateNewIngredientUnitCommand(string UnitName, decimal ConversionFactor, Guid IngredientUnitParentId, Guid IngredientId) : IRequest<Result>;

public class CreateNewIngredientUnitHandler : IRequestHandler<CreateNewIngredientUnitCommand, Result>
{
    private readonly IClaimService _claimService;
    private readonly IUnitOfWorks _unitOfWorks;

    public CreateNewIngredientUnitHandler(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _claimService = claimService;
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Result> Handle(CreateNewIngredientUnitCommand request, CancellationToken cancellationToken)
    {
        // Manual validation checks
        var fieldErrors = new List<FieldError>();

        // Check UnitName
        if (string.IsNullOrWhiteSpace(request.UnitName))
        {
            fieldErrors.Add(new FieldError
            {
                Field = char.ToLowerInvariant(nameof(request.UnitName)[0]) + nameof(request.UnitName).Substring(1),
                Message = "Tên đơn vị không được để trống."
            });
        }
        else if (request.UnitName.Length < 1 || request.UnitName.Length > 100)
        {
            fieldErrors.Add(new FieldError
            {
                Field = char.ToLowerInvariant(nameof(request.UnitName)[0]) + nameof(request.UnitName).Substring(1),
                Message = "Tên đơn vị phải từ 1 đến 100 ký tự."
            });
        }

        // Check ConversionFactor
        if (request.ConversionFactor <= 0)
        {
            fieldErrors.Add(new FieldError
            {
                Field = char.ToLowerInvariant(nameof(request.ConversionFactor)[0]) + nameof(request.ConversionFactor).Substring(1),
                Message = "Hệ số chuyển đổi phải lớn hơn 0."
            });
        }

        // Check IngredientUnitParentId
        if (request.IngredientUnitParentId == Guid.Empty)
        {
            fieldErrors.Add(new FieldError
            {
                Field = nameof(request.IngredientUnitParentId),
                Message = "Mã đơn vị cha không được để trống."
            });
        }

        // Check IngredientId
        if (request.IngredientId == Guid.Empty)
        {
            fieldErrors.Add(new FieldError
            {
                Field = char.ToLowerInvariant(nameof(request.IngredientId)[0]) + nameof(request.IngredientId).Substring(1),
                Message = "Mã nguyên liệu không được để trống."
            });
        }

        // Business logic validation: Check if the UnitName is unique
        bool isNameUnique = await IsNameUnique(request, cancellationToken);
        if (!isNameUnique)
        {
            fieldErrors.Add(new FieldError
            {
                Field = char.ToLowerInvariant(nameof(request.UnitName)[0]) + nameof(request.UnitName).Substring(1),
                Message = "Tên đơn vị đã tồn tại trong hệ thống."
            });
        }
        // If there are validation errors, throw exception
        if (fieldErrors.Any())
        {
            throw new AppException("Lỗi dữ liệu nhập vào", fieldErrors);
        }


        // Proceed with creating the ingredient unit
        IngredientUnit ingredientUnit = new(request.UnitName, request.IngredientId, request.IngredientUnitParentId, request.ConversionFactor);
        await _unitOfWorks.IngredientUnitRepository.AddAsync(ingredientUnit);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }

    private async Task<bool> IsNameUnique(CreateNewIngredientUnitCommand request, CancellationToken cancellationToken)
    {
        List<IngredientUnit> allIngredientUnits = await _unitOfWorks.IngredientUnitRepository
            .WhereAsync(x => x.IngredientId == request.IngredientId);

        return allIngredientUnits.All(x => x.UnitName != request.UnitName);
    }
}
