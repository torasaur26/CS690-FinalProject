namespace FitnessApp
{
    public class UserService
    {
        public bool Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            return Login(username, password); // Use the overload
        }

        public bool Login(string username, string password)
        {
            // Real validation would go here
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            Console.WriteLine($"\nWelcome back, {username}!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }

        public void CreateAccount()
        {
            Console.Write("Choose a username: ");
            string newUser = Console.ReadLine();

            Console.Write("Choose a password: ");
            string newPassword = Console.ReadLine();

            CreateAccount(newUser, newPassword); // Use the overload
        }

        public bool CreateAccount(string username, string password)
        {
            // Real persistence would happen here
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            Console.WriteLine("\nAccount created successfully!");
            Console.WriteLine("Press any key to return to login...");
            Console.ReadKey();
            return true;
        }
    }
}
