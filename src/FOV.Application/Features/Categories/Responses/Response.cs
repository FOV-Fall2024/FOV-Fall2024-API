namespace FOV.Application.Features.Categories.Reponses;


public sealed record GetParentCategoriesResponse(Guid Id, string CategoryName,DateTime CreatedDate);
