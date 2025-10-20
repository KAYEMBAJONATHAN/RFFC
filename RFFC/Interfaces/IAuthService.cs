using RFFC.DTO_s;

namespace RFFC.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto.LoginResponse> LoginAsync(AuthDto.Login dto, CancellationToken cancellationToken);
        Task<AuthDto.SignupResponse> SignupAsync(AuthDto.Signup dto, CancellationToken cancellationToken);
    }
}