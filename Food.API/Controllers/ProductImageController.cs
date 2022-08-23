using AutoMapper;
using Food.API.Data.Intefaces;
using Food.API.DTOs.Product;
using Food.API.DTOs.ProductImage;
using Food.API.Entities;
using Food.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Controllers
{
    [Route("ProductImage")]
    public class ProductImageController : BaseAdminApiController
    {
        private readonly FileService _fileService;
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageController(IMapper mapper, FileService fileService, IProductImageRepository productImageRepository) : base(mapper)
        {
            _fileService = fileService;
            _productImageRepository = productImageRepository;
        }




        // POST api/<ProductContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductImageReqDto dto, CancellationToken cancellationToken)
        {


            ProductImage productImage = new ProductImage();
            if (dto.File != null)
            {

                var imageUrl = await _fileService.UploadFile(dto.File, "Product");
                
                productImage.ProductId=dto.ProductId;
                productImage.ImageUrl=imageUrl;
            }

            await _productImageRepository.AddAsync(productImage, cancellationToken, true);
            return Ok();

        }

        // PUT api/<ProductContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var lastProductImage = await _productImageRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (lastProductImage == null)
            {
                return NotFound();
            }
        
            await _productImageRepository.DeleteAsync(lastProductImage, cancellationToken, true);
            return Ok();

        }
    }
}
