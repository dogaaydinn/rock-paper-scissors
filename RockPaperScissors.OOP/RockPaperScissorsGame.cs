namespace RockPaperScissors.OOP
{
    public class RockPaperScissorsGame : Game
    {
        public RockPaperScissorsGame(Player player1, Player player2, int numberOfRounds)
            : base(player1, player2, numberOfRounds) { }

        public override void Play()
        {
            var player1Score = 0;
            var player2Score = 0;

            for (int i = 0; i < NumberOfRounds; i++)
            {
                var player1Choice = Player1.GetChoice();
                var player2Choice = Player2.GetChoice();

                Console.Clear();
                Console.WriteLine($"Player 1 chose {player1Choice}");
                Console.WriteLine($"Player 2 chose {player2Choice}");

                if (player1Choice == player2Choice)
                {
                    Console.WriteLine("This round is a tie!");
                }
                else if (IsPlayerWinner(player1Choice, player2Choice))
                {
                    Console.WriteLine("Player 1 wins this round!");
                    player1Score++;
                }
                else
                {
                    Console.WriteLine("Player 2 wins this round!");
                    player2Score++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Final score - Player 1: {player1Score}, Player 2: {player2Score}");
            Console.WriteLine(player1Score > player2Score ? "Player 1 wins the game!" : "Player 2 wins the game!");
        }

        private bool IsPlayerWinner(Choice playerChoice, Choice opponentChoice)
        {
            return (playerChoice == Choice.Rock && opponentChoice == Choice.Scissors) ||
                   (playerChoice == Choice.Paper && opponentChoice == Choice.Rock) ||
                   (playerChoice == Choice.Scissors && opponentChoice == Choice.Paper);
        }
    }
}