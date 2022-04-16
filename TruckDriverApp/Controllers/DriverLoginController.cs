using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TruckDriverApp.Context;
using TruckDriverApp.Model;

namespace TruckDriverApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLoginController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly TruckDriverAppDbContext _context;

        public DriverLoginController(IConfiguration configuration, TruckDriverAppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> post(registermodel login)
        {
            if (login != null && login.Mobile_number != null && login.Password != null)
            {
                var user = await GetUser(login.Mobile_number,login.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                         new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                          new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                          new Claim("Mobile_number",user.Mobile_number),
                           new Claim("Password",user.Password),


                    };
                    var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Key"]));
                    var signIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
               _configuration["JWT:Issuer"],
               _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signIn);

                    user.Authkey = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token);
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return BadRequest("wrong choice");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<registermodel> GetUser(string mobile_number, string password)
        {
            return await _context.rRegisterModel.FirstOrDefaultAsync(m => m.Mobile_number == mobile_number && m.Password == password);

        }
        
        }
            
        }