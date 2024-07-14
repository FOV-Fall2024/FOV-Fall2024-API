using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.IngredientTypes.Commands.CreateIngredientType;

public  record CreateIngredientTypeCommand(string Name, string Description) : IRequest<Guid>;
