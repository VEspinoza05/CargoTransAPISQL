using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BCrypt;
using CargoTransAPISQL.DTOs;
using CargoTransAPISQL.Repositories;
using CargoTransAPISQL.Models;
using CargoTransAPISQL.Interfaces.Reposiories;

public class AuthService
{
    private readonly IConfiguration _config;
    private readonly IEmployeeRepository _repo;

    public AuthService(IConfiguration config, IEmployeeRepository repo)
    {
        _config = config;
        _repo = repo;
    }

    public async Task<string?> LoginAsync(LoginDTO dto)
    {
        var employee = await _repo.GetByEmailAsync(dto.Email);
        if (employee == null) return null;

        bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, employee.PasswordHash);
        if (!valid) return null;

        return GenerateJwtToken(employee);
    }

    public async Task<EmployeeModel> RegisterAsync(RegisterDTO dto)
    {
        var employee = new EmployeeModel
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RoleId = dto.RoleId,
            Status = dto.Status,
            Phone = dto.Phone,
            ContractType = dto.ContractType,
            Shift = dto.Shift,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            StartDate = DateTime.Now,
        };

        await _repo.AddAsync(employee);
        return employee;
    }

    private string GenerateJwtToken(EmployeeModel employee)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, employee.FirstName),
            new Claim(ClaimTypes.Role, employee.Role.Name),
            new Claim(ClaimTypes.Email, employee.Email),
            new Claim("UserId", employee.Id.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(4),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
