namespace RockPaperScissors.OOP
{
    public abstract class Game
    {
        protected Player Player1;
        protected Player Player2;
        protected int NumberOfRounds;

        protected Game(Player player1, Player player2, int numberOfRounds)
        {
            Player1 = player1;
            Player2 = player2;
            NumberOfRounds = numberOfRounds;
        }

        public abstract void Play();
    }
}