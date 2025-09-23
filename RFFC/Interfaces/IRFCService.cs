
using RFFC.DTO_s;
using RFFC.DTO_S;  

namespace RFFC.Interfaces  
{
    public interface IRFCService
    {
        Task<IEnumerable<RFCMemberDto>> GetAllMembers(CancellationToken cancellationToken);
        Task<RFCMemberDto?> GetMemberByIdAsync(Guid RFCId, CancellationToken cancellationToken);
        Task<RFCMemberDto> CreateMemberAsync(RFCMemberDto dto, CancellationToken cancellationToken);
        Task<RFCMemberDto> UpdateMemberAsync(RFCMemberDto dto, CancellationToken cancellationToken);
        Task<bool> DeleteMemberAsync(Guid RFCId, CancellationToken cancellationToken);
        Task<bool> SendMessageAsync(MessageRequestDto dto, CancellationToken cancellationToken);
    }
}
