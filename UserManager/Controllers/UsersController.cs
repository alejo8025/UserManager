using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UserManager.Domain.Helper;
using UserManager.Domain.User;
using UserManager.Model.Common;
using UserManager.Model.User;

namespace UserManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : Controller
    {

        private readonly UserDomain userDomain;
        private readonly ErrorManagerTool errorManagerTool;

        public UsersController(IUser userRepository, AppSettingGlobal settings)
        {
            userDomain = new UserDomain(userRepository, settings);
            errorManagerTool = new ErrorManagerTool();
        }

        /// <summary>
        /// Method responsible for performing the authentication and generating the access token
        /// </summary>
        /// <returns>Token</returns>
        /// <response code="200">If the request is accepted and found sites in DB</response>
        /// <response code="401">Unauthorized customer</response> 
        [HttpGet]
        [Route("GetAllUsers")]
        [ProducesResponseType(typeof(Result<List<UserModelDto>>), 200)]
        [ProducesResponseType(typeof(Result<List<UserModelDto>>), 401)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var usersList = await userDomain.GetUserAll();
                return Ok(usersList);
            }
            catch (Exception ex)
            {
                return StatusCode(503, errorManagerTool.SetError<List<UserModelDto>>(ex, MethodBase.GetCurrentMethod()));
            }
        }

        [HttpPost]
        [Route("UpdateUser")]
        [ProducesResponseType(typeof(Result<UserModelDto>), 200)]
        [ProducesResponseType(typeof(Result<UserModelDto>), 401)]
        public async Task<IActionResult> UpdateUser(UpdateUserModel updateUserModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(updateUserModel.UserId.ToString()) && 
                    !string.IsNullOrEmpty(updateUserModel.Firstname) && 
                    !string.IsNullOrEmpty(updateUserModel.Lastname) &&
                    !string.IsNullOrEmpty(updateUserModel.Rol))
                {
                    var userUpdate = await userDomain.UpdateUser(updateUserModel);
                    return Ok(userUpdate);
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
