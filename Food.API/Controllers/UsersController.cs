using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Food.API.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Food.API.Controllers
{

    public class UsersController : BaseAdminApiController
    {
        private readonly IConfiguration _configuration;

        public UsersController(IMapper mapper, IConfiguration configuration) : base(mapper)
        {
            _configuration = configuration;
        }
   
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserDto dto)
        {
            if (dto.Password.Equals(_configuration["Admin:Password"]) &&
                dto.Username.Equals(_configuration["Admin:Username"]))
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(30),
                    claims: new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "Admin"),
                        new Claim("Role", "FoodAdmin"),

                    },
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(

                    new JwtSecurityTokenHandler().WriteToken(token)

                );
            }
            else
            {
                return new NotFoundObjectResult("User not found");
            }
        }
    }
}
