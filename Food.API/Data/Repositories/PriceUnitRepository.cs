using Food.API.Data.Intefaces;
using Food.API.Entities;

namespace Food.API.Data.Repositories;

public class PriceUnitRepository : BaseRepository<PriceUnit>, IPriceUnitRepository
{
    public PriceUnitRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}