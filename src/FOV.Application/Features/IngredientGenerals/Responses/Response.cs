using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.IngredientGenerals.Responses;

public record GetAllIngredientResponse(Guid Id, string IngredientName, string IngredientType, string IngredientDescription, Status Status);

