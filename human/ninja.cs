using System;

public class Ninja:Human{

    public Ninja(string baba):base(baba){
        dexterity = 175;
    }

    public void steal(Human name){
        health = health + 10;
        Attack(name);
        Console.WriteLine(this.name + " gained 10 health from stealing!");
    }

    public void get_away(){
        health = health - 15;
        Console.WriteLine(this.name + " got away, but lost 15 health.");
    }

}