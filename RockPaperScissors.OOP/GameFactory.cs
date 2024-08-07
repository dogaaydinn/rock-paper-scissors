namespace RockPaperScissors.OOP
{
    public static class GameFactory
    {
        public static Game CreateGame(int gameOption, int numberOfRounds)
        {
            switch (gameOption)
            {
                case 1:
                    return new RockPaperScissorsGame(new HumanPlayer(1), new ComputerPlayer(), numberOfRounds);
                case 2:
                    return new RockPaperScissorsGame(new HumanPlayer(1), new HumanPlayer(2), numberOfRounds);
                default:
                    throw new ArgumentException("Invalid game option.");
            }
        }
    }
}