using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserManager.Domain.Rol;
using UserManager.Model.Common;
using UserManager.UnitTest.Config;

namespace UserManager.UnitTest.Rol
{
    [TestFixture()]
    public class RolDomainTests
    {
        private RolDomain rolDomain;
        private readonly Mock<IRol> rolRepositoryMock = new Mock<IRol>();
        private readonly AppSettingGlobal globalSettings = new AppSettingGlobal(new AppSettingsMock());

        [Test()]
        public async Task GetAllRolesTest()
        {
            //Arrange 
            rolDomain = new RolDomain(rolRepositoryMock.Object, globalSettings);
            //Act
            var roles = await rolDomain.GetAllRoles();
            //Assert
            Assert.NotNull(roles);
            Assert.IsTrue(roles.IsSuccess);
            Assert.NotNull(roles.Data);
        }
    }
}