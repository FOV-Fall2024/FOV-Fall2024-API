using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Commands.CheckExpiredIngredient;

public sealed record CheckExpiredIngredientCommand : IRequest<Result>;
public class CheckExpiredIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CheckExpiredIngredientCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public Task<Result> Handle(CheckExpiredIngredientCommand request, CancellationToken cancellationToken)
    {
        //? Get All Ingredient follow ingredienet have exprired Date and Check it is alredy have in exprired
        //? Ví dụ hàng nhập ngày 2 thì một đợt hết 1 đợt chưa xử lý


    }
}
