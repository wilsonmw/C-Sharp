using System;

public class Wizard : Human{

    Random rando = new Random();
    public Wizard(string baba):base(baba){
        health = 50;
        intelligence = 25;
    }

    public int heal(){
        int healed = 10*intelligence;
        health = health+healed;
        Console.WriteLine(this.name + " healed himself by "+healed+" health.");
        return health;
    }

    public void fireball(Human name){
        
        int fired = rando.Next(20,51);
        name.health = name.health - fired;
        Console.WriteLine(this.name + " attacked " + name.name + " with a fireball for " + fired +" damage!");
    }
}