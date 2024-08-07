namespace RockPaperScissors.OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("You are playing Rock Paper Scissors. Choose one of the options to play:");
                Console.WriteLine("1. Play against computer");
                Console.WriteLine("2. Play against friend");
                Console.WriteLine("3. Exit");

                Console.Write("Your Choice (1-3): ");
                if (!int.TryParse(Console.ReadLine(), out var gameOptionNumber) || gameOptionNumber < 1 || gameOptionNumber > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    continue;
                }

                if (gameOptionNumber == 3)
                {
                    Console.WriteLine("You chose: Exit");
                    break;
                }

                var numberOfRounds = GetNumberOfRounds();

                var game = GameFactory.CreateGame(gameOptionNumber, numberOfRounds);
                game.Play();
            }
        }

        private static int GetNumberOfRounds()
        {
            while (true)
            {
                Console.WriteLine("How many rounds do you want to play? Enter a number between 1 and 30:");
                if (int.TryParse(Console.ReadLine(), out var numberOfRounds) && numberOfRounds >= 1 && numberOfRounds <= 30)
                {
                    return numberOfRounds;
                }
                Console.WriteLine("Number of rounds must be between 1 and 30. Please try again.");
            }
        }
    }
}
/*
 This approach follows SOLID principles:
   
   Single Responsibility Principle (SRP): Each class has a single responsibility (e.g., HumanPlayer handles human input, ComputerPlayer handles computer input, RockPaperScissorsGame handles game logic).
   Open/Closed Principle (OCP): The GameFactory class can be extended to support more game types without modifying existing code.
   Liskov Substitution Principle (LSP): HumanPlayer and ComputerPlayer can be used interchangeably as they both inherit from Player.
   Interface Segregation Principle (ISP): Not applicable as there are no interfaces.
   Dependency Inversion Principle (DIP): The GameFactory class creates instances of the Game class, decoupling the creation logic from the main program logic.
   This setup provides a clean and maintainable code structure, making it easier to extend and test.
*/