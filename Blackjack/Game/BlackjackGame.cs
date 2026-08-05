using Blackjack.Models;

namespace Blackjack.Game;

public class BlackjackGame
{
    private readonly Deck _deck = new();
    private readonly Hand _playerHand = new();
    private readonly Hand _dealerHand = new();

    public void Start()
    {
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("|               Blackjack               |");
        Console.WriteLine("+---------------------------------------+");

        _deck.Shuffle();

        Console.WriteLine("Dealing initial cards...");
        for (int i = 0; i < 2; i++)
        {
            _playerHand.Add(_deck.Draw());
            _dealerHand.Add(_deck.Draw());
        }

        PlayerTurn();

        DealerTurn();
    }

    private void DealerTurn()
    {
        Console.WriteLine("-----------------------------------------");

        Console.WriteLine($"Dealer total: {_dealerHand.Total}");

        while (_dealerHand.Total < 17)
        {
            _dealerHand.Add(_deck.Draw());
            Console.WriteLine("Dealer hits");
            Console.WriteLine($"Dealer total: {_dealerHand.Total}");
        }

        if (_dealerHand.Total < 21)
            Console.WriteLine($"Dealer stands with {_dealerHand.Total}");
    }

    private void PlayerTurn()
    {
        Console.WriteLine("-----------------------------------------");

        Console.WriteLine($"Player total: {_playerHand.Total}");

        while (_playerHand.Total < 21)
        {
            Console.WriteLine("Hit (h) or stand (s)?");

            switch ((Console.ReadLine() ?? "").Trim().ToLowerInvariant())
            {
                case "h":
                    _playerHand.Add(_deck.Draw());
                    break;
                case "s":
                    Console.WriteLine($"Player stands at {_playerHand.Total}");
                    return;
                default:
                    Console.WriteLine("Invalid input. Enter 'h' or 's'");
                    break;
            }

            Console.WriteLine($"Player total: {_playerHand.Total}");
        }

        if (_playerHand.IsBust)
            Console.WriteLine("Bust");
    }
}
