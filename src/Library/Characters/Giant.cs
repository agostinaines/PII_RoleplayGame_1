using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Giant : EnemyCharacter
{
    public Giant(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
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
            // El gigante tiene una alta defensa y reduce el daño recibido en un 30%
            int damageReceived = damage - (damage / (10/3));
            Health -= damageReceived;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}