using System;
using Xunit;
using Moq;
using System.IO;
using FitnessApp;

namespace FitnessApp.Test
{
    public class NotificationsTests
    {
        [Fact]
        public void ChangeReminderTime_ShouldUpdateNotificationTime_WhenValidTimeIsEntered()
        {
            // Arrange
            var notifications = new Notifications();
            var stringWriter = new StringWriter();
            var stringReader = new StringReader("8:30 AM\n");
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            // Act
            notifications.ShowSettings();  

            // Assert
            string output = stringWriter.ToString();
            Assert.Contains("Reminder time updated to: 8:30 AM", output);
        }

        [Fact]
        public void SetupPushNotifications_ShouldSavePhoneNumber_WhenValidPhoneNumberIsEntered()
        {
            // Arrange
            var notifications = new Notifications();
            var stringWriter = new StringWriter();
            var stringReader = new StringReader("1\n123-456-7890\n");  
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            // Act
            notifications.ShowSettings();  

            // Assert
            string output = stringWriter.ToString();
            Assert.Contains("Phone number 123-456-7890 saved for notifications.", output);
        }

        [Fact]
        public void SetupPushNotifications_ShouldNotSavePhoneNumber_WhenInvalidPhoneNumberIsEntered()
        {
            // Arrange
            var notifications = new Notifications();
            var stringWriter = new StringWriter();
            var stringReader = new StringReader("1\n\n");  
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            // Act
            notifications.ShowSettings();  

            // Assert
            string output = stringWriter.ToString();
            Assert.Contains("Invalid phone number. Notifications not enabled.", output);
        }

        [Fact]
        public void ShowSettings_ShouldExit_WhenExitOptionIsSelected()
        {
            // Arrange
            var notifications = new Notifications();
            var stringWriter = new StringWriter();
            var stringReader = new StringReader("2\n");  
            Console.SetOut(stringWriter);
            Console.SetIn(stringReader);

            // Act
            notifications.ShowSettings();  

            // Assert
            string output = stringWriter.ToString();
            Assert.Contains("Returning to the main menu...", output);
        }

        
    }
}
