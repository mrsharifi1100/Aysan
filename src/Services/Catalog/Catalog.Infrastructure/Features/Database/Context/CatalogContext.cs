namespace Catalog.Infrastructure.Features.Database.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
