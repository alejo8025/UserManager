using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Model.User;

namespace UserManager.Domain.User
{
    public interface IUser
    {
        IEnumerable<UserModelDto> GetAllUsers();
        Task<UserModelDto> UpdateUser(UpdateUserModel updateUserModel);
    }
}
