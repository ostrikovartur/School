using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolsTest.Models;

namespace SchoolsTest.Data.Configs;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.Country)
        .IsRequired();

        builder.Property(t => t.City)
            .IsRequired();

        builder.Property(t => t.Street)
            .IsRequired();

        builder.Property(t => t.PostalCode)
            .IsRequired();
    }
}
