    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Threading;
    using System.Threading.Tasks;
    using FOV.Domain.Entities.OrderAggregator;
    using FOV.Domain.Entities.OrderAggregator.Enums;
    using FOV.Infrastructure.Caching.CachingService;
    using FOV.Infrastructure.Caching.ICachingService;
    using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
    using MediatR;

    namespace FOV.Application.Features.Orders.Commands.CreateOrder;

    public record OrderDetailDto(Guid? ComboId, Guid? ProductId, string Status, int Quantity, decimal Price);
    public record CreateOrderWithTableIdCommand(
        OrderType OrderType,
        DateTime OrderTime,
        decimal TotalPrice,
        List<OrderDetailDto> OrderDetails
    ) : IRequest<Guid>
    {
        [JsonIgnore]
        public OrderStatus OrderStatus = OrderStatus.Prepare;
        [JsonIgnore]
        public Guid TableId { get; set; }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderWithTableIdCommand, Guid>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CreateOrderHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<Guid> Handle(CreateOrderWithTableIdCommand request, CancellationToken cancellationToken)
        {
            string lockKey = $"order:table:{request.TableId}";
            //if (!await _lockingService.AcquireLockAsync())
            //{
            //    throw new Exception("Table is being used by another waiter");
            //};

            var order = new Domain.Entities.OrderAggregator.Order(request.OrderType, request.OrderTime, request.TotalPrice)
            {
                TableId = request.TableId,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var detail in request.OrderDetails)
            {
                var orderDetail = new OrderDetail(
                    detail.ComboId,
                    detail.ProductId,
                    null,
                    detail.Status,
                    detail.Quantity,
                    detail.Price
                );

                order.OrderDetails.Add(orderDetail);
            }

            await _unitOfWorks.OrderRepository.AddAsync(order);
            await _unitOfWorks.SaveChangeAsync();

            //if (request.OrderStatus == OrderStatus.Finish)
            //{
            //    await _lockingService.ReleaseLockAsync();
            //}

        return order.Id;
        }
    }
