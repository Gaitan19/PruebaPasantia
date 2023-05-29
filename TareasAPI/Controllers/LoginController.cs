using Microsoft.AspNetCore.Mvc;
using TareasAPI.Data.DTOs;
using TestTareasAPI.Services;
using TareasAPI.Data.TareaModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TareasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase    
{
    private readonly LoginService loginService;
    private IConfiguration config;
    public LoginController(LoginService loginService, IConfiguration config)
    {
        this.loginService = loginService;
        this.config = config;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Login(AdminDto adminDto)
    {
        var admin = await loginService.GetAdmin(adminDto);

        if (admin is null)
            return BadRequest(new { message = "Credenciales invalidas"});

        //Se genera un token en caso de que las credenciales sean correctas    
        string jwToken = GenerateToken(admin);
        
        return Ok(new {token = jwToken} );
    }

    private string GenerateToken(Administrador admin)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, admin.Nombre),
            new Claim(ClaimTypes.Email, admin.Correo),
            new Claim("AdminTipo" , admin.AdminTipo)
        };


    var key = config.GetSection("JWT:key").Value;
    
    #region ifkey
    if (key is null)
    {
       key = null!;
    }
    #endregion

    var keyBytes = Encoding.UTF8.GetBytes(key);
    var symmetricKey = new SymmetricSecurityKey(keyBytes);
    var creds = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512Signature);
    var securityToken = new JwtSecurityToken(
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(60),
                            signingCredentials: creds);
        
        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;                    

    }
}