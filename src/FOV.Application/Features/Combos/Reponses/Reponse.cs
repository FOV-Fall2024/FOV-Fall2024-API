using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.Combos.Reponses;

public sealed record GetCombosResponse(Guid Id, Guid RestaurantId, string ComboName, int Quantity, decimal Price, DateTimeOffset ExpiredDate);

