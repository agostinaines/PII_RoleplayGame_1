using Library.Interfaces;

namespace Library.Personajes;

public class Enano: PersonajeBase
{

    public Enano(string name, int life) : base(name, life)
    {
    }

    public void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        else
        {
            // El enano reduce un 10% del daño recibido
            int damageReceived = damage - (damage / 10);
            Health -= damageReceived;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("Mataste a ese enemigo");
            }
        }
    }
    
}
