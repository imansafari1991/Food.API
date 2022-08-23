using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.Category;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("Category")]
    public class CategoryContoller : BaseAdminApiController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryContoller(IMapper mapper, ICategoryRepository categoryRepository) : base(mapper)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return Ok(await _categoryRepository.TableNoTracking.ToListAsync());
        }

        // GET api/<CategoryContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(Guid id)
        {
            return Ok(await _categoryRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<CategoryContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryReqDto dto, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(dto);
            category.Id = Guid.NewGuid();

            await _categoryRepository.AddAsync(category, cancellationToken, true);
            return Ok(category.Id);

        }

        // PUT api/<CategoryContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoryReqDto dto, CancellationToken cancellationToken)
        {
            var lastCategory = await _categoryRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (lastCategory == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, lastCategory);
            lastCategory.ModifiedDateTime = DateTime.UtcNow;
            await _categoryRepository.UpdateAsync(lastCategory, cancellationToken, true);
            return Ok();

        }

        // DELETE api/<CategoryContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.TableNoTracking.Include(p => p.CategoryAttributes).FirstOrDefaultAsync(p => p.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.CategoryAttributes.Any())
            {
                return Content("You have to delete category attributes first");
            }
            if (category.Products.Any())
            {
                return Content("You have to delete products first");
            }

            await _categoryRepository.DeleteAsync(category, cancellationToken);
            return Ok();
        }
    }
}
