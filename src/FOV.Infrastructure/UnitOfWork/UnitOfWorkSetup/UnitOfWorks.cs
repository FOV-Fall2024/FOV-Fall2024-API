using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using FOV.Infrastructure.Repository.Repositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly FOVContext _context;
    private readonly IIngredientTypeRepository _ingredientTypeRepository;
    private readonly IIngredientGeneralRepository _ingredientGeneralRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IDishGeneralRepository _productGeneralRepository;
    private readonly IDishIngredientGeneralRepository _productIngredientGeneralRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IDishRepository _productRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IDishIngredientRepository _productIngredientRepository;
    private readonly IIngrdientTransactionRepository _ingrdientTransactionRepository;
    private readonly IDishComboRepository _productComboRepository;
    private readonly IComboRepository _comboRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IShiftRepository _shiftRepository;
    private readonly IWaiterScheduleRepository _waiterScheduleRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IIngredientUnitRepository _ingredientUnitRepository;
    private readonly IRefundDishInventoryRepository _refundDishInventoryRepository;
    private readonly IRefundDishInventoryTransactionRepository _refundDishInventoryTransactionRepository;
    private readonly IDishGeneralImageRepository _dishGeneralImageRepository;
    private readonly IngredientRequestRepository _ingredientRequestRepository;
    private readonly IngredientRequestDetailRepository _ingredientRequestDetailRepository;

    public UnitOfWorks(FOVContext context, IIngredientTypeRepository ingredientTypeRepository, IIngredientGeneralRepository ingredientGeneralRepository, IDishGeneralRepository productGeneralRepository, IDishIngredientGeneralRepository productIngredientGeneralRepository, ITableRepository tableRepository, IRestaurantRepository restaurantRepository, ICategoryRepository categoryRepository, IDishRepository productRepository, IIngredientRepository ingredientRepository, IDishIngredientRepository productIngredientRepository, IIngrdientTransactionRepository ingredientTransactionRepository, IDishComboRepository productComboRepository, IComboRepository comboRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IShiftRepository shiftRepository, IWaiterScheduleRepository waiterScheduleRepository,
        IRatingRepository ratingRepository, IPaymentRepository paymentRepository, IAttendanceRepository attendanceRepository, IIngredientUnitRepository ingredientUnitRepository, IRefundDishInventoryRepository refundDishInventoryRepository, IRefundDishInventoryTransactionRepository refundDishInventoryTransactionRepository, IDishGeneralImageRepository dishGeneralImageRepository, IngredientRequestDetailRepository ingredientRequestDetailRepository,IngredientRequestRepository ingredientRequestRepository)
    {
        _context = context;
        _ingredientTypeRepository = ingredientTypeRepository;
        _ingredientGeneralRepository = ingredientGeneralRepository;
        _tableRepository = tableRepository;
        _restaurantRepository = restaurantRepository;
        _productGeneralRepository = productGeneralRepository;
        _productIngredientGeneralRepository = productIngredientGeneralRepository;
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _ingredientRepository = ingredientRepository;
        _productIngredientRepository = productIngredientRepository;
        _ingrdientTransactionRepository = ingredientTransactionRepository;
        _productComboRepository = productComboRepository;
        _comboRepository = comboRepository;
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _shiftRepository = shiftRepository;
        _waiterScheduleRepository = waiterScheduleRepository;
        _ratingRepository = ratingRepository;
        _paymentRepository = paymentRepository;
        _attendanceRepository = attendanceRepository;
        _ingredientUnitRepository = ingredientUnitRepository;
        _attendanceRepository = attendanceRepository;
        _refundDishInventoryRepository = refundDishInventoryRepository;
        _refundDishInventoryTransactionRepository = refundDishInventoryTransactionRepository;
        _dishGeneralImageRepository = dishGeneralImageRepository;
        _ingredientRequestDetailRepository = ingredientRequestDetailRepository;
        _ingredientRequestRepository = ingredientRequestRepository;
    }
    public IIngredientTypeRepository IngredientTypeRepository => _ingredientTypeRepository;
    public IIngredientGeneralRepository IngredientGeneralRepository => _ingredientGeneralRepository;
    public ITableRepository TableRepository => _tableRepository;
    public IRestaurantRepository RestaurantRepository => _restaurantRepository;

    public IDishGeneralRepository DishGeneralRepository => _productGeneralRepository;

    public IDishIngredientGeneralRepository DishIngredientGeneralRepository => _productIngredientGeneralRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository;

    public IDishRepository DishRepository => _productRepository;

    public IIngredientRepository IngredientRepository => _ingredientRepository;

    public IDishIngredientRepository DishIngredientRepository => _productIngredientRepository;


    public IIngrdientTransactionRepository IngredientTransactionRepository => _ingrdientTransactionRepository;

    public IDishComboRepository DishComboRepository => _productComboRepository;

    public IComboRepository ComboRepository => _comboRepository;

    public IOrderRepository OrderRepository => _orderRepository;

    public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
    public IShiftRepository ShiftRepository => _shiftRepository;
    public IWaiterScheduleRepository WaiterScheduleRepository => _waiterScheduleRepository;


    public IPaymentRepository PaymentRepository => _paymentRepository;

    public IAttendanceRepository AttendanceRepository => _attendanceRepository;

    public IIngredientUnitRepository IngredientUnitRepository => _ingredientUnitRepository;
    public IRefundDishInventoryRepository RefundDishInventoryRepository => _refundDishInventoryRepository;


    public IRefundDishInventoryTransactionRepository RefundDishInventoryTransactionRepository => _refundDishInventoryTransactionRepository;

    public IDishGeneralImageRepository DishGeneralImageRepository => _dishGeneralImageRepository;

    public IIngredientRequestRepository IngredientRequestRepository => _ingredientRequestRepository;

    public IIngredientRequestDetailRepository IngredientRequestDetailRepository => _ingredientRequestDetailRepository;

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
