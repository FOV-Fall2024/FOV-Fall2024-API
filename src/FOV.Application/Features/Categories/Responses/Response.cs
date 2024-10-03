using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.Categories.Reponses;


public sealed record GetParentCategoriesResponse(Guid Id, string CategoryName);
