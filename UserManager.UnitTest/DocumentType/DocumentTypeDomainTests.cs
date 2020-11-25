using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserManager.Domain.DocumentType;
using UserManager.Model.Common;
using UserManager.UnitTest.Config;

namespace UserManager.UnitTest.DocumentType
{
    [TestFixture()]
    public class DocumentTypeDomainTests
    {
        private DocumentTypeDomain documentDomain;
        private readonly Mock<IDocumentType> documentRepositoryMock = new Mock<IDocumentType>();
        private readonly AppSettingGlobal globalSettings = new AppSettingGlobal(new AppSettingsMock());

        [Test()]
        public async Task GetAllDocumentTypesTest()
        {
            //Arrange 
            documentDomain = new DocumentTypeDomain(documentRepositoryMock.Object, globalSettings);
            //Act
            var document = await documentDomain.GetAllDocumentTypes();
            //Assert
            Assert.NotNull(document);
            Assert.IsTrue(document.IsSuccess);
            Assert.NotNull(document.Data);
        }
    }
}