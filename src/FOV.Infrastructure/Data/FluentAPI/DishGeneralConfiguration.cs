using FOV.Domain.Common;
using FOV.Domain.Entities.DishGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FOV.Infrastructure.Data.FluentAPI;

public class DishGeneralConfiguration : IEntityTypeConfiguration<DishGeneral>
{
    public void Configure(EntityTypeBuilder<DishGeneral> builder)
    {
        builder.HasMany(x => x.Dishes).WithOne(x => x.DishGeneral).HasForeignKey(x => x.DishGeneralId);
        builder.HasMany(x => x.Ingredients).WithOne(x => x.DishGeneral).HasForeignKey(x => x.DishGeneralId);
        builder.HasKey(x => x.Id);
        builder.HasData(
            new DishGeneral()
            {
                Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c012"),
                CategoryId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
                DishName = "Coca-Cola",
                DishDescription = "Coca-Cola ngon ",
                IsDeleted = false,
                Created = DefaultDatetime.MinValue,
                LastModified = DefaultDatetime.MinValue,
            },
             new DishGeneral()
             {
                 Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c013"),
                 CategoryId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c011"),
                 DishName = "7up",
                 DishDescription = "7up ngon ",
                 IsDeleted = false,
                 Created = DefaultDatetime.MinValue,
                 LastModified = DefaultDatetime.MinValue,
             },
             new DishGeneral()
             {
                 Id = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
                 CategoryId = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),
                 DishName = " Caprese Salad",
                 DishDescription = " Caprese Salad ngon ",
                 IsDeleted = false,
                 Created = DefaultDatetime.MinValue,
                 LastModified = DefaultDatetime.MinValue,
             },
             new DishGeneral()
             {
                 Id = Guid.Parse("2b9941ee-2f72-4417-8a0a-2e14a6d00fbb"),
                 CategoryId = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),
                 DishName = "Vegan Hotpot",
                 DishDescription = "Lẩu chay ngon",
                 IsDeleted = false,
                 Created = DefaultDatetime.MinValue,
                 LastModified = DefaultDatetime.MinValue,
             },
             new DishGeneral()
             {
                 Id = Guid.Parse("a4aade28-ecdf-4caa-b21d-eea8c01b6598"),
                 CategoryId = Guid.Parse("3140b8af-2124-44fa-8f43-907cddc26c3d"),
                 DishName = "Cơm trắng",
                 DishDescription = "Cơm ngon",
                 IsDeleted = false,
                 Created = DefaultDatetime.MinValue,
                 LastModified = DefaultDatetime.MinValue,
             }
    );
    }
}
