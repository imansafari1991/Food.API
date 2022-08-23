using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.Product;
using Food.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("Product")]
    public class ProductContoller : BaseAdminApiController
    {
        private readonly IProductRepository _productRopsitory;
        private readonly FileService _fileService;

        public ProductContoller(IMapper mapper, IProductRepository productRopsitory, FileService fileService) : base(mapper)
        {
            _productRopsitory = productRopsitory;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _productRopsitory.TableNoTracking.ToListAsync());
        }

        // GET api/<ProductContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {


            return Ok(await _productRopsitory.TableNoTracking.Include(p=>p.ProductImages).FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<ProductContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductReqDto dto,CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = Guid.NewGuid();

            List<ProductImage> productImages = new List<ProductImage>();
            if (dto.Files.Any())
            {
                foreach (var item in dto.Files)
                {
                  var imageUrl=  await _fileService.UploadFile(item, "Product");
                  productImages.Add(new() { ProductId = product.Id, ImageUrl = imageUrl });
                }

                product.ProductImages = productImages;

            }

            await _productRopsitory.AddAsync(product, cancellationToken, true);
            return Ok(product.Id);

        }

        // PUT api/<ProductContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromForm] ProductReqDto dto, CancellationToken cancellationToken)
        {
            var lastProduct = await _productRopsitory.TableNoTracking.FirstOrDefaultAsync(p=>p.Id==id);

            if (lastProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(lastProduct, dto);
            //if (dto.File == null)
            //{
            //    lastProduct.ImageUrl = await _fileService.UploadFile(dto.File, "Product");
            //}

      
            lastProduct.ModifiedDateTime=DateTime.UtcNow;

            await _productRopsitory.UpdateAsync(lastProduct, cancellationToken, true);
            return Ok();

        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> SetPopularProducts(List<PopularProductReqDto> dto, CancellationToken cancellationToken)
        {

            var productList = await _productRopsitory.Table.Where(p => dto.Select(c => c.ProductId).Contains(p.Id))
                .ToListAsync();

            foreach (var product in productList)
            {
                product.IsPopular = dto.First(p => p.ProductId == product.Id).IsPopular;
            }
            await _productRopsitory.UpdateRangeAsync(productList, cancellationToken, true);
            return Ok();

        }
        // DELETE api/<ProductContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var product = await _productRopsitory.TableNoTracking.Include(p=>p.ProductAttributes).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.ProductAttributes.Any())
            {
                return Content("You have delete product attributes first");
            }

         await   _productRopsitory.DeleteAsync(product, cancellationToken);
            return Ok();
        }
    }
}
