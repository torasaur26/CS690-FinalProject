using Xunit;
using FitnessApp;

public class UserServiceTests
{
    [Fact]
    public void Login_ShouldReturnTrue_WithValidCredentials()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        bool result = userService.Login("validUsername", "validPassword");
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Login_ShouldReturnFalse_WithInvalidCredentials()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        bool result = userService.Login("", "");
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CreateAccount_ShouldReturnTrue_WithValidCredentials()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        bool result = userService.CreateAccount("newUser", "newPassword");
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CreateAccount_ShouldReturnFalse_WithEmptyUsername()
    {
        // Arrange
        var userService = new UserService();
        
        // Act
        bool result = userService.CreateAccount("", "password");
        
        // Assert
        Assert.False(result);
    }
}
