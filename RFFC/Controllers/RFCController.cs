using Microsoft.AspNetCore.Mvc;
using RFFC.DTO_s;
using RFFC.DTO_S;
using RFFC.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RFFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFCController : ControllerBase
    {
        private readonly IRFCService _rfcService;

        public RFCController(IRFCService rfcService)
        {
            _rfcService = rfcService;
        }

        // GET: api/RFC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RFCMemberDto>>> GetAllMembers(CancellationToken cancellationToken)
        {
            var members = await _rfcService.GetAllMembers(cancellationToken);
            return Ok(members);
        }

        // GET: api/RFC/{RFCId}
        [HttpGet("{RFCId:guid}")]
        public async Task<ActionResult<RFCMemberDto>> GetMemberById(Guid RFCId, CancellationToken cancellationToken)
        {
            var member = await _rfcService.GetMemberByIdAsync(RFCId, cancellationToken);
            if (member == null) return NotFound();
            return Ok(member);
        }

        // POST: api/RFC
        [HttpPost]
        public async Task<ActionResult<RFCMemberDto>> CreateMember([FromBody] RFCMemberDto dto, CancellationToken cancellationToken)
        {
            var created = await _rfcService.CreateMemberAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetMemberById), new { RFCId = created.RFCId }, created);
        }

        // PUT: api/RFC/{RFCId}
        [HttpPut("{RFCId:guid}")]
        public async Task<ActionResult<RFCMemberDto>> UpdateMember(Guid RFCId, [FromBody] RFCMemberDto dto, CancellationToken cancellationToken)
        {
            dto.RFCId = RFCId;

            var updated = await _rfcService.UpdateMemberAsync(dto, cancellationToken);
            return Ok(updated);
        }

        // DELETE: api/RFC/{RFCId}
        [HttpDelete("{RFCId:guid}")]
        public async Task<IActionResult> DeleteMember(Guid RFCId, CancellationToken cancellationToken)
        {
            var success = await _rfcService.DeleteMemberAsync(RFCId, cancellationToken);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequestDto dto, CancellationToken cancellationToken)
        {
            var success = await _rfcService.SendMessageAsync(dto, cancellationToken);
            if (!success)
                return BadRequest("Message failed: invalid member, channel, or content.");

            return Ok("Message sent successfully.");
        }
    }
}
