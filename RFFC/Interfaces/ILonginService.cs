using RFFC.DTO_s;

namespace RFFC.Interfaces;

public interface ILoginService
{
    Task<LoginResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken);
}
