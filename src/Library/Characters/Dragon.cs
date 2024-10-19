namespace Library.Personajes;

public class Dragon: BaseCharacter
{
    public Dragon(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
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
            // El dragón tiene una alta defensa y reduce el daño recibido en un 20%
            int damageReceived = damage - (damage / 5);
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
