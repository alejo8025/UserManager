using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using UserManager.Domain.Login;
using UserManager.Model.Common;
using UserManager.Model.Login;
using UserManager.UnitTest.Config;

namespace UserManager.UnitTest.Login
{
    [TestFixture()]
    public class LoginDomainTests
    {
        private LoginDomain loginDomain;
        private readonly Mock<ILoginRepo> loginRepositoryMock = new Mock<ILoginRepo>();
        private readonly AppSettingGlobal globalSettings = new AppSettingGlobal(new AppSettingsMock());

        [Test()]
        public async Task GetUserTest()
        {
            //Arrange 
            UserLogin userLogin = new UserLogin
            {
                UserName = "alejandro.giraldo",
                Password = "alejandro.giraldo@+"
            };
            loginDomain = new LoginDomain(loginRepositoryMock.Object, globalSettings);
            //Act
            var users = await loginDomain.GetUser(userLogin);
            //Assert
            Assert.NotNull(users);
        }
    }
}