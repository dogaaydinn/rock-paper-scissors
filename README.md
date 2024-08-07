# Rock Paper Scissors

This project is a console-based Rock Paper Scissors game. Players can play against the computer or against each other.

## Setup

1. Clone or download this project to your computer.
2. Open the project in Visual Studio or any C# IDE.
3. Run the project.

## How to Play

When you start the game, you can choose from the following options:

1. Play against the computer
2. Play against a friend
3. Exit

### Playing Against the Computer

1. Select "Play against the computer".
2. Enter the number of rounds you want to play (between 1 and 30).
3. The game will randomly decide who starts first.
4. Choose rock (r), paper (p), or scissors (s) each round.
5. The computer will make its choice, and the winner of each round will be displayed.
6. The game continues until one player reaches the win condition.

### Playing Against a Friend

1. Select "Play against a friend".
2. Enter the number of rounds you want to play (between 1 and 30).
3. The game will randomly decide who starts first.
4. Both players take turns choosing rock (r), paper (p), or scissors (s) each round.
5. The winner of each round will be displayed.
6. The game continues until one player reaches the win condition.

### Exiting the Game

1. Select "Exit(3)" to close the game.

## Game Rules

- Rock beats Scissors
- Scissors beat Paper
- Paper beats Rock

## Code Overview

The main logic of the game is implemented in the following methods:

- `PlayAgainstComputer`: Handles the game logic when playing against the computer.
- `PlayAgainstFriend`: Handles the game logic when playing against a friend.
- `GetPlayerChoice`: Gets the player's choice (rock, paper, or scissors).
- `IsPlayerWinner`: Determines if a player is the winner of the round based on their choices.

The game uses an enum `Choice` to represent the possible choices (Rock, Paper, Scissors).

Enjoy the game!

