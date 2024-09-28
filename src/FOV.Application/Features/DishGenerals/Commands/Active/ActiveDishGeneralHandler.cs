using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Active;

public sealed record ActiveProductGeneralCommand(Guid id) : IRequest<Result>;
//public class ActiveProductGeneralHandler : IRequestHandler<Result>
//{

//}
