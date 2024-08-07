namespace RockPaperScissors.OOP
{
    public class ComputerPlayer : Player
    {
        private static readonly Random Random = new();

        public override Choice GetChoice()
        {
            var choices = Enum.GetValues(typeof(Choice));
            return (Choice)choices.GetValue(Random.Next(choices.Length))!;
        }
    }
}