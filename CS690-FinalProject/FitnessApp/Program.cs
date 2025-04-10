using System;
using System.Collections.Generic;

namespace FitnessApp
{
    class Program
    {
        static List<string> currentGoals = new List<string>();

        static void Main(string[] args)
        {
            string[] loginOptions = { "Login", "Create New Account" };
            int loginSelection = DisplayMenu("Welcome to Get Moving! Please select an option:", loginOptions);

            if (loginSelection == 0)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                Console.WriteLine($"\nWelcome back, {username}!");
            }
            else
            {
                Console.Write("Choose a username: ");
                string newUser = Console.ReadLine();

                Console.Write("Choose a password: ");
                string newPassword = Console.ReadLine();

                Console.WriteLine("\nYou made a Get Moving account. Please log in!");
                return;
            }

            bool running = true;
            while (running)
            {
                string[] mainOptions = {
                    "View Current Goals/Challenges",
                    "Input New Goal/Challenge",
                    "Exit"
                };

                int mainSelection = DisplayMenu("Welcome to Get Moving!", mainOptions);

                if (mainSelection == 0)
                {
                    if (currentGoals.Count == 0)
                    {
                        Console.WriteLine("\nNo current goals or challenges found. Add some to Get Moving!g");
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
                        }
                    }
                }
                else if (mainSelection == 1)
                {
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
                }
                else if (mainSelection == 2)
                {
                    Console.WriteLine("Cliché inspirational quote! Goodbye!");
                    running = false;
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


