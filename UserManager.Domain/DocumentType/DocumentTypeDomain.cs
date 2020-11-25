using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.Model.Common;
using UserManager.Model.DocumentType;

namespace UserManager.Domain.DocumentType
{
    public class DocumentTypeDomain
    {
        private readonly IDocumentType iDocumentType;
        private readonly AppSettingGlobal globalSettings;
        public DocumentTypeDomain(IDocumentType documentService, AppSettingGlobal settings)
        {
            iDocumentType = documentService;
            globalSettings = settings;
        }

        public async Task<Result<List<DocumentTypeModel>>> GetAllDocumentTypes()
        {
            var result = new Result<List<DocumentTypeModel>> { Data = new List<DocumentTypeModel>() };
            var documentTypes = iDocumentType.GetAllDocumentTypes();
            if (documentTypes != null)
            {
                result.IsSuccess = true;
                result.Data = documentTypes.ToList();
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
