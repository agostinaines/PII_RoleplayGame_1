namespace Library.Personajes;

public class Orco: PersonajeBase
{
    public Orco(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
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

    
    public override bool IsHero()
    {
        return false;
    }
    public override bool IsEnemy()
    {
        return true;
    }
}