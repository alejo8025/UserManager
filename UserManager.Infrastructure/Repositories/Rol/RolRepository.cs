using System.Collections.Generic;
using UserManager.Domain.Rol;
using UserManager.Infrastructure.Common;
using UserManager.Model.Common;
using UserManager.Model.Rol;

namespace UserManager.Infrastructure.Repositories.Rol
{
    public class RolRepository : GenericRepository, IRol
    {
        private readonly AppSettingGlobal globalSettings;

        public RolRepository(AppSettingGlobal settings) : base(settings)
        {
            globalSettings = settings;
        }

        public IEnumerable<RolModel> GetAllRoles()
        {
            var userDb = GetAsync<RolModel, RolModel>(globalSettings.GetValue("SPGetAllRoles"), new RolModel(), System.Data.CommandType.StoredProcedure).Result;
            return userDb;
        }

    }
}
