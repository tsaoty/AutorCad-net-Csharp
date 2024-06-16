using UtilityLibraries;

class Program
{
    static void Main(string[] args)
    {
        int row = 0;
        do
        {
            if (row == 0 || row >= 25)
                ResetConsole();
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            Console.WriteLine($"tty msg>Input: {input}");
            Console.WriteLine("ty msg> Begins with uppercase? " +
                $"{(input.StartsWithUpper() ? "Yes" : "No")}");
            Console.WriteLine();
            row += 4;
        } while (true);
        return;

        // Declare a ResetConsole local method
        void ResetConsole()
        {
            if (row > 0)
            {
                Console.WriteLine("tty msg> Press any key to continue...");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"tty msg> {Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press<Enter>:{Environment.NewLine}");
            row = 3;
        }
    }
}
