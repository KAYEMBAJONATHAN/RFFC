using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RFFC.Data;
using RFFC.DTO_s;
using RFFC.Entities;
using RFFC.Interfaces;

namespace RFFC.Services
{
    public class AuthService : IAuthService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Auth> _hasher;
        private readonly IJwtService _jwtService;

        public AuthService(DBContext context, IMapper mapper, IPasswordHasher<Auth> hasher, IJwtService jwtService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _hasher = hasher ?? throw new ArgumentNullException(nameof(hasher));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        public async Task<AuthDto.LoginResponse> LoginAsync(AuthDto.Login dto, CancellationToken cancellationToken)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var auth = await _context.Auths
                .SingleOrDefaultAsync(u => u.Email == dto.Email, cancellationToken);

            if (auth == null ||
                _hasher.VerifyHashedPassword(auth, auth.PasswordHash, dto.Password) != PasswordVerificationResult.Success)
            {
                return new AuthDto.LoginResponse
                {
                    Message = "Invalid email or password."
                };
            }

            var token = _jwtService.GenerateToken(auth);

            return new AuthDto.LoginResponse
            {
                Token = token,
                Message = "Login successful."
            };
        }

        public async Task<AuthDto.SignupResponse> SignupAsync(AuthDto.Signup dto, CancellationToken cancellationToken)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var existingUser = await _context.Auths
                .SingleOrDefaultAsync(u => u.Email == dto.Email, cancellationToken);

            if (existingUser != null)
            {
                return new AuthDto.SignupResponse
                {
                    Message = "User with this email already exists."
                };
            }

            var auth = _mapper.Map<Auth>(dto);
            auth.PasswordHash = _hasher.HashPassword(auth, dto.Password);

            _context.Auths.Add(auth);
            await _context.SaveChangesAsync(cancellationToken);

            return new AuthDto.SignupResponse
            {
                Message = "Signup successful."
            };
        }
    }
}
