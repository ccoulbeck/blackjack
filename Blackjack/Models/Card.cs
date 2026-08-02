namespace Blackjack.Models;

public record Card(Rank Rank, Suit Suit)
{
    public int Value => Rank switch
    {
        Rank.ACE => 11,
        Rank.KING or Rank.QUEEN or Rank.JACK => 10,
        _ => (int)Rank
    };

    public string DisplayName => $"{Rank} of {Suit}";

    public override string ToString()
    {
        return $"Card({Rank}, {Suit})";
    }
}
