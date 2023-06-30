using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class EmployeePositionConfig : IEntityTypeConfiguration<EmployeePosition>
{
    public void Configure(EntityTypeBuilder<EmployeePosition> builder)
    {
        builder.ToTable("EmployeePositions");

        builder
            .HasKey(t => new { t.EmployeeId, t.PositionId });

        //builder
        //    .HasOne(t => t.Employee)
        //    .WithMany(t => t.EmployeePositions)
        //    .HasForeignKey(t => t.EmployeeId)
        //    .OnDelete(DeleteBehavior.NoAction);

        //builder
        //    .HasOne(t => t.Position)
        //    .WithMany(t => t.EmployeePositions)
        //    .HasForeignKey(t => t.PositionId)
        //    .OnDelete(DeleteBehavior.NoAction);
    }
}
