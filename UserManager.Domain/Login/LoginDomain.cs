using System.Threading.Tasks;
using UserManager.Model.Common;
using UserManager.Model.Login;
using UserManager.Model.User;

namespace UserManager.Domain.Login
{
    public class LoginDomain
    {
        private readonly ILoginRepo iLogin;
        private readonly AppSettingGlobal globalSettings;
        public LoginDomain(ILoginRepo loginService, AppSettingGlobal settings)
        {
            iLogin = loginService;
            globalSettings = settings;
        }

        public async Task<Result<UserModelDto>> GetUser(UserLogin user)
        {
            var isValidUser = await ValidateUserInApplication(user);
            return isValidUser;
        }

        public async Task<Result<UserModelDto>> ValidateUserInApplication(UserLogin User)
        {
            var result = new Result<UserModelDto>();
            var userdb = await iLogin.GetUser(User);
            if (userdb == null)
            {
                return ErrorMesaggeValidationUSer(globalSettings.GetValue("MessageLoginUnsuccessAplication"));
            }
            result.ReturnMessage = globalSettings.GetValue("MessageLoginSucces");
            result.IsSuccess = true;
            result.Data = userdb;
            return result;
        }

        public Result<UserModelDto> ErrorMesaggeValidationUSer(string MessageError)
        {
            var result = new Result<UserModelDto>();
            result.ReturnMessage = MessageError;
            result.IsSuccess = false;
            result.Data = null;
            return result;
        }

    }
}
