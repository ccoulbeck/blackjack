package model;

/**
 * Represents a playing card identified by a rank and a suit.
 *
 * @param rank the rank of the card
 * @param suit the suit of the card
 */
public record Card(Rank rank, Suit suit) {
    /**
     * Returns the integer value associated with card's rank.
     *
     * @return the integer value of the rank
     */
    public int value() {
        return rank.getValue();
    }

    /**
     * Returns a human-readable string representation of the card in the format {@code <rank> of <suit>} (e.g. "A of HEARTS").
     *
     * @return a string describing the card
     */
    @Override
    public String toString() {
        return String.format("%s of %s", rank, suit);
    }
}

