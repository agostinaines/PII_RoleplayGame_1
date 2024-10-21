using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Dragon: EnemyCharacter
{
    public Dragon(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
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
            // El dragón tiene una alta defensa y reduce el daño recibido en un 20%
            double damageReceived = damage * (1 - 0.20) * (1 - (DefenseValue / 100.0));

            Health -= (int)damageReceived;
            
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}
