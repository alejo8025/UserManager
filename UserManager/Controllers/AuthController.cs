using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;
using UserManager.Domain.Auth;
using UserManager.Domain.Helper;
using UserManager.Model.Auth;
using UserManager.Model.Common;

namespace UserManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthDomain authDomain;
        private readonly ErrorManagerTool errorManagerTool;

        public AuthController(IAuth iAuthRepository, AppSettingGlobal settings)
        {
            authDomain = new AuthDomain(iAuthRepository, settings);
            errorManagerTool = new ErrorManagerTool();
        }

        /// <summary>
        /// Method responsible for performing the authentication and generating the access token
        /// </summary>
        /// <param name="ClientId">ClientId delivered by OneLink BPO to the company</param>
        /// <returns>Token</returns>
        /// <response code="400">If the ClientId is null or empty or the url is not built correctly</response>   
        /// <response code="200">If the ClientId is accepted</response>
        /// <response code="401">Unauthorized customer</response> 
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(Result<Token>), 200)]
        [ProducesResponseType(typeof(Result<Token>), 401)]
        public async Task<IActionResult> Auth([FromHeader] string ClientId)
        {
            try
            {
                if (!string.IsNullOrEmpty(ClientId))
                {
                    var isValid = await authDomain.IsValidClient(ClientId);
                    if (isValid.IsSuccess)
                    {
                        return Ok(await authDomain.GenerateToken(isValid.Data.ClientID, isValid.Data.SecretKey));

                    }
                    return Unauthorized(isValid);
                }
                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return StatusCode(503, errorManagerTool.SetError<Token>(ex, MethodBase.GetCurrentMethod()));
            }
        }
    }
}
