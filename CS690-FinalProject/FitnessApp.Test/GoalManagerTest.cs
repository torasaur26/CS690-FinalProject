using System;
using Xunit;
using FitnessApp;
using System.IO;

namespace FitnessApp.Test
{
    public class GoalManagerTest
    {
        [Fact]
        public void AddNewGoal_ShouldNotThrowException_WithValidInput()
        {
            // Arrange
            var fakeSelector = new Func<string, string[], int>((message, options) => 0); // Always picks the first option
            var goalManager = new GoalManager(fakeSelector);

            var input = new StringReader("Run 5k\n12/31/2025\nComplete 5k without walking\n"); // Simulate Console.ReadLine()
            Console.SetIn(input);

            // Act & Assert
            var exception = Record.Exception(() => goalManager.AddNewGoal());
            Assert.Null(exception); // Passes if no exception is thrown
        }
    }
}
