using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class RoomTypeConfig : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
            .IsRequired();

        builder.HasMany(t => t.Schools)
            .WithMany(t => t.RoomTypes);

        builder.HasMany(t => t.Rooms)
            .WithMany(t => t.RoomTypes);
    }
}
