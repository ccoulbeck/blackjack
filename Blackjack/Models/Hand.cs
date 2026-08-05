namespace Blackjack.Models;

public class Hand
{
    private readonly List<Card> _cards = [];
    public IReadOnlyList<Card> Cards => _cards;

    public void Add(Card card)
    {
        _cards.Add(card);
    }

    public int Total
    {
        get
        {
            int total = 0;

            foreach (var card in _cards)
            {
                total += card.Value;
            }

            return total;
        }
    }

    public bool IsBust => Total > 21;
}
