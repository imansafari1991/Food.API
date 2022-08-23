using Food.API.Data.Intefaces;
using Food.API.Data.Repositories;
using Food.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Category> GetAllCategoriesByLang(int languageId)
    {
        return TableNoTracking.Include(c => c.CategoryAttributes.Where(ca => ca.LanguageId == languageId))
            .Include(p => p.Products).ThenInclude(pa => pa.ProductAttributes.Where(ca => ca.LanguageId == languageId))
            .Include(p=>p.Products).ThenInclude(pi=>pi.ProductImages)
            ;

    }
}