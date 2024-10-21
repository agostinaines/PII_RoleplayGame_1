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
            // El enano reduce un 20% del daño, además del DefenseValue
            double damageReceived = damage * (1 - 0.30) * (1 - (DefenseValue / 100.0));

            Health -= (int)damageReceived;

            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}
