using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Model.Common;
using UserManager.Model.User;

namespace UserManager.Domain.User
{
    public class UserDomain
    {
        private readonly IUser iUser;
        private readonly AppSettingGlobal globalSettings;
        public UserDomain(IUser userService, AppSettingGlobal settings)
        {
            iUser = userService;
            globalSettings = settings;
        }

        public async Task<Result<List<UserModelDto>>> GetUserAll()
        {
            var result = new Result<List<UserModelDto>> { Data = new List<UserModelDto>()};
            var usersdb = iUser.GetAllUsers();
            if (usersdb != null)
            {
                result.IsSuccess = true;
                result.Data = usersdb.ToList();
                result.ReturnMessage = globalSettings.GetValue("ServiceConnectionSuccessful");
            }
            else
            {
                result.IsSuccess = false;
                result.ReturnMessage = globalSettings.GetValue("ServiceConnectionUnsuccessful");
            }
            
            return result;
        }

        public async Task<Result<UserModelDto>> UpdateUser(UpdateUserModel updateUserModel)
        {
            var result = new Result<UserModelDto>();
            var userdb = await iUser.UpdateUser(updateUserModel);
            if (userdb != null)
            {
                result.IsSuccess = true;
                result.Data = userdb;
                result.ReturnMessage = globalSettings.GetValue("ServiceConnectionSuccessful");
            }
            else
            {
                result.IsSuccess = false;
                result.ReturnMessage = globalSettings.GetValue("ServiceConnectionUnsuccessful");
            }

            return result;
        }
    }
}
