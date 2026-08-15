using Blackjack.Game;
using Blackjack.Models;

var game = new BlackjackGame();

PrintHeader();

game.InitialiseNewRound();

Console.WriteLine($"Player total: {game.PlayerTotal}");

while (!game.PlayerTurnComplete)
{
    var action = ReadPlayerAction();

    if (action == PlayerAction.Stand)
    {
        Console.WriteLine($"Player stands at {game.PlayerTotal}");
        break;
    }

    game.Hit();

    Console.WriteLine($"Player total: {game.PlayerTotal}");
}

if (!game.PlayerIsBust && !game.PlayerHasBlackjack)
{
    Console.WriteLine($"Dealer total: {game.DealerTotal}");

    game.PlayDealerTurn();
}

GameResult result = game.DetermineWinner();

switch (result)
{
    case GameResult.PlayerWins:
        Console.WriteLine("Player wins");
        break;
    case GameResult.DealerWins:
        Console.WriteLine("Dealer wins");
        break;
    case GameResult.Push:
        Console.WriteLine("Push");
        break;
}

static void PrintHeader()
{
    Console.WriteLine("+---------------------------------------+");
    Console.WriteLine("|               Blackjack               |");
    Console.WriteLine("+---------------------------------------+");
}

static PlayerAction ReadPlayerAction()
{
    while (true)
    {
        Console.WriteLine("Hit (h) or stand (s)?");

        var input = Console.ReadLine()?.Trim().ToLowerInvariant();

        switch (input)
        {
            case "h":
                return PlayerAction.Hit;
            case "s":
                return PlayerAction.Stand;
            default:
                Console.WriteLine("Invalid input. Enter 'h' or 's'");
                break;
        }
    }
}
