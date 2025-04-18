using System;
using System.Collections.Generic;

namespace FitnessApp
{
    public class GoalManager
    {
        private List<string> currentGoals = new List<string>();

        public void ViewGoals()
        {
            if (currentGoals.Count == 0)
            {
                Console.WriteLine("\nNo current goals or challenges found. Add some to Get Moving!");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
            else
            {
                int goalIndex = MenuHelper.DisplayMenu("Select a goal/challenge to view:", currentGoals.ToArray());
                Console.WriteLine($"\nYou selected: {currentGoals[goalIndex]}");
                Console.WriteLine("Add a workout update (or press Enter to skip):");
                string update = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(update))
                {
                    currentGoals[goalIndex] += $" | Update: {update}";
                    Console.WriteLine("Update saved!");
                }
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
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

            string[] types = { "Cardio Tracking", "Weight Tracking", "Other" };
            int typeIndex = MenuHelper.DisplayMenu("Select Workout Type", types);
            string selectedType = types[typeIndex];

            string goalEntry = $"{name} | Due: {date} | Type: {selectedType}";
            currentGoals.Add(goalEntry);

            Console.WriteLine("Goal saved! Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}

