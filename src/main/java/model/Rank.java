package model;

/**
 * Represents the rank of a playing card. Each rank has an associated
 * value.
 */
public enum Rank {
    ACE(11), KING(10), QUEEN(10), JACK(10), TEN(10), NINE(9), EIGHT(8), SEVEN(7), SIX(6), FIVE(5), FOUR(4), THREE(3), TWO(2);

    private final int value;

    Rank(int value) {
        this.value = value;
    }

    /**
     * Returns the integer value associated with this rank.
     */
    public int getValue() {
        return value;
    }
}
