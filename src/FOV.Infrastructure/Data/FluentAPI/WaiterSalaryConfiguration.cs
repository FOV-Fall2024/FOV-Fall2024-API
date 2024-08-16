using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FOV.Infrastructure.Data.FluentAPI;
public class WaiterSalaryConfiguration : IEntityTypeConfiguration<WaiterSalary>
{
    public void Configure(EntityTypeBuilder<WaiterSalary> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User).WithMany(x => x.WaiterSalaries).HasForeignKey(x => x.UserId);
    }
}

