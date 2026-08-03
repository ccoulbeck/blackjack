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
    }
}
