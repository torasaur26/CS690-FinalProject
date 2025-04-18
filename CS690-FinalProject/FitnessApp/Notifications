namespace FitnessApp
{
    public class SettingsManager
    {
        private string notificationTime = "Not Set";
        private string phoneNumber = "Not Set";

        public void ShowSettings()
        {
            Console.WriteLine("\n--- Settings ---");
            Console.WriteLine($"Current workout reminder time: {notificationTime}");

            Console.Write("Set a new reminder time (use 8:00 AM format): ");
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

            string[] notifyOptions = { "Yes", "No" };
            int notifySelection = MenuHelper.DisplayMenu("Would you like to receive push notifications?", notifyOptions);

            if (notifySelection == 0)
            {
                Console.Write("Enter your phone number (123-456-7890): ");
                string inputPhone = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(inputPhone))
                {
                    phoneNumber = inputPhone;
                    Console.WriteLine($"Phone number {phoneNumber} saved for notifications.");
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

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
