using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Data.Repositories;

public class ProductRopsitory : BaseRepository<Product>, IProductRepository
{
    public ProductRopsitory(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<Product> GetAllProductByLang(int languageId)
    {
        return  TableNoTracking.Include(c => c.Category).Include(p => p.ProductAttributes.Where(pa=>pa.LanguageId==languageId)).AsEnumerable();
    }
}