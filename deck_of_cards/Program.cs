using System;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();

            myDeck.shuffle();
            
            Player me = new Player("Matt");
            me.draw(myDeck);
            me.draw(myDeck);
            me.draw(myDeck);
            me.draw(myDeck);
            me.draw(myDeck);
            foreach (Card some in me.hand){
                Console.WriteLine(some.stringVal + " of " + some.suit);
            }

        }
    }
}
