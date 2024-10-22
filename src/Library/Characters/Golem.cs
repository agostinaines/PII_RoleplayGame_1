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
            //El golem reduce un 60% del daño, ademas del DefenseValue
            double damageReceived = damage * (1 - 0.6) * (1 - (DefenseValue / 100.0));

            Health -= (int)damageReceived;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}