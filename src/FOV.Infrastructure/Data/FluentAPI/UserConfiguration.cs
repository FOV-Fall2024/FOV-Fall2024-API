using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(x => x.Customer).WithOne(x => x.User).HasForeignKey<Customer>(x => x.UserId);
        builder.HasOne(x => x.Employee).WithOne(x => x.User).HasForeignKey<Employee>(x => x.UserId);
        builder.HasMany(x => x.GroupUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.GroupMessages).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        // Seed data
        //builder.HasData(
        //    new User
        //    {
        //        Id = "6fb87153-242c-4024-a3af-f787b3919760",
        //        FirstName = "Nguyen",
        //        LastName = "Anh",
        //        UserName = "NguyenAnh",
        //        NormalizedUserName = "NGUYENANH",
        //        Email = "nguyenanh@gmail.com",
        //        NormalizedEmail = "NGUYENANH@GMAIL.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = "AQAAAAEAACcQAAAAEP9r4v1tjDThjF1X2Rj3QvB1MzQaXJkblzP1LkL0fMPOZ5WsmXAf3P9N2WkPdMbxpg==",
        //        SecurityStamp = "A1B2C3D4E5",
        //        ConcurrencyStamp = "A1B2C3D4E5F6",
        //        PhoneNumber = "1234567890",
        //        PhoneNumberConfirmed = true,
        //        TwoFactorEnabled = false,
        //        LockoutEnabled = true,
        //        AccessFailedCount = 0
        //    },
        //    new User
        //    {
        //        Id = "f5404c4e-88b5-428e-8b07-b44af0d35979",
        //        FirstName = "Huynh",
        //        LastName = "Anh",
        //        UserName = "HuynhAnh",
        //        NormalizedUserName = "HUYNHANH",
        //        Email = "huynhanh@gmail.com",
        //        NormalizedEmail = "HUYNHANH@GMAIL.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = "AQAAAAEAACcQAAAAEHyv3s9XjAzOiDvB9vFS5Mkj8g7vnklQJkwpjCZr4mK34eM1JwqvP9M8F7wPdNBcy==",
        //        SecurityStamp = "B2C3D4E5F6",
        //        ConcurrencyStamp = "B2C3D4E5F6G7",
        //        PhoneNumber = "0987654321",
        //        PhoneNumberConfirmed = true,
        //        TwoFactorEnabled = false,
        //        LockoutEnabled = true,
        //        AccessFailedCount = 0
        //    },
        //    new User
        //    {
        //        Id = "5680415f-f3b6-4288-899f-c01a357f150f",
        //        FirstName = "Alice",
        //        LastName = "Johnson",
        //        UserName = "alicej",
        //        NormalizedUserName = "ALICEJ",
        //        Email = "alicej@example.com",
        //        NormalizedEmail = "ALICEJ@EXAMPLE.COM",
        //        EmailConfirmed = true,
        //        PasswordHash = "AQAAAAEAACcQAAAAEJ8s5t7kDv3X8bJ9fTS6nMk1h8jsnklRQNkqpL0z7oK45kM1WfqvQ9F9F8yPdMcbw==",
        //        SecurityStamp = "C3D4E5F6G7",
        //        ConcurrencyStamp = "C3D4E5F6G7H8",
        //        PhoneNumber = "1122334455",
        //        PhoneNumberConfirmed = true,
        //        TwoFactorEnabled = false,
        //        LockoutEnabled = true,
        //        AccessFailedCount = 0
        //    }
        //);
    }
}
