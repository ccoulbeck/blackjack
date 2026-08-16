using System.Runtime.InteropServices;
using Blackjack.Models;

namespace Blackjack.Game;

public class BlackjackGame
{
    private const int Blackjack = 21;
    private const int DealerStandTotal = 17;
    private readonly Deck _deck = new();
    private readonly Hand _playerHand = new();
    private readonly Hand _dealerHand = new();

    public int PlayerTotal => _playerHand.Total;

    public int DealerTotal => _dealerHand.Total;

    public bool PlayerTurnComplete =>
        _playerHand.IsBust ||
        _playerHand.Total == Blackjack;

    public bool DealerTurnComplete => _dealerHand.Total >= DealerStandTotal;

    public bool PlayerIsBust => _playerHand.IsBust;

    public bool DealerIsBust => _dealerHand.IsBust;

    public bool PlayerHasBlackjack => _playerHand.Total == Blackjack;

    public void InitialiseNewRound()
    {
        _deck.Shuffle();

        for (int i = 0; i < 2; i++)
        {
            _playerHand.Add(_deck.Draw());
            _dealerHand.Add(_deck.Draw());
        }
    }

    public void Hit()
    {
        _playerHand.Add(_deck.Draw());
    }

    public List<(PlayerAction Action, int Total)> PlayDealerTurn()
    {
        var actions = new List<(PlayerAction, int)>();

        while (_dealerHand.Total < DealerStandTotal)
        {
            _dealerHand.Add(_deck.Draw());
            actions.Add(new(PlayerAction.Hit, _dealerHand.Total));
        }

        if (_dealerHand.Total > Blackjack)
            actions.Add(new(PlayerAction.Bust, _dealerHand.Total));
        else
            actions.Add(new(PlayerAction.Stand, _dealerHand.Total));

        return actions;
    }

    public GameResult DetermineWinner()
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
}
