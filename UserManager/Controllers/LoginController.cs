using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;
using UserManager.Domain.Helper;
using UserManager.Domain.Login;
using UserManager.Model.Common;
using UserManager.Model.Login;
using UserManager.Model.User;

namespace UserManager.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class LoginController : Controller
    {

        private readonly LoginDomain loginDomain;
        private readonly ErrorManagerTool errorManagerTool;

        public LoginController(ILoginRepo loginRepository, AppSettingGlobal settings)
        {
            loginDomain = new LoginDomain(loginRepository, settings);
            errorManagerTool = new ErrorManagerTool();
        }

        /// <summary>
        /// Method responsible for performing the authentication by User credential to AD and DB
        /// </summary>
        /// <param name="userLogin">User credential delivered by OneLink BPO to the user</param>
        /// <returns>UserModel</returns>
        /// <response code="400">If the User is null or empty or the url is not built correctly</response>   
        /// <response code="200">If the userLogin is accepted</response>
        /// <response code="401">Unauthorized customer</response> 
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(Result<UserModelDto>), 200)]
        [ProducesResponseType(typeof(Result<UserModelDto>), 401)]
        public async Task<IActionResult> UserLogin([FromBody] UserLogin userLogin)
        {
            try
            {
                if (userLogin != null)
                {
                    var user = await loginDomain.GetUser(userLogin);
                    return Ok(user);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(503, errorManagerTool.SetError<UserModelDto>(ex, MethodBase.GetCurrentMethod()));
            }

        }
    }
}
