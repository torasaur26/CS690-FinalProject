using System;

namespace FitnessApp
{
    public class Notifications
    {
        private string notificationTime = "8:00 AM";  
        private string phoneNumber = "Not set";

        public void ShowSettings()
        {
            bool inSettings = true;

            while (inSettings)
            {
                Console.Clear();
                Console.WriteLine("\n--- Settings ---");
                Console.WriteLine($"Current workout reminder time: {notificationTime}");
                Console.WriteLine($"Phone number for notifications: {phoneNumber}");

                string[] options = {
                    "Change Reminder Time",
                    "Setup Push Notifications",
                    "Exit Settings"
                };

                int selection = MenuHelper.DisplayMenu("Choose a setting to update:", options);

                switch (selection)
                {
                    case 0: // Change Reminder Time
                        Console.Write("Enter new reminder time (use '8:00 AM' format): ");
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
                        break;

                    case 1: // Setup Push Notifications
                        string[] notifyOptions = { "Yes", "No" };
                        int notifySelection = MenuHelper.DisplayMenu("Enable push notifications?", notifyOptions);

                        if (notifySelection == 0) // Yes
                        {
                            Console.Write("Enter your phone number (use '123-456-7890' format): ");
                            string inputPhone = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(inputPhone))
                            {
                                phoneNumber = inputPhone;
                                Console.WriteLine($"Phone number {phoneNumber} saved for notifications.");
                                Console.WriteLine($"[Reminder @ {notificationTime}] Time to Get Moving!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid phone number. Notifications not enabled.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Push notifications not enabled.");
                        }
                        break;

                    case 2: // Exit Settings
                        inSettings = false;
                        Console.WriteLine("Returning to the main menu...");
                        break;
                }

                if (inSettings)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
