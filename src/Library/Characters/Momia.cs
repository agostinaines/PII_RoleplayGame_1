using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Momia: EnemyCharacter
{
    public Momia(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
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
            // La momia reduce el daño recibido en un 5%
            int damageReceived = damage - (damage / 20);
            Health -= damageReceived;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
    
}