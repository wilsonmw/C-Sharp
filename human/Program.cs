using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard wiz1 = new Wizard("Merlin");
            Ninja nin1 = new Ninja("George");
            Samurai sam1 = new Samurai("Samuel");
            sam1.Attack(nin1);
            sam1.Attack(wiz1);
            nin1.Attack(sam1);
            nin1.Attack(wiz1);
            wiz1.Attack(nin1);
            wiz1.Attack(sam1);

            nin1.steal(wiz1);
            sam1.meditate();
            wiz1.heal();
            wiz1.heal();
            wiz1.fireball(sam1);
            nin1.get_away();
            sam1.death_blow(nin1);
            wiz1.fireball(sam1);
            wiz1.fireball(nin1);
            wiz1.fireball(sam1);
            wiz1.fireball(nin1);
            wiz1.fireball(sam1);
            wiz1.fireball(nin1);
            sam1.death_blow(nin1);

        }
    }
}
