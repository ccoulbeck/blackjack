using Blackjack.Models;

namespace Blackjack.Game;

public class BlackjackGame
{
    private readonly Deck _deck = new();
    private readonly Hand _playerHand = new();

    public void Start()
    {
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("|               Blackjack               |");
        Console.WriteLine("+---------------------------------------+");

        _deck.Shuffle();

        Console.WriteLine("Dealing cards to Player...");
        for (int i = 0; i < 2; i++)
        {
            _playerHand.Add(_deck.Draw());
        }

        PlayerTurn();
    }

    private void PlayerTurn()
    {
        Console.WriteLine($"Total: {_playerHand.Total}");

        while (_playerHand.Total < 21)
        {
            Console.WriteLine("Hit (h) or stand (s)?");

            switch ((Console.ReadLine() ?? "").Trim().ToLowerInvariant())
            {
                case "h":
                    _playerHand.Add(_deck.Draw());
                    break;
                case "s":
                    return;
                default:
                    Console.WriteLine("Invalid input. Enter 'h' or 's'");
                    break;
            }

            Console.WriteLine($"Total: {_playerHand.Total}");
        }

        if (_playerHand.IsBust)
            Console.WriteLine("Bust");
    }
}
