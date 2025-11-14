package model;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Deck {
    private final ArrayDeque<Card> cards;

    public Deck() {
        cards = new ArrayDeque<>();
        List<String> RANKS = List.of("2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A");
        List<String> SUITS = List.of("Hearts", "Diamonds", "Spades", "Clubs");
        for (String suit : SUITS) {
            for (String rank : RANKS) {
                cards.add(new Card(rank, suit));
            }
        }
        shuffle();
    }

    public void shuffle() {
        List<Card> temp = new ArrayList<>(cards);
        Collections.shuffle(temp);
        cards.clear();
        cards.addAll(temp);
    }

    public Card drawCard() {
        if (cards.isEmpty()) {
            throw new IllegalStateException("No cards in Deck");
        }
        return cards.removeFirst();
    }
}