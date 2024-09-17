using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly FOVContext _context;
    private readonly IIngredientTypeRepository _ingredientTypeRepository;
    private readonly IIngredientGeneralRepository _ingredientGeneralRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IProductGeneralRepository _productGeneralRepository;
    private readonly IProductIngredientGeneralRepository _productIngredientGeneralRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IProductIngredientRepository _productIngredientRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IIngrdientTransactionRepository _ingrdientTransactionRepository;
    private readonly IProductComboRepository _productComboRepository;
    private readonly IComboRepository _comboRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IShiftRepository _shiftRepository;
    private readonly IWaiterScheduleRepository _waiterScheduleRepository;
    private readonly IGroupUserRepository _groupUserRepository;
    private readonly IGroupMessageRepository _groupMessageRepository;
    private readonly IGroupChatRepository _groupChatRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IIngredientUnitRepository _ingredientUnitRepository;

    public UnitOfWorks(FOVContext context, IIngredientTypeRepository ingredientTypeRepository, IIngredientGeneralRepository ingredientGeneralRepository, IProductGeneralRepository productGeneralRepository, IProductIngredientGeneralRepository productIngredientGeneralRepository, ITableRepository tableRepository, IRestaurantRepository restaurantRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, IIngredientRepository ingredientRepository, IProductIngredientRepository productIngredientRepository, ICustomerRepository customerRepository, IEmployeeRepository employeeRepository, IIngrdientTransactionRepository ingrdientTransactionRepository, IProductComboRepository productComboRepository, IComboRepository comboRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IShiftRepository shiftRepository, IWaiterScheduleRepository waiterScheduleRepository,
        IGroupChatRepository groupChatRepository, IGroupMessageRepository groupMessageRepository, IGroupUserRepository groupUserRepository,
        IProductImageRepository productImageRepository,
        IRatingRepository ratingRepository, IPaymentRepository paymentRepository, IAttendanceRepository attendanceRepository,IIngredientUnitRepository ingredientUnitRepository)
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
        _customerRepository = customerRepository;
        _employeeRepository = employeeRepository;
        _ingrdientTransactionRepository = ingrdientTransactionRepository;
        _productComboRepository = productComboRepository;
        _comboRepository = comboRepository;
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _shiftRepository = shiftRepository;
        _waiterScheduleRepository = waiterScheduleRepository;
        _groupChatRepository = groupChatRepository;
        _groupMessageRepository = groupMessageRepository;
        _groupUserRepository = groupUserRepository;
        _productImageRepository = productImageRepository;
        _ratingRepository = ratingRepository;
        _paymentRepository = paymentRepository;
        _attendanceRepository = attendanceRepository;
        _ingredientUnitRepository = ingredientUnitRepository;
        _attendanceRepository = attendanceRepository;
    }
    public IIngredientTypeRepository IngredientTypeRepository => _ingredientTypeRepository;
    public IIngredientGeneralRepository IngredientGeneralRepository => _ingredientGeneralRepository;
    public ITableRepository TableRepository => _tableRepository;
    public IRestaurantRepository RestaurantRepository => _restaurantRepository;

    public IProductGeneralRepository ProductGeneralRepository => _productGeneralRepository;

    public IProductIngredientGeneralRepository ProductIngredientGeneralRepository => _productIngredientGeneralRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository;

    public IProductRepository ProductRepository => _productRepository;

    public IIngredientRepository IngredientRepository => _ingredientRepository;

    public IProductIngredientRepository ProductIngredientRepository => _productIngredientRepository;

    public IEmployeeRepository EmployeeRepository => _employeeRepository;

    public ICustomerRepository CustomerRepository => _customerRepository;

    public IIngrdientTransactionRepository IngredientTransactionRepository => _ingrdientTransactionRepository;

    public IProductComboRepository ProductComboRepository => _productComboRepository;

    public IComboRepository ComboRepository => _comboRepository;

    public IOrderRepository OrderRepository => _orderRepository;

    public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository;
    public IShiftRepository ShiftRepository => _shiftRepository;
    public IWaiterScheduleRepository WaiterScheduleRepository => _waiterScheduleRepository;

    public IGroupChatRepository GroupChatRepository => _groupChatRepository;

    public IGroupMessageRepository GroupMessageRepository => _groupMessageRepository;

    public IGroupUserRepository GroupUserRepository => _groupUserRepository;

    public IProductImageRepository ProductImageRepository => _productImageRepository;

    public IPaymentRepository PaymentRepository => _paymentRepository;

    public IAttendanceRepository AttendanceRepository => _attendanceRepository;

    public IIngredientUnitRepository IngredientUnitRepository => _ingredientUnitRepository;

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
