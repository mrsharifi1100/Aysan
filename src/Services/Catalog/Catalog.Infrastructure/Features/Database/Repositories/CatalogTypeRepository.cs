namespace Catalog.Infrastructure.Features.Database.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly CatalogContext _context;

        public CatalogTypeRepository(CatalogContext context)
        {
            _context = context;
        }
        IUnitOfWork IRepository<CatalogType>.UnitOfWork => _context;
        public CatalogType Add(CatalogType item)
        {
            return _context.Add(item).Entity;
        }

        public async Task<IEnumerable<CatalogType>> Get(long[] ids)
        {
            var types = await _context.CatalogTypes.Where(ci => ids.Contains(ci.Id)).ToListAsync();

            return types;
        }

        public async Task<CatalogType> GetByIdAsync(long id)
        {
            var catalogTypes = await _context
                                  .CatalogTypes
                                  .FirstOrDefaultAsync(C => C.Id == id);
            return catalogTypes;
        }

        public void Update(CatalogType item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}