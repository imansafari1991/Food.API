using Food.API.Data.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.API.Controllers
{
    [Route("api")]
    [ApiController]

    public class BasePublicApiController : ControllerBase
    {
        protected string _rLangCode = "en";
        protected int _rLangId = 1;

        public BasePublicApiController(IHttpContextAccessor httpContextAccessor, ILanguageRepository languageRepository)
        {
            var langCode = httpContextAccessor.HttpContext.Request.Headers["LanguageCode"].ToString();
            if (!string.IsNullOrEmpty(langCode))
            {
                _rLangCode = langCode;
                var lang = languageRepository.TableNoTracking.FirstOrDefault(p => p.Code == _rLangCode);
                if (lang != null)
                {
                    _rLangId = lang.Id;
                }
            }



        }
    }
}
