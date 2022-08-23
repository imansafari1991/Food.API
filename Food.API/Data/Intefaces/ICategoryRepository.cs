using Food.API.Entities;

namespace Food.API.Data.Intefaces;

public interface ICategoryRepository:IBaseRepository<Category>
{

    IEnumerable<Category> GetAllCategoriesByLang(int languageId);
}