using FluentResults;
using MediatR;

namespace FOV.Application.Features.Combos.Queries.GetCombos;
public sealed record GetCombosCommand(string ComboName) : IRequest<Result>;
internal class GetCombosQuery
{
}
