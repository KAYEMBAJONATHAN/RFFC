using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RFFC.Data;
using RFFC.DTO_s;
using RFFC.Entities;
using RFFC.Interfaces;

namespace RFFC.Services;

public class LoginService : ILoginService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _hasher;
    private readonly IJwtService _jwtService;

    public LoginService(DBContext context, IMapper mapper, IPasswordHasher<User> hasher, IJwtService jwtService)
    {
        _context = context;
        _mapper = mapper;
        _hasher = hasher;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken)
    {
        var user = await _context.GetUsers().SingleOrDefaultAsync(u => u.Email == dto.Email, cancellationToken);

        if (user == null ||
            _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password) != PasswordVerificationResult.Success)
        {
            return new LoginResponseDto
            {
                Message = "Invalid email or password."
            };
        }

        var token = _jwtService.GenerateToken(user);

        return new LoginResponseDto
        {
            Token = token,
            Message = "Login successful."
        };
    }
}
