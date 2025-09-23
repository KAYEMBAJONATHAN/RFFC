using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RFFC.Data;
using RFFC.DTO_s;
using RFFC.DTO_S;
using RFFC.Entities;
using RFFC.Interfaces;

namespace RFFC.Services
{
    public class RFCService : IRFCService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public RFCService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RFCMemberDto>> GetAllMembers(CancellationToken cancellationToken)
        {
            var members = await _context.RFCs.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<RFCMemberDto>>(members);
        }

        public async Task<RFCMemberDto?> GetMemberByIdAsync(Guid RFCId, CancellationToken cancellationToken)
        {
            var member = await _context.RFCs.FindAsync(new object[] { RFCId }, cancellationToken);
            return member == null ? null : _mapper.Map<RFCMemberDto>(member);
        }

        public async Task<RFCMemberDto> CreateMemberAsync(RFCMemberDto dto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RFC>(dto);
            entity.RFCId = Guid.NewGuid();

            _context.RFCs.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RFCMemberDto>(entity);
        }

        public async Task<RFCMemberDto> UpdateMemberAsync(RFCMemberDto dto, CancellationToken cancellationToken)
        {
            var entity = await _context.RFCs.FindAsync(new object[] { dto.RFCId }, cancellationToken);
            if (entity == null) throw new KeyNotFoundException("Member not found");

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RFCMemberDto>(entity);
        }

        public async Task<bool> DeleteMemberAsync(Guid RFCId, CancellationToken cancellationToken)
        {
            var entity = await _context.RFCs.FindAsync(new object[] { RFCId }, cancellationToken);
            if (entity == null) return false;

            _context.RFCs.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> SendMessageAsync(MessageRequestDto dto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(dto.RecipientPhone) || string.IsNullOrWhiteSpace(dto.MessageText))
                return false;

            var channel = "sms"; // Default or infer from context if needed

            // Simulate sending logic
            Console.WriteLine($"[{channel.ToUpper()}] To: {dto.RecipientPhone} | Message: {dto.MessageText}");

            // Persist message to DB
            var messages = new MessageRequest
            {
                MessageText = dto.MessageText.Trim(),
                RecipientName = dto.RecipientName?.Trim(),
                RecipientPhone = dto.RecipientPhone.Trim(),
                RecipientEmail = dto.RecipientEmail?.Trim()
            };

            _context.Messages.Add(messages);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
