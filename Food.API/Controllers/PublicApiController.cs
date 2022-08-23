using Food.API.Data.Intefaces;
using Food.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    public class PublicApiController : BasePublicApiController
    {
        private readonly SliderService _sliderService;
        private readonly ProductService _productService;
        private readonly ILanguageRepository _languageRepository;
        private readonly IProductRepository _productRepository;

        public PublicApiController(IHttpContextAccessor httpContextAccessor, ILanguageRepository languageRepository, SliderService sliderService, ProductService productService, IProductRepository productRepository) : base(httpContextAccessor, languageRepository)
        {
            _sliderService = sliderService;
            _productService = productService;
            _languageRepository = languageRepository;
            _productRepository = productRepository;
        }

        // GET: api/<PublicApiController>
        [HttpGet]
        [Route("Slider/GetAll")]
        public async Task<IActionResult> GetAllSliders()
        {
            return Ok(await _sliderService.GetAllSliderByLang(_rLangId));
        }
        [HttpGet]
        [Route("Category/GetAll")]
        public async Task<IActionResult> GetAllCategoriesAndProducts()
        {
            return Ok(await _productService.GetAllCategoryAndProductsByLang(_rLangId));
        }
        [HttpGet]
        [Route("Language/GetAll")]
        public async Task<IActionResult> GetAllLanguages()
        {
            return Ok(await _languageRepository.TableNoTracking.Where(p=>p.IsActive).ToListAsync());
        }
        [HttpGet]
        [Route("Product/GetAllPopulars")]
        public async Task<IActionResult> GetAllPopulars()
        {
            return Ok(await _productRepository.TableNoTracking.Where(p => p.IsActive &&p.IsPopular).ToListAsync());
        }
        // GET api/<PublicApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublicApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublicApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublicApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
