using RFFC.Entities;

namespace RFFC.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(Auth auth);
    }
}