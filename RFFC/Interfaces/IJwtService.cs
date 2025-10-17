using RFFC.Entities;

namespace RFFC.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}