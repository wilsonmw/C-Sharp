using System;
using System.Collections.Generic;

namespace uno
{
    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            reset();
            shuffle();
        }
        public Deck reset()
        {
            cards = new List<Card>();
            
            string[] wildVals = {"Wild","Wild","Wild","Wild","DrawFour","DrawFour","DrawFour","DrawFour"};
            
            string[] suits = {"Red","Blue","Green","Yellow"};
            string[] strVals = {"Zero","One","One","Two","Two","Three","Three","Four","Four","Five","Five","Six","Six","Seven","Seven","Eight","Eight","Nine","Nine","DrawTwo","DrawTwo","Skip","Skip","Reverse","Reverse"};
            int[] strScore = {0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,20,20,20,20,20,20};
            //for each suit, assemble set of cards.
            foreach(string suit in suits)
            {
                //build out individual suit cards 
                for(int i = 0; i < strVals.Length; i++){
                    Card noob = new Card(strVals[i], suit, strScore[i]);

                    cards.Add(noob);
                }
                    //build out wild suit cards 
            }
            for(int i = 0; i < wildVals.Length; i++){
                Card noob = new Card(wildVals[i], "Wild", 50);

                cards.Add(noob);
            }
            return this;
        }
        public Deck shuffle()
        {
            //iterate backwards through our deck
            Random rand = new Random();
            for(int end = cards.Count-1; end > 0; end--){
                //grab a random card
                int randx = rand.Next(end);
                Card temp = cards[randx];
                // swap it with out end value
                cards[randx] = cards[end];
                cards[end] = temp;
            }
            return this;
        }
        public Card deal()
        {
            if(cards.Count > 0){
            
            //grab top card
            Card res = cards[0];
            //remove said card
            cards.RemoveAt(0);
            //return said card.
            return res;
            } else {
                // reset();
                return deal();
            }
        }
    }
}
