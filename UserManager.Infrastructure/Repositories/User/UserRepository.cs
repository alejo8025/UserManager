using System.Collections.Generic;
using System.Threading.Tasks;
using UserManager.Domain.User;
using UserManager.Infrastructure.Common;
using UserManager.Model.Common;
using UserManager.Model.User;

namespace UserManager.Infrastructure.Repositories.User
{
    public class UserRepository : GenericRepository, IUser
    {
        private readonly AppSettingGlobal globalSettings;

        public UserRepository(AppSettingGlobal settings) : base(settings)
        {
            globalSettings = settings;
        }

        public IEnumerable<UserModelDto> GetAllUsers()
        {
            var userDb = GetAsync<UserModelDto, UserModelDto>(globalSettings.GetValue("SPGetAllUsers"), new UserModelDto(), System.Data.CommandType.StoredProcedure).Result;
            return userDb;
        }

        public async Task<UserModelDto> UpdateUser(UpdateUserModel updateUserModel)
        {
            var userDb = await GetAsyncFirst<UpdateUserModel, UserModelDto>(globalSettings.GetValue("SPGetUpdateUsers"), updateUserModel, System.Data.CommandType.StoredProcedure);
            return userDb;
        }
    }
}
