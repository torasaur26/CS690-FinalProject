namespace FitnessApp
{
    public class SettingsManager
    {
        private string notificationTime = "8:00 AM";
        private string phoneNumber = "";

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
                    case 0:
                        Console.Write("Enter new reminder time (e.g., 8:00 AM): ");
                        string inputTime = Console.ReadLine();
                        SetReminderTime(inputTime);
                        break;

                    case 1:
                        string[] notifyOptions = { "Yes", "No" };
                        int notifySelection = MenuHelper.DisplayMenu("Enable push notifications?", notifyOptions);

                        if (notifySelection == 0)
                        {
                            Console.Write("Enter your phone number (e.g., 123-456-7890): ");
                            string inputPhone = Console.ReadLine();
                            SetPhoneNumber(inputPhone);
                        }
                        else
                        {
                            Console.WriteLine("Push notifications not enabled.");
                        }
                        break;

                    case 2:
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

        public bool SetReminderTime(string inputTime)
        {
            if (DateTime.TryParse(inputTime, out DateTime validTime))
            {
                notificationTime = validTime.ToShortTimeString();
                Console.WriteLine($"Reminder time updated to: {notificationTime}");
                return true;
            }

            Console.WriteLine("Invalid time format. Reminder time not changed.");
            return false;
        }

        public bool SetPhoneNumber(string inputPhone)
        {
            if (!string.IsNullOrWhiteSpace(inputPhone))
            {
                phoneNumber = inputPhone;
                Console.WriteLine($"Phone number {phoneNumber} saved for notifications.");
                Console.WriteLine($"[Reminder @ {notificationTime}] Time to workout!");
                return true;
            }

            Console.WriteLine("Invalid phone number. Notifications not enabled.");
            return false;
        }
    }
}
