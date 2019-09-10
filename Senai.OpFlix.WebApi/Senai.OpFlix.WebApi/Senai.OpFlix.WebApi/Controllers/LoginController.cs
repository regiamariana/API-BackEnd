using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository usuarioRepository { get; set; }

        public LoginController()
        {
            usuarioRepository = new UsuarioRepository();

        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = usuarioRepository.BuscarPorEmailESenha(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "deu rui" });

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Idusuario.ToString()),
                    // é a permissão do usuário
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdtipousuarioNavigation.Tipousuario1),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("OpFlix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}