using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Golem: EnemyCharacter
{

    public Golem(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
    {
    }

    public override void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} ya está muerto.");
        }
        else
        {
            int damageReceived = damage - (damage * 60 / 100);
            Health -= damageReceived;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}