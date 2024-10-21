using Library.Characters.AncestralClasses;

namespace Library.Characters;

public class Dwarf: BaseCharacter
{

    public Dwarf(string name, int life) :  base(name, life)
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
            int damageReceived = damage - (damage * 30 / 100);
            Health -= damageReceived;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}
