using Library.Interfaces;

namespace Library.Personajes;

public class Dwarf: BaseCharacter
{

    public Dwarf(string name, int life) :  base(name, life)
    {
    }

    public override void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        else
        {
            // El enano reduce un 30% del daño recibido
            int damageReceived = damage - (damage * 30 / 100);
            Health -= damageReceived;
            if (Health < 0)                             // aca capaz que hay que hacer un override para que mago y elfo usen la herencia a diferencia de enano, pero no se como funciona.
            {
                Health = 0;
                Console.WriteLine("Mataste a ese enemigo");
            }
        }
    }
    
}
