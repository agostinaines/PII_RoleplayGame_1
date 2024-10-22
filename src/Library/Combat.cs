using Library.Characters.AncestralClasses; // Asegúrate de que el namespace correcto está importado

namespace Library.Funcionalidades
{
    public class Combat
    {
        public void DoEncounter(List<HeroCharacter> heroes, List<EnemyCharacter> enemies)
        {
            while (heroes.Count != 0 && enemies.Count != 0)
            {

                for (int heroesI = 0; heroesI < heroes.Count; )
                {

                    enemies[heroesI % enemies.Count].ReceiveAttack(heroes[heroesI].AttackValue);

                    heroes[heroesI].ReceiveAttack(enemies[heroesI % enemies.Count].AttackValue);

                    if (enemies[heroesI % enemies.Count].Health <= 0)
                    {
                        heroes[heroesI].AddVictoryPoints(enemies[heroesI % enemies.Count].VictoryPoints);
                        
                        enemies.RemoveAt(heroesI % enemies.Count);
                    }
                    
                    if (heroes[heroesI].VictoryPoints >= 5 && heroes[heroesI].Health <= 0)
                    {
                        heroes[heroesI].Health = heroes[heroesI].MaxHealth;
                        
                        heroes[heroesI].VictoryPoints -= 5;
                    }
                    if (heroes[heroesI].Health <= 0)
                    {
                        heroes.RemoveAt(heroesI);
                    }
                    else
                    {
                        heroesI++; 
                    }
                    if (heroesI >= heroes.Count || enemies.Count == 0) break;
                }
            }
        }
    }
}


