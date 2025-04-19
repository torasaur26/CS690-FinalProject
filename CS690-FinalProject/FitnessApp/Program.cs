namespace FitnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var goalManager = new GoalManager();
            var settingsManager = new SettingsManager();

            bool loggedIn = false;

            while (!loggedIn)
            {
                string[] loginOptions = { "Login", "Create New Account" };
                int loginSelection = MenuHelper.DisplayMenu("Welcome to Get Moving! Please select an option:", loginOptions);

                if (loginSelection == 0)
                    loggedIn = userService.Login();
                else
                    userService.CreateAccount();
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

                int mainSelection = MenuHelper.DisplayMenu("Welcome to Get Moving!", mainOptions);

                switch (mainSelection)
                {
                    case 0:
                        goalManager.ViewGoals();
                        break;
                    case 1:
                        goalManager.InputGoal();
                        break;
                    case 2:
                        settingsManager.ShowSettings();
                        break;
                    case 3:
                        running = false;
                        Console.WriteLine("Thank you for using Get Moving! Goodbye.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}

