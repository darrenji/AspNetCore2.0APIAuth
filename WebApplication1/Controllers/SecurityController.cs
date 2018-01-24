using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
   
    public class SecurityController : Controller
    {
        private IOptions<ApplicationSettings> _settings;
        public SecurityController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
        }
       public IActionResult RequestToken([FromBody]TokenRequest request)
        {
            if(request.Username == "darren" && request.Password == "888888")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.SecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "domain.com",
                    audience:"domain.com",
                    claims: claims,
                    expires:DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("couldn't verify username and password");
            
        }
    }
}
