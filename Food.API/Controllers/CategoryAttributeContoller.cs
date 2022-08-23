using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.CategoryAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("CategoryAttribute")]
    public class CategoryAttributeContoller : BaseAdminApiController
    {
        private readonly ICategoryAttributeRepository _categoryAttributeRepository;

        public CategoryAttributeContoller(IMapper mapper, ICategoryAttributeRepository categoryRepository) : base(mapper)
        {
            _categoryAttributeRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryAttribute>>> Get()
        {
            return Ok(await _categoryAttributeRepository.TableNoTracking.Include(p => p.Category).ToListAsync());
        }

        // GET api/<CategoryAttributeContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryAttribute>> Get(Guid id)
        {
            return Ok(await _categoryAttributeRepository.TableNoTracking.Include(p=>p.Category).Include(p=>p.Language).FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<CategoryAttributeContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryAttributeReqDto dto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<CategoryAttribute>(dto);
            category.Id = Guid.NewGuid();

            await _categoryAttributeRepository.AddAsync(category, cancellationToken, true);
            return Ok(category.Id);

        }

        // PUT api/<CategoryAttributeContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoryAttributeReqDto dto, CancellationToken cancellationToken)
        {
            var lastCategoryAttribute = await _categoryAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (lastCategoryAttribute == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, lastCategoryAttribute);
            lastCategoryAttribute.ModifiedDateTime = DateTime.UtcNow;

            await _categoryAttributeRepository.UpdateAsync(lastCategoryAttribute, cancellationToken, true);
            return Ok();

        }

        // DELETE api/<CategoryAttributeContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var categoryAttribute = await _categoryAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (categoryAttribute == null)
            {
                return NotFound();
            }
            await _categoryAttributeRepository.DeleteAsync(categoryAttribute, cancellationToken);
            return Ok();
        }
    }
}
