using CargoTransAPISQL.DTOs;
using CargoTransAPISQL.Interfaces;
using CargoTransAPISQL.Mappers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly IRoleRepository _roleRepo;

    public AuthController(AuthService authService, IRoleRepository roleRepo)
    {
        _authService = authService;
        _roleRepo = roleRepo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        var usuario = await _authService.RegisterAsync(dto);
        var role = await _roleRepo.GetByIdAsync(usuario.RoleId);
        usuario.Role = role;
        return Ok(usuario.ToEmployeeDTO());
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var token = await _authService.LoginAsync(dto);
        if (token == null)
            return Unauthorized(new { message = "Credenciales inválidas" });

        return Ok(new { token });
    }
}
