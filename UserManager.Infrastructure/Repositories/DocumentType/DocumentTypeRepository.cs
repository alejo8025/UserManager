using System.Collections.Generic;
using UserManager.Domain.DocumentType;
using UserManager.Infrastructure.Common;
using UserManager.Model.Common;
using UserManager.Model.DocumentType;

namespace UserManager.Infrastructure.Repositories.DocumentType
{
    public class DocumentTypeRepository : GenericRepository, IDocumentType
    {
        private readonly AppSettingGlobal globalSettings;

        public DocumentTypeRepository(AppSettingGlobal settings) : base(settings)
        {
            globalSettings = settings;
        }

        public IEnumerable<DocumentTypeModel> GetAllDocumentTypes()
        {
            var userDb = GetAsync<DocumentTypeModel, DocumentTypeModel>(globalSettings.GetValue("SPGetAllDocumentTypes"), new DocumentTypeModel(), System.Data.CommandType.StoredProcedure).Result;
            return userDb;
        }
    }
}
