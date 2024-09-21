using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.UserAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        // Seed data for Employee entity
        builder.HasData(
            new Employee
            {
                Id = Guid.Parse("be4e8a98-7c95-4ef1-a407-6b8093b0e13a"),
                HireDate = DateTime.UtcNow,
                EmployeeCode = "EMP001",
                UserId = "6fb87153-242c-4024-a3af-f787b3919760",
                IsDeleted = false,
                RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                Created = DateTimeOffset.Parse("2022-01-15 10:00:00+00"),
                CreatedBy = "admin",
                LastModified = DateTimeOffset.Parse("2022-01-15 10:00:00+00"),
                LastModifiedBy = "admin"
            },
            new Employee
            {
                Id = Guid.Parse("a07496ad-bda3-4ac5-9279-81cae66ba253"),
                HireDate = DateTime.UtcNow,
                EmployeeCode = "EMP002",
                UserId = "f5404c4e-88b5-428e-8b07-b44af0d35979",
                IsDeleted = false,
                RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                Created = DateTimeOffset.Parse("2022-05-10 09:30:00+00"),
                CreatedBy = "manager",
                LastModified = DateTimeOffset.Parse("2022-05-10 09:30:00+00"),
                LastModifiedBy = "manager"
            },
            new Employee
            {
                Id = Guid.Parse("ce84ef13-3ce9-40c3-a14c-4a93dce72eb9"),
                HireDate = DateTime.UtcNow,
                EmployeeCode = "EMP003",
                UserId = "5680415f-f3b6-4288-899f-c01a357f150f",
                IsDeleted = false,
                RestaurantId = Guid.Parse("d42cf3c6-cbe4-4431-ac91-9eae870fa007"),
                Created = DateTimeOffset.Parse("2023-03-20 14:15:00+00"),
                CreatedBy = "admin",
                LastModified = DateTimeOffset.Parse("2023-03-20 14:15:00+00"),
                LastModifiedBy = "admin"
            }
        );
    }
}
