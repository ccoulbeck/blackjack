namespace Blackjack.Models;

public class Hand
{
    private readonly List<Card> _cards = [];
    public IReadOnlyList<Card> Cards => _cards;

    public void Add(Card card)
    {
        _cards.Add(card);
    }

    public int Value
    {
        get
        {
            int value = 0;

            foreach (var card in _cards)
            {
                value += card.Value;
            }

            return value;
        }
    }

    public bool IsBust => Value > 21;
}
