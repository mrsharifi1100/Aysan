using Catalog.Domain.Common;

namespace Catalog.Infrastructure.Features.Database.Context
{
    public class CatalogContext : DbContext,IUnitOfWork
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer(
                    "Server=localhost," +
                    "1433;Database=CatalogDb;" +
                    "User Id=sa;" +
                    "Password=Admin@12345Strong;" +
                    "TrustServerCertificate=True");

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}
