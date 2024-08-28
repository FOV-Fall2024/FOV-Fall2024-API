﻿using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public interface IUnitOfWorks
{
    public IIngredientTypeRepository IngredientTypeRepository { get; }

    public IIngredientGeneralRepository IngredientGeneralRepository { get; }
    public ITableRepository TableRepository { get; }
    public IRestaurantRepository RestaurantRepository { get; }
    public IProductGeneralRepository ProductGeneralRepository { get; }
    public IProductIngredientGeneralRepository ProductIngredientGeneralRepository { get; }

    public IProductIngredientRepository ProductIngredientRepository { get; }
    public IProductRepository ProductRepository { get; }

    public IEmployeeRepository EmployeeRepository { get; }

    public ICustomerRepository CustomerRepository { get; }
    public IIngredientRepository IngredientRepository { get; }

    public ICategoryRepository CategoryRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderDetailRepository OrderDetailRepository { get; }
    public IShiftRepository ShiftRepository { get; }
    public IWaiterScheduleRepository WaiterScheduleRepository { get; }

    public IIngrdientTransactionRepository IngredientTransactionRepository { get; }

    public IProductComboRepository ProductComboRepository { get; }

    public IGroupChatRepository GroupChatRepository { get; }

    public IGroupMessageRepository GroupMessageRepository { get; }


    public IGroupUserRepository GroupUserRepository { get; }
    public IComboRepository ComboRepository { get; }

    public Task<int> SaveChangeAsync();
}
