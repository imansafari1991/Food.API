using Food.API.Data.Intefaces;
using Food.API.Data.Repositories;
using Food.API.Entities;

namespace Food.API.Data.Repositories;

public class ProductAttributeRepository : BaseRepository<ProductAttribute>, IProductAttributeRepository
{
    public ProductAttributeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}