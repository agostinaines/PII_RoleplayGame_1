namespace Library.Personajes;

public class Momia: PersonajeBase
{
    public Momia(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
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

    public override bool IsHero()
    {
        return false;
    }
    public override bool IsEnemy()
    {
        return true;
    }
}