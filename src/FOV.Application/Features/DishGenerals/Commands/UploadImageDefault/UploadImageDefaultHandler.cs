using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FOV.Application.Features.DishGenerals.Commands.UploadImageDefault;
public sealed record UploadImageDefaultCommand : IRequest<string>
{
    public required IFormFile Image { get; set; }
}
public class UploadImageDefaultHandler(StorageHandler storageHandler) : IRequestHandler<UploadImageDefaultCommand, string>
{
    private readonly StorageHandler _storageHandler = storageHandler;
    public async Task<string> Handle(UploadImageDefaultCommand request, CancellationToken cancellationToken)
    {
        if (request.Image == null)
        {
            throw new ArgumentNullException("ImageDefault and Ingredients are required.");
        }

        StorageFile storageFile = await _storageHandler.UploadImageAsync(request.Image, "ProductImage");

        return storageFile.FileName;
    }
}
