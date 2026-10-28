using Catalog.Infrastructure.Features.Database.Extentions;
using System.Data;

namespace Catalog.Infrastructure.Features.Database.Context
{
    public class CatalogContext : DbContext,IUnitOfWork
    {
        private readonly IMediator _mediator;
        public CatalogContext(
            DbContextOptions options,
            IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            var result = await SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CatalogItemConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        private IDbContextTransaction _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
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

            return new CatalogContext(optionsBuilder.Options, new NoMediator());
        }
    }
}
class NoMediator : IMediator
{
    public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        return null;
    }

    public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = default)
    {
        return null;
    }

    public Task Publish(object notification, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
    {
        return Task.CompletedTask;
    }

    public Task<TResponse> Send<TResponse>(
    IRequest<TResponse> request,
    CancellationToken cancellationToken = default)
    {
        return Task.FromResult(default(TResponse)!);
    }

    public Task<object?> Send(
        object request,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult<object?>(null);
    }
    public Task Send<TRequest>(
    TRequest request,
    CancellationToken cancellationToken = default)
    where TRequest : IRequest
    {
        return Task.CompletedTask;
    }
}