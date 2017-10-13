using System;
using System.Collections.Generic;

namespace uno
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Clear();
            Console.WriteLine("Welcome to Uno for console...");
            Console.Write("\nHow many players? (2-10): ");
            string playerprompt = Console.ReadLine();
            int numPlayers = Int32.Parse(playerprompt);
            int currentPlayeridx = 0; 
            Table table1 = new Table(numPlayers);

            //startgame
            // Console.Clear();
            Console.WriteLine("Uno for console is ready to play...");
            Console.Write("\nPress any key when all players are ready...");
            Console.ReadLine();
            
            Console.Clear();
            table1.gamestatus = true;
            
            while(table1.gamestatus == true && table1.tablestatus ==true){
                
                Player currentPlayer= table1.currPlayers[currentPlayeridx];
                bool userCanDraw = true;
                Console.WriteLine("Player " + currentPlayer.name + ", it's your turn. ");
                Console.Write("\nCards are secret, everyone but : " + currentPlayer.name + ", Close your eyes! haha");
                Console.ReadLine();

                Console.Clear();
                Console.Write("========== Your Hand: =======");
                Console.Write("\n========= Playable Cards ==================");
                
                //get playable cards. 
                List<Card> playableCards = new List<Card>();
                List<Card> nonPlayableCards = new List<Card>();
                
                // parsing cards for the user, because this is a computer.  
                Card currentDiscard = table1.discardPile[table1.discardPile.Count-1];
                Console.WriteLine(currentDiscard);
                foreach (Card card in table1.discardPile){
                    Console.WriteLine(card.suit + " " + card.strVal);
                }
                playableCards.Clear();
                nonPlayableCards.Clear();
                foreach(Card card in currentPlayer.hand){
                    if(card.suit == currentDiscard.suit || card.strVal == currentDiscard.strVal || card.suit == "Wild")
                    {
                        playableCards.Add(card);
                    } else {
                        nonPlayableCards.Add(card);
                    }

                }

                for(int i = 0; i < playableCards.Count; i++){
                    int option = i+1;
                    Console.Write("\n"+option+") "+playableCards[i].suit+" "+playableCards[i].strVal);
                }
                    Console.Write("\n");

                Console.Write("\n========= Non Playable Cards ==================");
                for(int i = 0; i < nonPlayableCards.Count; i++){
                    Console.Write("\n  "+nonPlayableCards[i].suit+" "+nonPlayableCards[i].strVal);
                }
                    Console.Write("\n");

                Console.Write("\n========= Current Card on top ==================");
                Console.Write("\n  "+currentDiscard.suit+" | "+currentDiscard.strVal);
                
                Console.Write("\n========= What do you want to do  ==================");
                Console.Write("\n");
                Console.Write("\n");
                Console.Write("\n Pick a card to play (enter the number from (Playable Cards)");
                if(userCanDraw){
                    Console.Write("\n Press 'd' to draw a card");
                }
                Console.Write("\n");
                string response = Console.ReadLine();
                Console.WriteLine(response);

                if(response == "d" && userCanDraw == true){
                    currentPlayer.draw(table1.drawPile);
                    userCanDraw = false;
                    //=======================================================================
                    Console.Clear();
                    Console.Write("========== Your Hand: =======");
                    Console.Write("\n========= Playable Cards ==================");
                    
                    // parsing cards for the user, because this is a computer.  
                    playableCards.Clear();
                    nonPlayableCards.Clear();
                    foreach(Card card in currentPlayer.hand){
                        if(card.suit == currentDiscard.suit || card.strVal == currentDiscard.strVal || card.suit == "Wild")
                        {
                            playableCards.Add(card);
                        } else {
                            nonPlayableCards.Add(card);
                        }

                    }

                    for(int i = 0; i < playableCards.Count; i++){
                        int option = i+1;
                        Console.Write("\n"+option+") "+playableCards[i].suit+" "+playableCards[i].strVal);
                    }
                        Console.Write("\n");

                    Console.Write("\n========= Non Playable Cards ==================");
                    for(int i = 0; i < nonPlayableCards.Count; i++){
                        Console.Write("\n  "+nonPlayableCards[i].suit+" "+nonPlayableCards[i].strVal);
                    }
                        Console.Write("\n");

                    Console.Write("\n========= Current Card on top ==================");
                    Console.Write("\n  "+currentDiscard.suit+" | "+currentDiscard.strVal);
                    
                    Console.Write("\n========= What do you want to do  ==================");
                    Console.Write("\n");
                    Console.Write("\n Pick a card to play (enter the number from (Playable Cards)");
                    if(userCanDraw){
                        Console.Write("\n Press 'd' to draw a card");
                    }
                    Console.Write("\n");
                    response = Console.ReadLine();
                    Console.WriteLine(response);

                    if(response == "d" && userCanDraw == true){
                        currentPlayer.draw(table1.drawPile);
                        userCanDraw = false;
                    }
                    //===================================================================
                }
                int cardoptiontoremove = Int32.Parse(response);
                Card cardtoremove = currentPlayer.hand[cardoptiontoremove];
                currentPlayer.hand.RemoveAt(cardoptiontoremove); 
                table1.discardPile.Add(cardtoremove);
                if(currentPlayer.hand.Count == 0){
                    table1.tablestatus = false; 
                    Console.WriteLine(currentPlayer.name + " has won! Game resetting -- we will soon keep score too!");
                } else {
                    if(currentPlayeridx == table1.currPlayers.Count - 1){
                        currentPlayeridx = 0;
                    } else {
                        currentPlayeridx ++;
                    }
                }                       
             }        
        }
    }
}
