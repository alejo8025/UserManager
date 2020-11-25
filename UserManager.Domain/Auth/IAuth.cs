using System.Threading.Tasks;
using UserManager.Model.Auth;

namespace UserManager.Domain.Auth
{
    public interface IAuth
    {
        Task<Token> GenerateToken(string clientid, string secretkey);
        Task<Credential> GetCredentials();
    }
}
