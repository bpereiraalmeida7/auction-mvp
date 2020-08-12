using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using LeilaoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace LeilaoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly LeilaoContext _context;

        public LoginController(IConfiguration config, LeilaoContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuarios _userData)
        {
            if (_userData != null && _userData.Usuario != null && _userData.Senha != null)
            {
                var user = await GetUser(_userData.Usuario, _userData.Senha);

                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Nome", user.Nome),
                        new Claim("Usuario", user.Usuario)
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddHours(3), signingCredentials: signIn);
                    var tokenAuth = (new JwtSecurityTokenHandler().WriteToken(token));

                    var response = new[]
                    {
                        new Claim("bearer", tokenAuth)
                    };

                    return Ok(response);

                }
                else
                {
                    return BadRequest("Credenciais Inválidas ou Usuário Inativo");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Usuarios> GetUser(string usuario, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario == usuario && u.Senha == senha && u.Situacao);
        }
    }
}