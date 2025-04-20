using System;
using System.Collections.Generic;

namespace FitnessApp
{
    public class GoalManager
    {
        private readonly Func<string, string[], int> _menuSelector;
        private List<string> currentGoals = new List<string>();

        // Constructor allows injecting a custom menu selector for testing
        public GoalManager(Func<string, string[], int>? menuSelector = null)
        {
            _menuSelector = menuSelector ?? MenuHelper.DisplayMenu;
        }

        public void ViewGoals()
        {
            if (currentGoals.Count == 0)
            {
                Console.WriteLine("\nNo current goals or challenges found. Add some to Get Moving!");
            }
            else
            {
                int goalIndex = _menuSelector("Select a goal/challenge to view:", currentGoals.ToArray());
                Console.WriteLine($"\nYou selected: {currentGoals[goalIndex]}");
                Console.WriteLine("Add a workout update (or press Enter to skip):");
                string update = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(update))
                {
                    currentGoals[goalIndex] += $" | Update: {update}";
                    Console.WriteLine("Update saved!");
                }
            }
        }

        public void AddNewGoal()
        {
            Console.WriteLine("\n--- Input New Goal/Challenge ---");

            Console.Write("Enter goal/challenge name: ");
            string name = Console.ReadLine();

            Console.Write("Enter end date (mm/dd/yyyy): ");
            string date = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || !DateTime.TryParse(date, out _))
            {
                Console.WriteLine("Invalid goal name or date. Please try again.");
                return;
            }

            Console.WriteLine($"What goal are you trying to reach by {date}? (Describe briefly):");
            string goalDescription = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(goalDescription))
            {
                Console.WriteLine("Goal description cannot be empty. Please try again.");
                return;
            }

            string[] types = { "Cardio Tracking", "Weight Tracking", "Other" };
            int typeIndex = _menuSelector("Select Workout Type", types);
            string selectedType = types[typeIndex];

            string goalEntry = $"{name} | Due: {date} | Goal: {goalDescription} | Type: {selectedType}";
            currentGoals.Add(goalEntry);

            Console.WriteLine("Goal saved!");
        }
    }
}
