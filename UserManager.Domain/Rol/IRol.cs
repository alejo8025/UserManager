using System.Collections.Generic;
using UserManager.Model.Rol;

namespace UserManager.Domain.Rol
{
    public interface IRol
    {
        IEnumerable<RolModel> GetAllRoles();
    }
}
