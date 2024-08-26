using FOV.Domain.Entities.GroupChatAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
internal class GroupChatConfiguration : IEntityTypeConfiguration<GroupChat>
{
    public void Configure(EntityTypeBuilder<GroupChat> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.GroupUsers).WithOne(x => x.GroupChat).HasForeignKey(x => x.GroupChatId);
        builder.HasMany(x => x.GroupMessages).WithOne(x => x.GroupChat).HasForeignKey(x => x.GroupChatId);
    }
}
