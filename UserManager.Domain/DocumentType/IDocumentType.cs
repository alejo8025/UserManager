using System.Collections.Generic;
using UserManager.Model.DocumentType;

namespace UserManager.Domain.DocumentType
{
    public interface IDocumentType
    {
        IEnumerable<DocumentTypeModel> GetAllDocumentTypes();
    }
}
