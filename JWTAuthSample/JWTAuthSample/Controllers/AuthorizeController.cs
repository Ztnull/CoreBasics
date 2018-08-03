using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;



namespace JWTAuthSample.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private Models.JwtSettings _jwtSettings = new Models.JwtSettings();
        public AuthorizeController(IOptions<Models.JwtSettings> _jwtSettingsAccess)
        {
            _jwtSettings = _jwtSettingsAccess.Value;
        }

        public IActionResult Token(Models.LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (!(loginModel.User == "Dream" && loginModel.Password == "123456"))
                {
                    return BadRequest();
                }
                var claims = new Claim[] {
                    new Claim(ClaimTypes.Name,"Dream"),
                    new Claim(ClaimTypes.Role,"admin")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.SecreKey));//设置token加密Key
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//设置加密方式
                /*
                 加密Token
                 */
                var toekn = new JwtSecurityToken(
                    _jwtSettings.Issuser,
                    _jwtSettings.Audience,
                    claims,
                    DateTime.Now,//
                    DateTime.Now.AddMinutes(30),//过期时间
                    creds
                    );
                //最终的Token
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(toekn) });

            }
            return BadRequest();
        }
    }
}