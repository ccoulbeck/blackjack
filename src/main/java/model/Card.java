package model;

public record Card(String rank, String suit) {
    public int value() {
        return switch (rank) {
            case "Ace" -> 11;
            case "King", "Queen", "Jack" -> 10;
            default -> Integer.parseInt(rank);
        };
    }

    @Override
    public String toString() {
        return String.format("\"%s of %s\"", rank, suit);
    }
}
