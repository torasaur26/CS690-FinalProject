using System;
using System.Collections.Generic;

namespace FitnessApp
{
    class Program
    {
        static List<string> currentGoals = new List<string>();
        static string notificationTime = "Not Set"; 

        static void Main(string[] args)
        {
            bool loggedIn = false;

            while (!loggedIn)
            {
                string[] loginOptions = { "Login", "Create New Account" };
                int loginSelection = DisplayMenu("Welcome to Get Moving! Please select an option:", loginOptions);

                if (loginSelection == 0) // Login
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    // In a real app you'd check this against saved accounts
                    Console.WriteLine($"\nWelcome back, {username}!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    loggedIn = true;
                }
                else // Create account
                {
                    Console.Write("Choose a username: ");
                    string newUser = Console.ReadLine();

                    Console.Write("Choose a password: ");
                    string newPassword = Console.ReadLine();

                    // In a real app you'd save the account data
                    Console.WriteLine("\nAccount created successfully!");
                    Console.WriteLine("Please log in with your new credentials.");
                    Console.WriteLine("Press any key to return to login screen...");
                    Console.ReadKey();
                }
            }

            bool running = true;
            while (running)
            {
                string[] mainOptions = {
                    "View Current Goals/Challenges",
                    "Input New Goal/Challenge",
                    "Settings",
                    "Exit"
                };

                int mainSelection = DisplayMenu("Welcome to Get Moving!", mainOptions);

                switch (mainSelection)
                {
                    case 0: // View Goals
                        if (currentGoals.Count == 0)
                        {
                            Console.WriteLine("\nNo current goals or challenges found. Add some to Get Moving!");
                            Console.WriteLine("Press any key to return to the menu...");
                            Console.ReadKey();
                        }
                        else
                        {
                            int goalIndex = DisplayMenu("Select a goal/challenge to view:", currentGoals.ToArray());
                            Console.WriteLine($"\nYou selected: {currentGoals[goalIndex]}");
                            Console.WriteLine("Click to add a workout update (or press Enter to skip):");
                            string update = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(update))
                            {
                                currentGoals[goalIndex] += $" | Update: {update}";
                                Console.WriteLine("Update saved!");
                            }
                            Console.WriteLine("Press any key to return to the menu...");
                            Console.ReadKey();
                        }
                        break;

                    case 1: // Add New Goal
                        Console.WriteLine("\n--- Input New Goal/Challenge ---");

                        Console.Write("Enter workout name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter completion date (use mm/dd/yyyy format): ");
                        string date = Console.ReadLine();

                        string[] types = { "Cardio Tracking", "Weight Tracking", "Other" };
                        int typeIndex = DisplayMenu("Select Workout Type", types);
                        string selectedType = types[typeIndex];

                        string goalEntry = $"{name} | Due: {date} | Type: {selectedType}";
                        currentGoals.Add(goalEntry);

                        Console.WriteLine("Goal saved! Press any key to return to the menu...");
                        Console.ReadKey();
                        break;

                    case 2: // Settings
                        Console.WriteLine("\n--- Settings ---");
                        Console.WriteLine($"Current workout reminder time: {notificationTime}");

                        Console.Write("Set a new reminder time (e.g., 8:00 AM): ");
                        string inputTime = Console.ReadLine();

                        if (DateTime.TryParse(inputTime, out DateTime validTime))
                        {
                            notificationTime = validTime.ToShortTimeString();
                            Console.WriteLine($"Reminder time updated to: {notificationTime}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid time format. Reminder time not changed.");
                        }

                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey();
                        break;

                    case 3: // Exit
                        Console.WriteLine("Cliché inspirational quote! Goodbye!");
                        running = false;
                        break;
                }
            }
        }

        static int DisplayMenu(string title, string[] options)
        {
            int selected = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine(title + "\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("> " + options[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("  " + options[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    selected = (selected == 0) ? options.Length - 1 : selected - 1;
                else if (key == ConsoleKey.DownArrow)
                    selected = (selected == options.Length - 1) ? 0 : selected + 1;

            } while (key != ConsoleKey.Enter);

            Console.Clear();
            return selected;
        }
    }
}
