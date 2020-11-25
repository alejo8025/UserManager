using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Model.Common;
using UserManager.Model.Rol;

namespace UserManager.Domain.Rol
{
    public class RolDomain
    {
        private readonly IRol iRol;
        private readonly AppSettingGlobal globalSettings;
        public RolDomain(IRol rolService, AppSettingGlobal settings)
        {
            iRol = rolService;
            globalSettings = settings;
        }

        public async Task<Result<List<RolModel>>> GetAllRoles()
        {
            var result = new Result<List<RolModel>> { Data = new List<RolModel>() };
            var rolesdb = iRol.GetAllRoles();
            if (rolesdb != null)
            {
                result.IsSuccess = true;
                result.Data = rolesdb.ToList();
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
