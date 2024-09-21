using FOV.Domain.Entities.ProductGeneralAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
internal class ProductIngredientGeneralConfiguration : IEntityTypeConfiguration<ProductIngredientGeneral>
{
    public void Configure(EntityTypeBuilder<ProductIngredientGeneral> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasData(new ProductIngredientGeneral
        {
            Id = Guid.Parse("9ccc8ec6-6b72-4467-aaeb-1e45dc0540b0"),
            IngredientGeneralId = Guid.Parse("9ccc9ec6-6b72-4467-aaeb-1e45dc0540a8"),
            ProductGeneralId = Guid.Parse("6535596e-a86a-4fcc-97e7-7e6182a5c022"),
            Quantity = 2,
            IsDeleted = false,
        });
    }
}
