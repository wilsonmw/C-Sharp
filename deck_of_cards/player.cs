using System.Collections.Generic;

public class Player{
    public string name;
    public List<Card> hand;

    public Player(string name){
        this.name = name;
        hand = new List<Card>();
    }
    
    public Card draw(Deck deck){
        Card drawnCard = deck.deal();
        hand.Add(drawnCard);
        return drawnCard;
    }

    public Card discard(int index){
        Card removedCard = hand[index];
        hand.Remove(removedCard);
        return removedCard;
    }
}