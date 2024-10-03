using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.Dishes.Responses;

public sealed record GetProductResponse(Guid Id, string ProductName, string ProductDescription);

public sealed record GetMenuResponse(Guid Id, string ProductName, string ProductDescription);


