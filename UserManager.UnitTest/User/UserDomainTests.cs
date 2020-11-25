using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserManager.Domain.User;
using UserManager.Model.Common;
using UserManager.Model.User;
using UserManager.UnitTest.Config;

namespace UserManager.UnitTest.User
{
    [TestFixture()]
    public class UserDomainTests
    {
        private UserDomain userDomain;
        private readonly Mock<IUser> userRepositoryMock = new Mock<IUser>();
        private readonly AppSettingGlobal globalSettings = new AppSettingGlobal(new AppSettingsMock());

        [Test()]
        public async Task GetUserAllTest()
        {
            //Arrange 
            userDomain = new UserDomain(userRepositoryMock.Object, globalSettings);
            //Act
            var users = await userDomain.GetUserAll();
            //Assert
            Assert.NotNull(users);
        }

        [Test()]
        public async Task UpdateUserTest()
        {
            //Arrange 
            UpdateUserModel updateUserModel = new UpdateUserModel
            {
                UserId = Guid.Parse("C90B8330-AF48-426D-BE43-B613749CC8B2"),
                Lastname = "Giraldo",
                Firstname = "Alejandro",
                Rol = "Administrador"
            };
            userDomain = new UserDomain(userRepositoryMock.Object, globalSettings);
            //Act
            var users = await userDomain.UpdateUser(updateUserModel);
            //Assert
            Assert.NotNull(users);
        }
    }
}