﻿using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public interface IUnitOfWorks
{

    public IIngredientTypeRepository IngredientTypeRepository { get; }

    public IIngredientGeneralRepository IngredientGeneralRepository { get; }
    public ITableRepository TableRepository { get; }
    public IRestaurantRepository RestaurantRepository { get; }
    public IDishGeneralRepository DishGeneralRepository { get; }
    public IDishIngredientGeneralRepository DishIngredientGeneralRepository { get; }

    public IDishIngredientRepository DishIngredientRepository { get; }
    public IDishRepository DishRepository { get; }

    public IEmployeeRepository EmployeeRepository { get; }

    public ICustomerRepository CustomerRepository { get; }
    public IIngredientRepository IngredientRepository { get; }

    public ICategoryRepository CategoryRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderDetailRepository OrderDetailRepository { get; }
    public IShiftRepository ShiftRepository { get; }
    public IWaiterScheduleRepository WaiterScheduleRepository { get; }

    public IIngrdientTransactionRepository IngredientTransactionRepository { get; }

    public IDishComboRepository DishComboRepository { get; }

    public IGroupChatRepository GroupChatRepository { get; }

    public IGroupMessageRepository GroupMessageRepository { get; }


    public IGroupUserRepository GroupUserRepository { get; }
    public IComboRepository ComboRepository { get; }
    public IPaymentRepository PaymentRepository { get; }
    public IAttendanceRepository AttendanceRepository { get; }

    public IIngredientUnitRepository IngredientUnitRepository { get; }


    public INewDishRecommendLogRepository NewDishRecommendLogRepository { get; }

    public INewDishRecommendRepository NewDishRecommendRepository { get; }

    public IRefundDishInventoryRepository RefundDishInventoryRepository { get; }


    public IRefundDishInventoryTransactionRepository RefundDishInventoryTransactionRepository { get; }

    public IDishGeneralImageRepository DishGeneralImageRepository { get; }

    public Task<int> SaveChangeAsync();
}
