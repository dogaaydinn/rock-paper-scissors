start:
Console.WriteLine("You are playing Rock Paper Scissors. Choose one of options for playing..");
var random = new Random(); //required for random selection of the computer

var options = new List<string> { "1. play against computer", "2. play against friend", "3. exit" };
Console.WriteLine("Options:"); //writes
foreach (var option in options)
    Console.WriteLine(option);

int gameOptionNumber; // holds which of the options 1,2,3 to choose

Console.Write("Seçiminiz (1-3): ");
var playMode = Console.ReadLine();

try
{
    gameOptionNumber =
        Convert.ToInt32(
            playMode); //we need to convert it to inte since it is written as a string so that it can be processed

    switch (gameOptionNumber)
    {
        case 1:
            Console.WriteLine("Your Choice: play against computer");
            break;
        case 2:
            Console.WriteLine("Your Choice: play against friend");
            break;
        case 3:
            Console.WriteLine("You Choose: Exit");
            return;
        default:
            throw new Exception("Invalid Option. Please enter a valid option.");
    }
}
catch (FormatException)
{
    Console.WriteLine($"You cannot convert {playMode} to integer");
    goto start;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    goto start;
}

var numberOfRounds = 0; //wherever one of the players ends up, it is necessary for the condition expression

while (true) // when the player's input is correct
{
    Console.WriteLine("How many rounds do you want to play? Enter a number between 1 and 30:");
    try
    {
        numberOfRounds = Convert.ToInt32(Console.ReadLine());

        if (numberOfRounds is < 1 or > 30)
            Console.WriteLine("Number of rounds must be between 1 and 30. Please try again.");
        else
            break;
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a numeric value.");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

// string interpolation
Console.WriteLine($"You have chosen to play {numberOfRounds} rounds.");

var playerStarts =
    random.Next(2) ==
    0; //There are 2 players in the game (when playing against the computer) generates 0 and 1, random number generator
//player1 if true, false computer or player2
switch (gameOptionNumber)
{
    case 1:
        Console.WriteLine(playerStarts
            ? "Player starts the game."
            : "Computer starts the game."); //ternary is used, player start condition, if the condition is true, first if false, 2.
        PlayAgainstComputer(random, numberOfRounds);
        break;
    case 2:
        Console.WriteLine(playerStarts ? "Player 1 starts the game." : "Player 2 starts the game.");
        PlayAgainstFriend(random, numberOfRounds);
        break;
}

static void PlayAgainstComputer(Random random, int winCondition)
{
    var choices = Enum.GetValues(typeof(Choice)); // used to print enum values as an array
    var playerScore = 0;
    var computerScore = 0;
    var playerStarts = true;

    for (;
         playerScore < winCondition &&
         computerScore <
         winCondition;) //no start, no increase or decrease, condition => continue until player or computer reaches a certain score
    {
        Choice playerChoice, computerChoice;
        if (playerStarts)
        {
            playerChoice = GetPlayerChoice();
            computerChoice =
                (Choice)choices.GetValue(
                    random.Next(choices.Length))!; //randomly selects a random value from the computer enum
        }
        else
        {
            computerChoice =
                (Choice)choices.GetValue(
                    random.Next(choices.Length))!; //randomly selects value from computer enum - randomly
            playerChoice = GetPlayerChoice();
        }


        Console.WriteLine($"Computer chose {computerChoice}");

        if (IsPlayerWinner(playerChoice, computerChoice))
        {
            Console.WriteLine("You win this round!");
            playerScore++;
        }
        else if (IsPlayerWinner(computerChoice, playerChoice))
        {
            Console.WriteLine("Computer wins this round!");
            computerScore++;
        }
        else
        {
            Console.WriteLine("This round is a tie!");
        }

        playerStarts = !playerStarts; // to change respectively
    }

    Console.WriteLine($"Final score - Player: {playerScore}, Computer: {computerScore}");

    if (playerScore >= winCondition)
        Console.WriteLine("You win the game!");
    else if (computerScore >= winCondition)
        Console.WriteLine("Computer wins the game!");
    else
        Console.WriteLine("The game is a tie!"); // I just put it for control purposes
}

//only static methods can call static methods
static void PlayAgainstFriend(Random random, int winCondition)
{
    var player1Score = 0;
    var player2Score = 0;
    var playerStarts = true;

    for (;
         player1Score < winCondition &&
         player2Score <
         winCondition;) // written for player 1 or player 2 to play until the specified condition
    {
        Choice player1Choice, player2Choice; //I defined it this way because it will be taken on enum
        if (playerStarts) // player 1 starts when playerStart is true 
        {
            player1Choice = GetPlayerChoice(1);
            player2Choice = GetPlayerChoice(2);
        }
        else // player 2 starts when playerStart is true 
        {
            player2Choice = GetPlayerChoice(2);
            player1Choice = GetPlayerChoice(1);
        }

        Console.Clear();

        if (player1Choice == player2Choice)
        {
            Console.WriteLine("Both players chose the same. This round is a tie!");
        }
        else
        {
            if (IsPlayerWinner(player1Choice, player2Choice))
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

        playerStarts = !playerStarts; // changes at the end of each round
    }

    Console.Clear();
    Console.WriteLine($"Final score - Player 1: {player1Score}, Player 2: {player2Score}");

    if (player1Score >= winCondition)
        Console.WriteLine("Player 1 wins the game!");
    else
        Console.WriteLine("Player 2 wins the game!");
}

static Choice GetPlayerChoice(int playerNumber = 0) // player number indicates which player will be selected
{
    while
        (true) //as long as the player chooses one of the specified characters, the infinite loop continues until the player chooses a valid expression
    {
        if (playerNumber > 0)
            Console.Write($"Player {playerNumber}, choose rock (r), paper (p), or scissors (s): ");
        else
            Console.Write("Choose rock (r), paper (p), or scissors (s): ");
        Console.Clear();
        var input = Console.ReadLine()?.ToLower(); //converts to lower case if capitalised
        switch (input)
        {
            case "r"
                : // The reason for not using return here is again to increase the usage in the switch structure, we could also add property-return
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

static bool IsPlayerWinner(Choice playerChoice, Choice opponentChoice)
{
    return (playerChoice == Choice.Rock && opponentChoice == Choice.Scissors) || //stone beats scissors
           (playerChoice == Choice.Paper && opponentChoice == Choice.Rock) || //paper beats stone
           (playerChoice == Choice.Scissors && opponentChoice == Choice.Paper); //makas defeats the paper
}

internal enum Choice
{
    Rock,
    Paper,
    Scissors
}