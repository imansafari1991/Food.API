using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.SliderAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("SliderAttribute")]
    public class SliderAttributeContoller : BaseAdminApiController
    {
        private readonly ISliderAttributeRepository _sliderAttributeRepository;

        public SliderAttributeContoller(IMapper mapper, ISliderAttributeRepository sliderAttributeRepository) : base(mapper)
        {
            _sliderAttributeRepository = sliderAttributeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SliderAttribute>>> Get()
        {
            return Ok(await _sliderAttributeRepository.TableNoTracking.Include(p => p.Slider).ToListAsync());
        }

        // GET api/<SliderAttributeContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SliderAttribute>> Get(Guid id)
        {
            return Ok(await _sliderAttributeRepository.TableNoTracking.Include(p=>p.Slider).Include(p=>p.Language).FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<SliderAttributeContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SliderAttributeReqDto dto, CancellationToken cancellationToken)
        {
            var slider = _mapper.Map<SliderAttribute>(dto);
            slider.Id = Guid.NewGuid();

            await _sliderAttributeRepository.AddAsync(slider, cancellationToken, true);
            return Ok();

        }

        // PUT api/<SliderAttributeContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] SliderAttributeReqDto dto, CancellationToken cancellationToken)
        {
            var lastSliderAttribute = await _sliderAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (lastSliderAttribute == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, lastSliderAttribute);
            lastSliderAttribute.ModifiedDateTime = DateTime.UtcNow;

            await _sliderAttributeRepository.UpdateAsync(lastSliderAttribute, cancellationToken, true);
            return Ok();

        }

        // DELETE api/<SliderAttributeContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var sliderAttribute = await _sliderAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (sliderAttribute == null)
            {
                return NotFound();
            }
            await _sliderAttributeRepository.DeleteAsync(sliderAttribute, cancellationToken);
            return Ok();
        }
    }
}
