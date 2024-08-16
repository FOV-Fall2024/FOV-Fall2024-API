using FluentResults;
using MediatR;

namespace FOV.Application.Features.Ingredients.Commands.CheckExpiredIngredient;

public sealed record CheckExpiredIngredientCommand : IRequest<Result>;
public class CheckExpiredIngredientHandler : IRequestHandler<CheckExpiredIngredientCommand, Result>
{
    public Task<Result> Handle(CheckExpiredIngredientCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
