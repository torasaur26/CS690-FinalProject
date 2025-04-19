using Xunit;
using FitnessApp;

namespace FitnessApp.Test
{
    public class UserServiceTests
    {
        [Fact]
        public void ValidateLogin_WithValidCredentials_ReturnsTrue()
        {
            var service = new UserService();
            bool result = service.ValidateLogin("user1", "pass123");
            Assert.True(result);
        }

        [Fact]
        public void ValidateLogin_WithEmptyUsername_ReturnsFalse()
        {
            var service = new UserService();
            bool result = service.ValidateLogin("", "pass123");
            Assert.False(result);
        }

        [Fact]
        public void CreateAccount_WithValidInput_ReturnsTrue()
        {
            var service = new UserService();
            bool result = service.CreateAccount("newuser", "securepass");
            Assert.True(result);
        }

        [Fact]
        public void CreateAccount_WithEmptyPassword_ReturnsFalse()
        {
            var service = new UserService();
            bool result = service.CreateAccount("newuser", "");
            Assert.False(result);
        }
    }
}

}