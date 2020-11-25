using System;
using System.Threading.Tasks;
using UserManager.Domain.Helper;
using UserManager.Model.Auth;
using UserManager.Model.Common;

namespace UserManager.Domain.Auth
{
    public class AuthDomain
    {
        private readonly IAuth iAuthRepository;
        private readonly AppSettingGlobal globalSettings;
        public AuthDomain(IAuth authRepository, AppSettingGlobal settings)
        {
            iAuthRepository = authRepository;
            globalSettings = settings;
        }

        public async Task<Result<Credential>> IsValidClient(string clientId)
        {
            var credential = await iAuthRepository.GetCredentials();
            var result = new Result<Credential>
            {
                ReturnMessage = globalSettings.GetValue("MessageAuthNotValid"),
                IsSuccess = false
            };

            var clientsList = await Tools.ConvertStringToList(credential.ClientID, Convert.ToChar(globalSettings.GetValue("Separator")));
            var clientIdLast = await Tools.ExistIn(clientsList, clientId);

            if (clientIdLast)
            {
                result.ReturnMessage = globalSettings.GetValue("MessageAuthSuccess");
                result.IsSuccess = true;
                result.Data = credential;
                return result;
            }
            return result;
        }

        public async Task<Result<Token>> GenerateToken(string clientId, string secretKey)
        {
            Result<Token> result = new Result<Token>();
            var token = await iAuthRepository.GenerateToken(clientId, secretKey);
            result.IsSuccess = true;
            result.ReturnMessage = globalSettings.GetValue("MessageSuccessToken");
            result.Data = token;
            return result;
        }
    }
}
