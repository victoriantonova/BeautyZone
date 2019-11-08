using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BeautyZone.BLL.Models;
using BeautyZone.BLL.Services;
using BeautyZone.WEB.Models;
using Microsoft.AspNetCore.Http;

namespace BeautyZone.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        readonly UserService userService;
        UserHelper userHelper = new UserHelper();
        public IdentityController(UserService serv)
        {
            userService = serv;
        }

        [Route("token")]
        [HttpPost]
        public IActionResult Token([FromBody]UserBLL model)
        {
            var identity = GetIdentity(model.Login, model.Password);
            if (identity == null)
            {
                return Unauthorized();
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            userHelper.Token = encodedJwt;

            return Ok(userHelper);
        }
        private IReadOnlyCollection<Claim> GetIdentity(string login, string password)
        {
            List<Claim> claims = null;
            var user = userService.GetUsers();
            foreach (UserBLL u in user)
            {
                if (u.Login == login)
                {
                    var sha256 = new SHA256Managed();
                    var passwordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));

                    if (passwordHash == u.Password)
                    {
                        userHelper.Id = u.Id;
                        userHelper.Login = u.Login;
                        claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, u.Login),
                        };
                    }
                }
            }
            return claims;
        }
    }
}