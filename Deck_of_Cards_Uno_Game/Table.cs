using System;
using System.Collections.Generic;

namespace uno
{
    public class Table
    {
        public Deck drawPile;
        public List<Card> discardPile;
        public List<Player> currPlayers;
        public bool direction = true;
        public bool gamestatus = false;
        public bool tablestatus = false;
    

        public Table(int numPlayers)
        {
            //create the drawPile,currnet list of players, and discard pile list.
            drawPile = new Deck();                    
            currPlayers = new List<Player>();
            discardPile = new List<Card>();

            //create the game players... 
            for(int i = 1; i < numPlayers+1; i++){
                // Console.Clear();   
                Console.Write("Enter the player "+i+" name: ");
                string playerName = Console.ReadLine();
                Player Name = new Player(playerName);
                Console.WriteLine("Here we are testing...");
                currPlayers.Add(Name);
                Name.draw(drawPile, 7);               
                }

            //move 1 card to discard pile, after creating users. 1 card is needed to start the game. 
            discardPile.Add(drawPile.deal());
            tablestatus = true;
        }


    }
}