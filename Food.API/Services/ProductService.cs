using Food.API.Data.Intefaces;
using Food.API.DTOs;
using Food.API.DTOs.ProductImage;
using Food.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRopsitory;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRopsitory, ILanguageRepository languageRepository, ICategoryRepository categoryRepository)
        {
            _productRopsitory = productRopsitory;
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IReadOnlyList<CategoryAndProductResDto>> GetAllCategoryAndProductsByLang(int languageId)
        {
            var categories =await _categoryRepository.GetAllCategoriesByLang(languageId).AsQueryable().ToListAsync();
        

            var result = categories.Where(p=>p.CategoryAttributes.Any()).Select(c => new CategoryAndProductResDto
            {

                Id = c.Id,
                Title = c.CategoryAttributes.First().Title,
                Products = c.Products.Where(cc=>cc.ProductAttributes.Any()).Select(cp => new ProductResDto
                {
                    Title = cp.ProductAttributes.First().Title,
                    Description = cp.ProductAttributes.First().Description,
                    Price = cp.ProductAttributes.First().Price,
                    Id=cp.Id,
                    ProductImages = cp.ProductImages.Select(p=>new  ProductImageResDto(){ImageUrl = p.ImageUrl,Id = p.Id,ProductId = p.ProductId}).ToList()
                }).ToList()
            }).ToList();
            return result;

        }
    }
}
