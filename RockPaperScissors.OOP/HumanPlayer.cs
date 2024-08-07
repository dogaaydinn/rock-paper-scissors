namespace RockPaperScissors.OOP
{
    public class HumanPlayer : Player
    {
        private readonly int _playerNumber;

        public HumanPlayer(int playerNumber)
        {
            _playerNumber = playerNumber;
        }

        public override Choice GetChoice()
        {
            while (true)
            {
                Console.Write(_playerNumber > 0 ? $"Player {_playerNumber}, choose rock (r), paper (p), or scissors (s): " : "Choose rock (r), paper (p), or scissors (s): ");
                var input = Console.ReadLine()?.ToLower();
                switch (input)
                {
                    case "r":
                    case "rock":
                        return Choice.Rock;
                    case "p":
                    case "paper":
                        return Choice.Paper;
                    case "s":
                    case "scissors":
                        return Choice.Scissors;
                    default:
                        Console.WriteLine("Invalid choice. Please choose rock (r), paper (p), or scissors (s).");
                        break;
                }
            }
        }
    }
}