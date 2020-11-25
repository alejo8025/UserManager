using System.Threading.Tasks;
using UserManager.Domain.Login;
using UserManager.Infrastructure.Common;
using UserManager.Model.Common;
using UserManager.Model.Login;
using UserManager.Model.User;

namespace UserManager.Infrastructure.Repositories.Login
{
    public class LoginRepository : GenericRepository, ILoginRepo
    {
        private readonly AppSettingGlobal globalSettings;

        public LoginRepository(AppSettingGlobal settings) : base(settings)
        {
            globalSettings = settings;
        }

        public async Task<UserModelDto> GetUser(UserLogin user)
        {
            var userDb = await GetAsyncFirst<UserLogin, UserModelDto>(globalSettings.GetValue("SPGetuser"), user, System.Data.CommandType.StoredProcedure);
            return userDb;
        }
    }
}
