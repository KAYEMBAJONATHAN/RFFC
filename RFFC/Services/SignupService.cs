using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RFFC.Data;
using RFFC.DTO_s;
using RFFC.Entities;
using RFFC.Interfaces;

namespace RFFC.Services;

public class SignupService : ISignupService
{
    private readonly DBContext _context;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _hasher;
    private readonly IJwtService _jwtService;

    public SignupService(DBContext context, IMapper mapper, IPasswordHasher<User> hasher, IJwtService jwtService)
    {
        _context = context;
        _mapper = mapper;
        _hasher = hasher;
        _jwtService = jwtService;
    }

    public async Task<SignupResponseDto> SignupAsync(SignupDto dto, CancellationToken cancellationToken)
    {
        // Check if user already exists
        if (_context.GetUsers().Any(u => u.Email == dto.Email))
            return new SignupResponseDto { Message = "User already exists" };

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = _hasher.HashPassword(null!, dto.Password)
        };

        _context.GetUsers().Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return new SignupResponseDto { Message = "User created successfully" };
    }
}
