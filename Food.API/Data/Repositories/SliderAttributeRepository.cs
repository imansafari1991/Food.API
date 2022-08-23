using Food.API.Data.Intefaces;
using Food.API.Entities;

namespace Food.API.Data.Repositories;

public class SliderAttributeRepository : BaseRepository<SliderAttribute>, ISliderAttributeRepository
{
    public SliderAttributeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}