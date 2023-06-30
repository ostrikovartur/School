using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class SchoolConfig : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("Schools");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasOne(t => t.Address)
            .WithMany(t => t.Schools);

        builder.Property(t => t.OpeningDate)
            .HasColumnType("date");

        builder.HasMany(t => t.Students)
            .WithOne(t => t.School);

        builder.HasMany(t => t.Employees)
            .WithMany(t => t.Schools);

        builder.HasMany(t => t.Positions)
            .WithMany(t => t.Schools);

        builder.Ignore(t => t.Rooms);
    }
}