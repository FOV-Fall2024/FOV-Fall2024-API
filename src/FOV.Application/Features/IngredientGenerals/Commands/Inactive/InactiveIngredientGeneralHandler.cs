using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Commands.Inactive;

public sealed record InactiveIngredientGeneralCommand(Guid Id) : IRequest<Result>;

public class InactiveIngredientGeneralHandler : IRequestHandler<InactiveIngredientGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public InactiveIngredientGeneralHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Result> Handle(InactiveIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        if (!await CheckIngredient(request.Id))
        {
            throw new AppException("Không thể xóa nguyên liệu này", new List<FieldError>
            {
                new() {
                    Field = "ingredientGeneralId",
                    Message = "Nguyên liệu này không thể xóa vì đã được một số nhà hàng sử dụng."
                }
            });
        }

        IngredientGeneral ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id)
            ?? throw new AppException("Nguyên liệu không tồn tại.");

        ingredientGeneral.UpdateState(false);
        _unitOfWorks.IngredientGeneralRepository.Update(ingredientGeneral);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }


    public async Task<bool> CheckIngredient(Guid id)
    {
        var ingredients = await _unitOfWorks.DishIngredientGeneralRepository
            .WhereAsync(x => x.IngredientGeneralId == id);

        // Check if the collection is empty
        return ingredients.Count == 0;
    }
}
