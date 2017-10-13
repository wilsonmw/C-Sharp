using System;
using System.Collections.Generic;
using System.Linq;

public class Deck{
    public List<Card> cards;



    public Deck(){
        cards = new List<Card>();
        List<string> suits = new List<string>();
        suits.Add("Diamonds");
        suits.Add("Hearts");
        suits.Add("Clubs");
        suits.Add("Spades");
        foreach (string suit in suits){
            for(int x = 1;x<=13;x++){
                Card newCard = new Card(suit, x);
                cards.Add(newCard);
            }
        }
    }

    public Deck shuffle(){
        Random randObj = new Random();
        for(int i=0;i<52;i++){
            int tempIdx = randObj.Next(0,52);
            Card temp = cards[i];
            cards[i]=cards[tempIdx];
            cards[tempIdx] = temp;
        }
        return this;
    }

    public Card deal(){
        Card dealtCard = cards[0];
        cards.Remove(dealtCard);
        return dealtCard;
    }

    public void reset(){
        this.cards = new List<Card>();
        List<string> suits = new List<string>();
        suits.Add("Diamonds");
        suits.Add("Hearts");
        suits.Add("Clubs");
        suits.Add("Spades");
        foreach (string suit in suits){
            for(int x = 1;x<=13;x++){
                Card newCard = new Card(suit, x);
                this.cards.Add(newCard);
            }
        }
    }
}