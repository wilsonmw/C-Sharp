public class Card{
    public string stringVal;
    public string suit;
    public int val;


    public Card(string suit, int val){
        this.suit = suit;
        this.val = val;
        if(val == 1){
            this.stringVal = "Ace";
        }
        if(val == 2){
            this.stringVal = "2";
        }
        if(val == 3){
            this.stringVal = "3";
        }
        if(val == 4){
            this.stringVal = "4";
        }
        if(val == 5){
            this.stringVal = "5";
        }
        if(val == 6){
            this.stringVal = "6";
        }
        if(val == 7){
            this.stringVal = "7";
        }
        if(val == 8){
            this.stringVal = "8";
        }
        if(val == 9){
            this.stringVal = "9";
        }
        if(val == 10){
            this.stringVal = "10";
        }
        if(val == 11){
            this.stringVal = "Jack";
        }
        if(val == 12){
            this.stringVal = "Queen";
        }
        if(val == 13){
            this.stringVal = "King";
        }
    }
}
