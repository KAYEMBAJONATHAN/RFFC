using RFFC.Entities;
using RFFC.Interfaces;

namespace RFFC.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateToken(RFFC.Entities.User user)
        {
            return "token";
        }
    }
}