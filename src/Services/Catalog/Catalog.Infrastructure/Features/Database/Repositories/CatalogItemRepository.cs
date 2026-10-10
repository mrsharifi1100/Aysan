namespace Catalog.Infrastructure.Features.Database.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly CatalogContext _context;

        public CatalogItemRepository(CatalogContext context)
        {
            _context = context;
        }
        IUnitOfWork IRepository<CatalogItem>.UnitOfWork => _context;

        public CatalogItem Add(CatalogItem item)
        {
            return _context.Add(item).Entity;
        }

        public async Task<IEnumerable<CatalogItem>> Get(long[] ids)
        {
            var items = await _context.CatalogItems.Where(ci => ids.Contains(ci.Id)).ToListAsync();

            return items;
        }

        public async Task<CatalogItem> GetByIdAsync(long id)
        {
            var catalogItem = await _context
                                  .CatalogItems
                                  .FirstOrDefaultAsync(C => C.Id == id);
            return catalogItem;
        }

        public async Task<IEnumerable<CatalogItem>> GetByPagingAsync(int pageSize, int pageIndex)
        {
            var totalItems = await _context.CatalogItems
                .LongCountAsync();

            var itemsOnPage = await _context.CatalogItems
                .OrderBy(c => c.Name)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
             .ToListAsync();
            return itemsOnPage;
        }

        public void Update(CatalogItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
