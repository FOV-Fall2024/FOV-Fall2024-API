using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Application.Features.Combos.Reponses;

public sealed record GetCombosResponse(Guid Id, Guid RestaurantId, string ComboName, decimal ComboPrice,string ComboThumbnail, DateTime CreatedDate,Status Status);

