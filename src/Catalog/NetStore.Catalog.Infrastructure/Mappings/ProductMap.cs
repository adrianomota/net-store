namespace NetStore.Catalog.Infrastructure.Mappings;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetStore.Catalog.Domain;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("varchar(250)");
        builder.Property(c => c.Price)
        .IsRequired()
        .HasColumnType("decimal(10,2)");

        builder.Ignore(c => c.ValidationResult);

        builder.OwnsOne(c => c.Dimensions, cm =>
        {
            cm.Property(c => c.Height)
                .HasColumnName("Height")
                .HasColumnType("int");
            cm.Property(c => c.Width)
                .HasColumnName("Width")
                .HasColumnType("int");
            cm.Property(c => c.Depth)
                .HasColumnName("Depth")
                .HasColumnType("int");
            
            cm.Ignore(c => c.ValidationResult);
        });
    }
}
