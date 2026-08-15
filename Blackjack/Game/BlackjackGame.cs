using Blackjack.Models;

namespace Blackjack.Game;

public class BlackjackGame
{
    private const int Blackjack = 21;
    private const int DealerStandTotal = 17;
    private readonly Deck _deck = new();
    private readonly Hand _playerHand = new();
    private readonly Hand _dealerHand = new();

    public void Start()
    {
        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine("|               Blackjack               |");
        Console.WriteLine("+---------------------------------------+");

        _deck.Shuffle();

        for (int i = 0; i < 2; i++)
        {
            _playerHand.Add(_deck.Draw());
            _dealerHand.Add(_deck.Draw());
        }

        PlayerTurn();

        if (_playerHand.IsBust)
        {
            Console.WriteLine("Bust");
            Console.WriteLine("Dealer wins");
            return;
        }
        if (_playerHand.Total == Blackjack)
        {
            Console.WriteLine("Player wins");
            return;
        }

        DealerTurn();

        if (_dealerHand.IsBust)
        {
            Console.WriteLine("Bust");
            Console.WriteLine("Player wins");
            return;
        }

        if (_playerHand.Total == _dealerHand.Total)
        {
            Console.WriteLine("Push");
            return;
        }

        bool playerWins = _playerHand.Total > _dealerHand.Total;
        Console.WriteLine(playerWins ? "Player wins" : "Dealer wins");
    }

    private void DealerTurn()
    {
        Console.WriteLine($"Dealer total: {_dealerHand.Total}");

        while (_dealerHand.Total < DealerStandTotal)
        {
            _dealerHand.Add(_deck.Draw());
            Console.WriteLine("Dealer hits");
            Console.WriteLine($"Dealer total: {_dealerHand.Total}");
        }

        if (_dealerHand.Total < Blackjack)
            Console.WriteLine($"Dealer stands at {_dealerHand.Total}");
    }

    private void PlayerTurn()
    {
        Console.WriteLine($"Player total: {_playerHand.Total}");

        while (_playerHand.Total < Blackjack)
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
    }
}
