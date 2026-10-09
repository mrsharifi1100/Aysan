namespace Catalog.Infrastructure.Features.Database.Configuration;

public class CatalogItemConfiguration
    : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("CatalogItem");

        builder.Property(x => x.Id)
            .UseHiLo("catalog_hilo")
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired(false);

        builder.Property(x => x.IsDiscount)
            .IsRequired();

        builder.Property(x => x.AvailableStock)
            .IsRequired();

        builder.Property(x => x.StockThreshold)
            .IsRequired();

        builder.Property(x => x.MaxStockThreshold)
            .IsRequired();

        builder.HasOne(x => x.CatalogType)
            .WithMany()
            .HasForeignKey(x => x.CatalogTypeId);
    }
}