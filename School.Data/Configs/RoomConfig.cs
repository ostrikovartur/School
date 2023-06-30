using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class RoomConfig : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Number)
            .IsRequired();

        builder.HasOne(t => t.Floor)
            .WithMany(t => t.Rooms)
            .HasForeignKey(t => t.FloorId);
    }
}
