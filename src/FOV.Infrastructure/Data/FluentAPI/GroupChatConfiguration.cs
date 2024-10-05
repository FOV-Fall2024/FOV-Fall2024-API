using FOV.Domain.Entities.GroupChatAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
internal class GroupChatConfiguration : IEntityTypeConfiguration<GroupChat>
{
    public void Configure(EntityTypeBuilder<GroupChat> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasMany(x => x.GroupUsers).WithOne(x => x.GroupChat).HasForeignKey(x => x.GroupChatId);
        builder.HasMany(x => x.GroupMessages).WithOne(x => x.GroupChat).HasForeignKey(x => x.GroupChatId);
        builder.HasData(new GroupChat
        {
            Id = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0110b0"),
            GroupName = "DefaultGroupChat",
            RestaurantId = Guid.Parse("9ffc9ec6-6b72-4467-aaeb-1e45dc0540b0"),
            Created = DateTimeOffset.Parse("2022-01-01")
        });
    }
}
