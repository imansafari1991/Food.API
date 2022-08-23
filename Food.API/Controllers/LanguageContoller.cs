using Food.API.Data.Intefaces;
using Food.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AutoMapper;
using Food.API.DTOs.Language;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food.API.Controllers
{
    [Route("Language")]
    public class LanguageContoller : BaseAdminApiController
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageContoller(IMapper mapper, ILanguageRepository languageRepository) : base(mapper)
        {
            _languageRepository = languageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Language>>> Get()
        {
            return Ok(await _languageRepository.TableNoTracking.ToListAsync());
        }

        // GET api/<LanguageContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> Get(int id)
        {
            return Ok(await _languageRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id));
        }

        // POST api/<LanguageContoller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LanguageReqDto dto,CancellationToken cancellationToken)
        {
            var language = _mapper.Map<Language>(dto);
            await _languageRepository.AddAsync(language, cancellationToken, true);
            return Ok();

        }

        // PUT api/<LanguageContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LanguageReqDto dto, CancellationToken cancellationToken)
        {
            var lastLanguage = await _languageRepository.TableNoTracking.FirstOrDefaultAsync(p=>p.Id==id);

            if (lastLanguage == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, lastLanguage);
            lastLanguage.ModifiedDateTime=DateTime.UtcNow;

            await _languageRepository.UpdateAsync(lastLanguage, cancellationToken, true);
            return Ok();

        }

        // DELETE api/<LanguageContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var language = await _languageRepository.TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);

            if (language == null)
            {
                return NotFound();
            }


            try
            {
                await _languageRepository.DeleteAsync(language, cancellationToken);
            }
            catch
            {
                return Content("You have delete language attributes first");
            }
        
            return Ok();
        }
    }
}
