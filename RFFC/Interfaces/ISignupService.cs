using RFFC.DTO_s;

namespace RFFC.Interfaces;

public interface ISignupService
{
    Task<SignupResponseDto> SignupAsync(SignupDto dto, CancellationToken cancellationToken);
}
