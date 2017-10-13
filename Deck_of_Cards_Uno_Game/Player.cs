using System.Collections.Generic;

namespace uno
{
    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        public Card draw(Deck decky)
        {
            Card noob = decky.deal();
            hand.Add(noob);
            return noob;
        }

        public Player draw(Deck decky, int num)
        {
            for(int i = 0; i < num; i++){
                this.draw(decky);
            }
            return this;
        }

        //Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.
        public Card discard(int idx)
        {
            if(idx < 0 || idx > hand.Count){
                System.Console.WriteLine("yo learn to count!");
                return null;
            } else {
                //remove
                Card res = hand[idx];
                hand.RemoveAt(idx);
                return res;
            }
        }
    }
}