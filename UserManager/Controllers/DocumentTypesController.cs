using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UserManager.Domain.DocumentType;
using UserManager.Domain.Helper;
using UserManager.Model.Common;
using UserManager.Model.DocumentType;

namespace UserManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypesController : Controller
    {

        private readonly DocumentTypeDomain documentTypeDomain;
        private readonly ErrorManagerTool errorManagerTool;

        public DocumentTypesController(IDocumentType documentRepository, AppSettingGlobal settings)
        {
            documentTypeDomain = new DocumentTypeDomain(documentRepository, settings);
            errorManagerTool = new ErrorManagerTool();
        }

        /// <summary>
        /// Method responsible for performing the authentication and generating the access token
        /// </summary>
        /// <returns>Token</returns>
        /// <response code="200">If the request is accepted and found sites in DB</response>
        /// <response code="401">Unauthorized customer</response> 
        [HttpGet]
        [Route("GetAllDocumentTypes")]
        [ProducesResponseType(typeof(Result<List<DocumentTypeModel>>), 200)]
        [ProducesResponseType(typeof(Result<List<DocumentTypeModel>>), 401)]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            try
            {
                var rolesList = await documentTypeDomain.GetAllDocumentTypes();
                return Ok(rolesList);
            }
            catch (Exception ex)
            {
                return StatusCode(503, errorManagerTool.SetError<List<DocumentTypeModel>>(ex, MethodBase.GetCurrentMethod()));
            }
        }
    }
}
