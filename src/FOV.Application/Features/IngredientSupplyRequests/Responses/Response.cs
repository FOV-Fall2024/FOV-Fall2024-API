using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.IngredientSupplyRequests.Responses;
public sealed record SupplyRequestRespond(Guid Id, string RequestCode, DateTime CreatedDate,int Count);
public sealed record SupplyRequestRespond1(Guid Id, string RequestCode, List<SupplyRequestDetailRespond> Supplies);
public sealed record SupplyRequestDetailRespond(Guid IngredientId, string IngredientName);
