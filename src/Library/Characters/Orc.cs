using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Orc: BaseCharacter
{
    public Orc(string name, int life, int victoryPoints) :  base(name, life)
    {
        this.VictoryPoints = victoryPoints;
    }
    
    public override void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} ya está muerto.");
        }
        else
        {
            // Orco recibe el daño sin reducción
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}