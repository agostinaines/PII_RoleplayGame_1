using Library.Interfaces;

namespace Library.Personajes;

public class Elfo: PersonajeBase
{
    public Elfo(string name, int life) :  base(name,  life,0)
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

    public override bool IsHero()
    {
        return true;
    }
    public override bool IsEnemy()
    {
        return false;
    }
}