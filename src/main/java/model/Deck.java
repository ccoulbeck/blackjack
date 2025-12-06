package model;

import java.util.*;

public class Deck {
    private final Deque<Card> cards;

    public Deck() {
        cards = new ArrayDeque<>();
        populateDeck();
        shuffle();
    }

    private void populateDeck() {
        List<String> ranks = List.of("Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King");
        List<String> suits = List.of("Clubs", "Diamonds", "Hearts", "Spades");
        for (String suit : suits) {
            for (String rank : ranks) {
                cards.add(new Card(rank, suit));
            }
        }
    }

    public void shuffle() {
        List<Card> shuffled = new ArrayList<>(cards);
        Collections.shuffle(shuffled);
        cards.clear();
        cards.addAll(shuffled);
    }

    public Optional<Card> draw() {
        return Optional.ofNullable(cards.poll());
    }
}
