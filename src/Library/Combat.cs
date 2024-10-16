using Library.Interfaces;


namespace Library;
using Library.Personajes;

public class Combat 
{
    public static void HeroAttacksEnemy(PersonajeBase hero, PersonajeBase enemy)
    {
        if (hero.IsHero() && enemy.IsEnemy())
        {
            enemy.ReceiveAttack(hero.AttackValue);
            if (enemy.Health <= 0)
            {
                hero.AddVictoryPoints(enemy.VictoryPoints);
            }
        }
    }
    
}
