using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstractions;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;


namespace Services
{
    //public class UserService(IUnitOfWork _unitOfWork) : IUserService
    //{
    //    public async Task RegisterUserAsync(RegisterUserDto dto)
    //    {
    //        var repo = _unitOfWork.GetRepository<User>();

    //        var existingUser = (await repo.GetAllAsync())
    //                           .FirstOrDefault(u => u.UserName == dto.Username);

    //        if (existingUser is not null)
    //            throw new Exception("Username already exists");

    //        var user = new User
    //        {
    //            UserName = dto.Username,
    //            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
    //            Role = Enum.Parse<Roles>(dto.Role, ignoreCase: true)
    //        };

    //        await repo.AddAsync(user);
    //        await _unitOfWork.SaveChangesAsync();
    //    }

    //    public async Task<string> LoginUserAsync(LoginUserDto dto)
    //    {
    //        var repo = _unitOfWork.GetRepository<User>();
    //        var user = (await repo.GetAllAsync())
    //                   .FirstOrDefault(u => u.UserName == dto.Username);

    //        if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
    //            throw new Exception("Invalid credentials");

            
    //        var config = new ConfigurationBuilder()
    //                        .AddJsonFile("appsettings.json")
    //                        .Build();

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        var claims = new[]
    //        {
    //            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
    //            new Claim(ClaimTypes.Name, user.UserName),
    //            new Claim(ClaimTypes.Role, user.Role.ToString())
    //        };

    //        var token = new JwtSecurityToken(
    //            issuer: config["Jwt:Issuer"],
    //            audience: config["Jwt:Audience"],
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddHours(2),
    //            signingCredentials: creds
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    //}
}