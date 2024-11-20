using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json.Serialization;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.Create;

public record CreateTableCommand(Guid RestaurantId, int Amount) : IRequest<List<Guid>>
{
    [JsonIgnore]
    public TableStatus Status { get; set; } = TableStatus.Available;
}
public class CreateTableHandler(IUnitOfWorks unitOfWorks, StorageHandler storageHandler, QRCodeGeneratorHandler qrCodeGeneratorHandler) : IRequestHandler<CreateTableCommand, List<Guid>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly StorageHandler _storageHandler = storageHandler;
    private readonly QRCodeGeneratorHandler _qrCodeGeneratorHandler = qrCodeGeneratorHandler;

    public async Task<List<Guid>> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        var tableIds = new List<Guid>();
        int nextTableNumber = await GetNextTableNumberAsync(request.RestaurantId);

        for (int i = 0; i < request.Amount; i++)
        {
            Table table = new(request.Status)
            {
                RestaurantId = request.RestaurantId,
                TableNumber = nextTableNumber + i,
                TableStatus = TableStatus.Available
            };
            await _unitOfWorks.TableRepository.AddAsync(table);
            tableIds.Add(table.Id);
        }

        await _unitOfWorks.SaveChangeAsync();
        return tableIds;
    }

    private async Task<int> GetNextTableNumberAsync(Guid restaurantId)
    {
        var highestTableNumber = await _unitOfWorks.TableRepository
            .GetHighestTableNumberAsync(restaurantId);

        return (highestTableNumber ?? 0) + 1;
    }
}
