using System.Text.Json.Serialization;
using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientUnits.Commands.Update;

public sealed record UpdateIngredientUnitCommand(string UnitName, decimal ConversionFactor) : IRequest<Result>
{
    [JsonIgnore]
    public Guid IngredientUnitId { get; set; }
}

public class UpdateIngredientUnitHandler : IRequestHandler<UpdateIngredientUnitCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public UpdateIngredientUnitHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Result> Handle(UpdateIngredientUnitCommand request, CancellationToken cancellationToken)
    {
        // Field validation (manual)
        var fieldErrors = new List<FieldError>();

        // Validate UnitName
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
        else
        {
            // Check if the UnitName is unique
            if (!await IsUnitNameUniqueAsync(request.UnitName, request.IngredientUnitId))
            {
                fieldErrors.Add(new FieldError
                {
                    Field = char.ToLowerInvariant(nameof(request.UnitName)[0]) + nameof(request.UnitName).Substring(1),
                    Message = "Tên đơn vị phải là duy nhất."
                });
            }
        }

        // Validate ConversionFactor
        if (request.ConversionFactor <= 0)
        {
            fieldErrors.Add(new FieldError
            {
                Field = char.ToLowerInvariant(nameof(request.ConversionFactor)[0]) + nameof(request.ConversionFactor).Substring(1),
                Message = "Hệ số chuyển đổi phải lớn hơn 0."
            });
        }

        // Check if there are validation errors
        if (fieldErrors.Count != 0)
        {
            throw new AppException("Lỗi dữ liệu nhập vào", fieldErrors);
        }

        // Fetch the existing IngredientUnit by ID
        IngredientUnit? ingredientUnit = await _unitOfWorks.IngredientUnitRepository.GetByIdAsync(request.IngredientUnitId);
        if (ingredientUnit == null)
        {
            return Result.Fail("Không tìm thấy đơn vị nguyên liệu.");
        }

        // Update the ingredient unit with new data
        ingredientUnit.Update(request.UnitName, request.ConversionFactor);

        // Update in the repository
        _unitOfWorks.IngredientUnitRepository.Update(ingredientUnit);

        // Save changes
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }
    private async Task<bool> IsUnitNameUniqueAsync(string unitName, Guid ingredientUnitId)
    {
        // Fetch the current IngredientUnit being updated
        var currentIngredientUnit = await _unitOfWorks.IngredientUnitRepository.GetByIdAsync(ingredientUnitId);
        if (currentIngredientUnit == null)
        {
            throw new Exception("Ingredient Unit not found.");
        }

        // Fetch the ingredient associated with the current unit
        Ingredient ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(currentIngredientUnit.IngredientId, x => x.IngredientUnits) ?? throw new Exception("Ingredient not found.");

        // Check for any IngredientUnit with the same UnitName within the same Ingredient
        var existingUnit = ingredient.IngredientUnits
            .FirstOrDefault(ui =>
                ui.UnitName.Equals(unitName, StringComparison.OrdinalIgnoreCase) &&
                ui.Id != ingredientUnitId && ui.IngredientId == ingredient.Id); // Ignore the current unit being updated

        return existingUnit == null;
    }
}

