using System.Threading.Tasks;
using UserManager.Model.Login;
using UserManager.Model.User;

namespace UserManager.Domain.Login
{
    public interface ILoginRepo
    {
        Task<UserModelDto> GetUser(UserLogin user);
    }
}
