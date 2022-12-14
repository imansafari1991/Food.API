using Food.API.Data.Intefaces;
using Food.API.Data.Repositories;
using Food.API.Entities;

namespace Food.API.Data.Repositories;

public class CategoryAttributeRepository : BaseRepository<CategoryAttribute>, ICategoryAttributeRepository
{
    public CategoryAttributeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}