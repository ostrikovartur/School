using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class RoomConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Room");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Number)
            .IsRequired();

        builder.Property(t => t.Type)
            .HasColumnType<RoomType>("tinyint");

        builder.HasOne(t => t.FloorNumber)
            .WithMany(t => t.Rooms);
    }
}
