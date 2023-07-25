using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace chatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }


        [HttpPost("register")]

        public ActionResult<User> Register (UserDTO request){
            
            string passwordHa = BCrypt.Net.BCrypt.HashPassword(request.password);
            user.userName=request.userName;
            user.passwordH=passwordHa;

            return Ok(user);
        }

         [HttpPost("login")]

        public ActionResult<User> login (UserDTO request){
            
            if(user.userName!=request.userName){
                return BadRequest("User not found please check your login details");
            }
            if(!BCrypt.Net.BCrypt.Verify(request.password,user.passwordH)){
                return BadRequest("worong password");
            }

            string token =CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user){
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token= new JwtSecurityToken(
                claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds
            );

            var jwt=new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}