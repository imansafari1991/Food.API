
using Food.API.Data.Intefaces;
using Food.API.Entities;

namespace Food.API.Data.Repositories;

public class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}