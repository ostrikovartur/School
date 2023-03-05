using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class PositionConfig : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Position");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired();

        //builder.HasMany(t => t.Employees)
        //    .WithMany(t => t.Positions)
        //    .UsingEntity(j => j.ToTable("EmployeePosition"));
            //.UsingEntity(
            //    jt => jt.HasOne(typeof(Position))
            //        .WithMany()
            //        .HasForeignKey("PositionId")
            //        .HasConstraintName("FK_EmployeePosition_PositionId")
            //        .OnDelete(DeleteBehavior.NoAction),
            //    jt => jt.HasOne(typeof(Employee))
            //        .WithMany()
            //        .HasForeignKey("EmployeeId")
            //        .HasConstraintName("FK_EmployeePosition_EmployeeId")
            //        .OnDelete(DeleteBehavior.NoAction),
            //    b => b.ToTable("EmployeePosition")
            //        .HasKey("EmployeeId", "PositionId")
            //    );
    }
}
