using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.ProductAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("ProductAttribute")]
    public class ProductAttributeContoller : BaseAdminApiController
    {
        private readonly IProductAttributeRepository _productAttributeRepository;

        public ProductAttributeContoller(IMapper mapper, IProductAttributeRepository productAttributeRepository) : base(mapper)
        {
            _productAttributeRepository = productAttributeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _productAttributeRepository.TableNoTracking.ToListAsync());
        }

        // GET api/<ProductContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            return Ok(await _productAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<ProductContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductAttributeReqDto dto, CancellationToken cancellationToken)
        {

            var productAttribute = _mapper.Map<ProductAttribute>(dto);
            productAttribute.Id = Guid.NewGuid();
            await _productAttributeRepository.AddAsync(productAttribute, cancellationToken, true);
            return Ok(productAttribute.Id);

        }

        // PUT api/<ProductContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductAttributeReqDto dto, CancellationToken cancellationToken)
        {
            var lastProductAttribute = await _productAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);


            if (lastProductAttribute == null)
            {
                return NotFound();
            }


            _mapper.Map(dto, lastProductAttribute);
            lastProductAttribute.ModifiedDateTime = DateTime.UtcNow;


            await _productAttributeRepository.UpdateAsync(lastProductAttribute, cancellationToken, true);
            return Ok();

        }

        // DELETE api/<ProductContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var productAttribute = await _productAttributeRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (productAttribute == null)
            {
                return NotFound();
            }
            await _productAttributeRepository.DeleteAsync(productAttribute, cancellationToken);
            return Ok();
        }
    }
}
