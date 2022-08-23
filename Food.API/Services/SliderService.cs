using Food.API.Data.Intefaces;
using Food.API.DTOs.Slider;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Services;

public class SliderService
{
    private readonly ISliderRepository _sliderRepository;
    private readonly ILanguageRepository _languageRepository;

    public SliderService(ISliderRepository sliderRepository, ILanguageRepository languageRepository)
    {
        _sliderRepository = sliderRepository;
        _languageRepository = languageRepository;
    }
    public async Task<IReadOnlyList<SliderResDto>> GetAllSliderByLang(int languageId)
    {
        var res =await  _sliderRepository.TableNoTracking.Include(p =>
            p.SliderAttributes.Where(c => c.IsActive &&c.LanguageId == languageId)).ToListAsync();

        return  res.Where(p=>p.SliderAttributes.Any()).Select(p => new SliderResDto
        {
            Id = p.SliderAttributes.First().Id,
            ImageUrl = p.ImageUrl,
            Description = p.SliderAttributes.First().Description,
            Title = p.SliderAttributes.First().Title

        }).ToList();

    }
}