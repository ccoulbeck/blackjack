import model.Card;
import model.Deck;

import java.util.ArrayList;
import java.util.List;

public class BlackjackApp {
    static void main() {
        BlackjackApp.play();
    }

    static void play() {
        Deck deck = new Deck();
        deck.shuffle();

        List<Card> playerHand = new ArrayList<>();
        List<Card> dealerHand = new ArrayList<>();

        playerHand.add(deck.drawCard());
        playerHand.add(deck.drawCard());

        dealerHand.add(deck.drawCard());
        dealerHand.add(deck.drawCard());

        System.out.printf("Your hand: %s\n", handToString(playerHand));
        System.out.printf("Dealer's hand: %s\n", handToString(dealerHand));
    }

    private static String handToString(List<Card> hand) {
        return hand.toString().replace("[", "").replace("]", "");
    }
}
