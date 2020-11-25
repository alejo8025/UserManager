using Microsoft.Extensions.Options;
using UserManager.Model.Common;

namespace UserManager.UnitTest.Config
{
    public class AppSettingsMock : IOptions<AppSetting>
    {
        public AppSetting Value { get; set; }
        public AppSettingsMock()
        {
            Value = new AppSetting();
            Value.SecretKeyAuth = "1a2c76d2-9ccb-46b4-afc6-8aae0b191a9d";
            Value.ClientIdAuth = "59cd7a41-d9c5-4f94-9bc6-2bb5da87410a|40be544d-02de-45cb-b11c-9a8e6a5767d2|0a6c35dd-c408-4212-9b97-0df08b461970";
            Value.DbConnection = "Server=(localdb)\\mssqllocaldb;Database=db-UserManager-dev;Persist Security Info=False;MultipleActiveResultSets=True;TrustServerCertificate=False;Integrated Security=true;Connection Timeout=30;";
            Value.Issuer = "CheckTraveler";
            Value.Audience = "CheckTraveler";
            Value.Separator = "|";
            Value.MessageLoginSucces = "Login success";
            Value.MessageLoginUnsuccess = "Wrong user or password";
            Value.MessageLoginUnsuccessAplication = "Unauthorized User";
            Value.MessageAuthSuccess = "Successfull Authentication";
            Value.ServiceConnectionSuccessful = "Successfull connection service";
            Value.ServiceConnectionUnsuccessful = "Unsuccessfull connection service";
            Value.MessageAuthNotValid = "ClientId is not valid";
            Value.MessageSuccessToken = "Successfully generated token";
            Value.SPGetuser = "CON_USER_EXIST";
            Value.SPGetAllUsers = "CON_USER_ALL";
            Value.SPGetUpdateUsers = "INS_USER_UPDATE";
            Value.SPGetAllRoles = "CON_ROLES_ALL";
            Value.SPGetAllDocumentTypes = "CON_DOCUMENTTYPE_ALL";
            Value.SPInsertUser = "INS_USER_NEW";
        }
    }
}
