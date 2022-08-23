using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.Slider;
using Food.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("Slider")]
    public class SliderContoller : BaseAdminApiController
    {
        private readonly ISliderRepository _sliderRopsitory;
        private readonly FileService _fileService;

        public SliderContoller(IMapper mapper, ISliderRepository sliderRopsitory, FileService fileService) : base(mapper)
        {
            _sliderRopsitory = sliderRopsitory;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Slider>>> Get()
        {
            return Ok(await _sliderRopsitory.TableNoTracking.ToListAsync());
        }

        // GET api/<SliderContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> Get(Guid id)
        {
            return Ok(await _sliderRopsitory.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<SliderContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] SliderReqDto dto, CancellationToken cancellationToken)
        {

            var slider = _mapper.Map<Slider>(dto);
            slider.Id = Guid.NewGuid();

            if (dto.File != null)
            {
                slider.ImageUrl = await _fileService.UploadFile(dto.File, "Slider");
            }


            await _sliderRopsitory.AddAsync(slider, cancellationToken, true);
            return Ok(slider.Id);

        }

        // PUT api/<SliderContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm] SliderReqDto dto, CancellationToken cancellationToken)
        {
            var lastSlider = await _sliderRopsitory.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (lastSlider == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, lastSlider);
            if (dto.File != null)
            {
                lastSlider.ImageUrl = await _fileService.UploadFile(dto.File, "Slider");
            }

            lastSlider.ModifiedDateTime = DateTime.UtcNow;

            await _sliderRopsitory.UpdateAsync(lastSlider, cancellationToken, true);
            return Ok();

        }

        // DELETE api/<SliderContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var slider = await _sliderRopsitory.TableNoTracking.Include(p => p.SliderAttributes).FirstOrDefaultAsync(p => p.Id == id);

            if (slider == null)
            {
                return NotFound();
            }

            if (slider.SliderAttributes.Any())
            {
                return Content("You have delete slider attributes first");
            }

            await _sliderRopsitory.DeleteAsync(slider, cancellationToken);
            return Ok();
        }
    }
}
