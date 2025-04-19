using Xunit;
using FitnessApp;

namespace FitnessApp.Test
{
    public class UserServiceTests
    {
        [Fact]
        public void Login_ShouldReturnTrue_WithValidInput()
        {
            var service = new UserService();
            bool result = service.Login("victoria", "secure123");
            Assert.True(result);
        }

        [Theory]
        [InlineData("", "pass")]
        [InlineData("user", "")]
        [InlineData("", "")]
        public void Login_ShouldReturnFalse_WithMissingFields(string username, string password)
        {
            var service = new UserService();
            bool result = service.Login(username, password);
            Assert.False(result);
        }

        [Fact]
        public void CreateAccount_ShouldReturnTrue_WithValidInput()
        {
            var service = new UserService();
            bool result = service.CreateAccount("victoria", "secure123");
            Assert.True(result);
        }

        [Theory]
        [InlineData("", "pass")]
        [InlineData("user", "")]
        [InlineData("", "")]
        public void CreateAccount_ShouldReturnFalse_WithMissingFields(string username, string password)
        {
            var service = new UserService();
            bool result = service.CreateAccount(username, password);
            Assert.False(result);
        }
    }
}
