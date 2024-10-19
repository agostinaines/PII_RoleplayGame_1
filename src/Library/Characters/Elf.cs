using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Elf: BaseCharacter
{
    public Elf(string name, int life) :  base(name,  life)
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
            // Daño directo sin modificaciones
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}