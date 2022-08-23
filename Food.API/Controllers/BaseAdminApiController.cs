using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.API.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    [Authorize]
    public class BaseAdminApiController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseAdminApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
