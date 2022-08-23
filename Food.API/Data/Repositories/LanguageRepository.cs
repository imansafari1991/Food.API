using Food.API.Data.Intefaces;
using Food.API.Data.Repositories;
using Food.API.Entities;

namespace Food.API.Data.Repositories;

public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
{
    public LanguageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}