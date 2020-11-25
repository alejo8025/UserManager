using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UserManager.Domain.Helper;
using UserManager.Domain.Rol;
using UserManager.Model.Common;
using UserManager.Model.Rol;

namespace UserManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : Controller
    {

        private readonly RolDomain rolDomain;
        private readonly ErrorManagerTool errorManagerTool;

        public RolesController(IRol rolRepository, AppSettingGlobal settings)
        {
            rolDomain = new RolDomain(rolRepository, settings);
            errorManagerTool = new ErrorManagerTool();
        }

        /// <summary>
        /// Method responsible for performing the authentication and generating the access token
        /// </summary>
        /// <returns>Token</returns>
        /// <response code="200">If the request is accepted and found sites in DB</response>
        /// <response code="401">Unauthorized customer</response> 
        [HttpGet]
        [Route("GetAllRoles")]
        [ProducesResponseType(typeof(Result<List<RolModel>>), 200)]
        [ProducesResponseType(typeof(Result<List<RolModel>>), 401)]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var rolesList = await rolDomain.GetAllRoles();
                return Ok(rolesList);
            }
            catch (Exception ex)
            {
                return StatusCode(503, errorManagerTool.SetError<List<RolModel>>(ex, MethodBase.GetCurrentMethod()));
            }
        }
    }
}
