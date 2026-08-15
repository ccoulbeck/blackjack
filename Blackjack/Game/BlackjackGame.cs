using System.Collections;
using System.Diagnostics;
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

        if (!_playerHand.IsBust && _playerHand.Total != Blackjack)
        {
            DealerTurn();
        }

        GameResult result = DetermineWinner();

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
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private GameResult DetermineWinner()
    {
        if (_playerHand.IsBust)
            return GameResult.DealerWins;

        if (_dealerHand.IsBust)
            return GameResult.PlayerWins;

        if (_playerHand.Total > _dealerHand.Total)
            return GameResult.PlayerWins;

        if (_playerHand.Total < _dealerHand.Total)
            return GameResult.DealerWins;

        return GameResult.Push;
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

    private static PlayerAction ReadPlayerAction()
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
                    Console.WriteLine("Invalid input. Enter");
                    break;
            }

        }
    }

    private void PlayerTurn()
    {
        Console.WriteLine($"Player total: {_playerHand.Total}");

        while (_playerHand.Total < Blackjack)
        {
            var action = ReadPlayerAction();

            if (action == PlayerAction.Stand)
            {
                Console.WriteLine($"Player stands at {_playerHand.Total}");
                return;
            }

            _playerHand.Add(_deck.Draw());

            Console.WriteLine($"Player total: {_playerHand.Total}");
        }
    }
}
