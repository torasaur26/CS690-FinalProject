namespace FitnessApp
{
    public class WorkoutLogger
    {
        private List<string> workoutEntries = new List<string>();

        public void LogWorkout()
        {
            Console.WriteLine("\n--- Log a New Workout ---");

            Console.Write("Enter workout type (e.g., Cardio, Strength, Yoga): ");
            string type = Console.ReadLine();

            Console.Write("Enter duration in minutes: ");
            string duration = Console.ReadLine();

            Console.Write("Enter any notes or comments: ");
            string notes = Console.ReadLine();

            string entry = $"{DateTime.Now.ToShortDateString()} - {type} - {duration} min - Notes: {notes}";
            workoutEntries.Add(entry);

            Console.WriteLine("Workout logged successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public void ViewWorkoutLog()
        {
            Console.WriteLine("\n--- Workout History ---");

            if (workoutEntries.Count == 0)
            {
                Console.WriteLine("No workouts logged yet.");
            }
            else
            {
                foreach (var entry in workoutEntries)
                {
                    Console.WriteLine(entry);
                }
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
