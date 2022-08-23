using Food.API.Entities;

namespace Food.API.Data.Intefaces;

public interface IProductRepository:IBaseRepository<Product>
{
    IEnumerable<Product> GetAllProductByLang(int languageId);
}