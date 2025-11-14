package model;

public record Card(String rank, String suit) {
    @Override
    public String toString() {
        return rank + " of " + suit;
    }
}
