using Blackjack.Game;
using Blackjack.Models;

var game = new BlackjackGame();

PrintHeader();

var result = PlayRound(game);

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

static GameAction ReadPlayerAction()
{
    while (true)
    {
        Console.WriteLine("Hit (h) or stand (s)?");

        var input = Console.ReadLine()?.Trim().ToLowerInvariant();

        switch (input)
        {
            case "h":
                return GameAction.Hit;
            case "s":
                return GameAction.Stand;
            default:
                Console.WriteLine("Invalid input. Enter 'h' or 's'");
                break;
        }
    }
}

static GameResult PlayRound(BlackjackGame game)
{
    game.InitialiseNewRound();

    if (game.PlayerHasBlackjack)
    {
        Console.WriteLine("Player has blackjack");
        return game.DetermineWinner();
    }

    Console.WriteLine($"Player total: {game.PlayerTotal}");

    while (!game.PlayerTurnComplete)
    {
        var action = ReadPlayerAction();

        if (action == GameAction.Stand)
        {
            Console.WriteLine($"Player stands at {game.PlayerTotal}");
            break;
        }

        game.Hit();

        if (game.PlayerIsBust)
        {
            Console.WriteLine($"Player busts at {game.PlayerTotal}");
            break;
        }
        else
            Console.WriteLine($"Player total: {game.PlayerTotal}");
    }

    if (!game.PlayerIsBust && !game.PlayerHasBlackjack)
    {
        Console.WriteLine($"Dealer total: {game.DealerTotal}");

        var actions = game.PlayDealerTurn();

        foreach (var (action, total) in actions)
        {
            switch (action)
            {
                case GameAction.Hit:
                    Console.WriteLine("Dealer hits");
                    Console.WriteLine($"Dealer total: {total}");
                    break;
                case GameAction.Stand:
                    Console.WriteLine($"Dealer stands at {total}");
                    break;
                case GameAction.Bust:
                    Console.WriteLine($"Dealer busts at {total}");
                    break;
            }
        }
    }

    return game.DetermineWinner();
}
