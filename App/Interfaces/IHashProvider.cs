using School_API.App.DTO;

namespace School_API.App.Interfaces
{
    public interface IHashProvider
    {
        byte[] GenerateSalt();
        HashResult Hash(byte[] salt, string password); 
        bool Verify(byte[] salt, byte[] hash, string password); 
    }
}