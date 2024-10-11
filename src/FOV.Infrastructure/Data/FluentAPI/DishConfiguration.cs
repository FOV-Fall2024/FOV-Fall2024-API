using FOV.Domain.Common;
using FOV.Domain.Entities.DishAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.DishCombos).WithOne(x => x.Dish).HasForeignKey(x => x.DishId);
        builder.HasMany(x => x.OrderDetails).WithOne(x => x.Dish).HasForeignKey(x => x.ProductId);
        builder.HasMany(x => x.DishImages).WithOne(x => x.Dish).HasForeignKey(x => x.DishId);
        
        //builder.HasData(new Dish
        //{
        //    Id = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540c3"),
        //    CategoryId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
        //    DishName = "7up",
        //    Price = 10000,
        //    DishDescription = "Description",
        //    DishGeneralId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
        //    RestaurantId = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
        //    Created = DefaultDatetime.MinValue,
        //    LastModified = DefaultDatetime.MinValue,
        //},
        //new Dish
        //{
        //    Id = Guid.Parse("e311d82d-452c-4603-a029-762a2a4e5e19"),
        //    CategoryId = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),
        //    DishName = "Lẩu chay Thủ Đức",
        //    Price = 60000,
        //    DishDescription = "Siêu rẻ",
        //    DishGeneralId = Guid.Parse("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
        //    RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
        //    Created = DefaultDatetime.MinValue,
        //    LastModified = DefaultDatetime.MinValue,
        //},
        //new Dish
        //{
        //    Id = Guid.Parse("9d40c875-bd7f-403a-9734-c7b5dbba5e78"),
        //    CategoryId = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),
        //    DishName = "Cơm Không",
        //    Price = 20000,
        //    DishDescription = "Description",
        //    DishGeneralId = Guid.Parse("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
        //    RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
        //    Created = DefaultDatetime.MinValue,
        //    LastModified = DefaultDatetime.MinValue,
            
        //}
        //);
    }
}
