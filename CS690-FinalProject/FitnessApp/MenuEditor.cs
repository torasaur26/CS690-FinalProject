namespace FitnessApp
{
    public static class MenuHelper
    {
        public static int DisplayMenu(string title, string[] options)
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

