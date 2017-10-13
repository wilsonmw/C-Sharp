using System;

public class Samurai:Human{

    public static int count = 0;
    public Samurai(string baba):base(baba){
        health = 200;
        count ++;
    }

    public void death_blow(Human name){
        if(name.health < 50){
            name.health = 0;
            Console.WriteLine(this.name+" attacked "+name.name+" with a Death Blow and "+name.name+" is dead!");
        }
        else{
            Console.WriteLine(this.name+" attacked " + name.name + " with a Death Blow but didn't do any damage.");
        }
    }

    public void meditate(){
        health = 200;
        Console.WriteLine(this.name+" meditated and returned to 200 health");
    }

    public void how_many(){
        Console.WriteLine("There are currently " + count + " samurais in existence.");
    }


}