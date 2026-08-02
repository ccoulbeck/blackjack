namespace Blackjack.Models;

public class Deck
{
    private readonly List<Card> _cards = [];
    private readonly Random _rand = new();

    public Deck()
    {
        foreach (Suit suit in Enum.GetValues<Suit>())
        {
            foreach (Rank rank in Enum.GetValues<Rank>())
            {
                _cards.Add(new Card(rank, suit));
            }
        }
    }

    public Card Draw()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("Cannot draw from an empty deck.");
        }

        var topCard = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return topCard;
    }

    public void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            (_cards[j], _cards[i]) = (_cards[i], _cards[j]);
        }
    }
}
