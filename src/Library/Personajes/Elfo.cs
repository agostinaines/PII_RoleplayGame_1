using Library.Interfaces;

namespace Library.Personajes;

public class Elfo: PersonajeBase
{
    public Elfo(string name, int life) :  base(name,  life)
    {
    }
    
    public override void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto");
        }
        else
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("¡Mataste a tu enemigo!");
            }
        }
    }
}