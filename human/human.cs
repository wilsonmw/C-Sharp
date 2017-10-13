using System;

public class Human{
    public string name;
    public int strength = 3;
    public int intelligence = 3;
    public int dexterity = 3;
    public int health = 100;

    protected Human(){}
    public Human(string name){
        this.name = name;
    }
    public Human(string name, int strength, int intelligence, int dexterity, int health){
        this.name = name;
        this.strength = strength;
        this.intelligence = intelligence;
        this.dexterity = dexterity;
        this.health = health;
    }
    public int Attack(object name){
        Human enemy = name as Human;
        if (enemy != null){
            int damage = 5*this.strength;
            enemy.health = enemy.health - damage;
            Console.WriteLine(this.name + " attacked " + enemy.name+" for "+damage+" health!");
        }
        
        return health;
    }
}
