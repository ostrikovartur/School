using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Age)
            .IsRequired();

        builder.HasMany(t => t.Positions)
            .WithMany(t => t.Employees);

        //builder.Property(t => t.Position)
        //    .HasColumnType<Position>("tinyint");

        //builder.HasOne(t => t.School)
        //    .WithMany(t => t.Employees);
    }
}
