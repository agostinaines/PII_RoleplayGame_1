using Library.Characters.AncestralClasses;
using Library.Interfaces;

namespace Library.Funcionalidades;

public class Combat
{
    public void DoEncounter(List<HeroCharacter> heroes, List<EnemyCharacter> enemies)
    {
        while (heroes.Count != 0 || enemies.Count != 0)
        {
            if (heroes.Count > enemies.Count)
            {
                int enemiesI = 0;
                int heroesI = 0;

                while (enemiesI < enemies.Count)
                {
                    heroes[heroesI].ReceiveAttack(enemies[enemiesI].AttackValue);
                    if (heroes[heroesI].Health <= 0)
                    {
                        heroes.RemoveAt(heroesI);
                    }
                    enemiesI++;
                    heroesI++;
                }

                enemiesI = 0;
                heroesI = 0;
                while (heroesI < heroes.Count)
                {
                    enemies[enemiesI].ReceiveAttack(heroes[heroesI].AttackValue);
                    if (enemies[enemiesI].Health <= 0)
                    {
                        heroes[heroesI].AddVictoryPoints(enemies[enemiesI].VictoryPoints);
                        if (heroes[heroesI].VictoryPoints >= 5)
                        {
                            heroes[heroesI].Health = heroes[heroesI].MaxHealth;
                            heroes[heroesI].VictoryPoints -= 5;
                        }
                        enemies.RemoveAt(enemiesI);
                    }
                    
                    if (enemiesI == enemies.Count - 1)
                    {
                        enemiesI = 0;
                    }
                    else
                    {
                        enemiesI++;
                    }

                    heroesI++;
                }
            }
            
            
            if (heroes.Count < enemies.Count)
            {
                int enemiesI = 0;
                int heroesI = 0;
                while (enemiesI < enemies.Count)
                {
                    heroes[heroesI].ReceiveAttack(enemies[enemiesI].AttackValue);
                    if (heroes[heroesI].Health <= 0)
                    {
                        heroes.RemoveAt(heroesI);
                    }
                    
                    if (heroesI == heroes.Count - 1)
                    {
                        heroesI = 0;
                    }
                    else
                    {
                        heroesI++;
                    }

                    enemiesI++;
                }
                
                enemiesI = 0;
                heroesI = 0;

                while (heroesI < heroes.Count)
                {
                    enemies[enemiesI].ReceiveAttack(heroes[heroesI].AttackValue);
                    if (enemies[enemiesI].Health <= 0)
                    {
                        heroes[heroesI].AddVictoryPoints(enemies[enemiesI].VictoryPoints);
                        if (heroes[heroesI].VictoryPoints >= 5)
                        {
                            heroes[heroesI].Health = heroes[heroesI].MaxHealth;
                            heroes[heroesI].VictoryPoints -= 5;
                        }
                        enemies.RemoveAt(enemiesI);
                    }
                    enemiesI++;
                    heroesI++;
                }
            }
            
            
            if (heroes.Count == enemies.Count)
            {
                int enemiesI = 0;
                int heroesI = 0;
                
                while (enemiesI < enemies.Count)
                {
                    heroes[heroesI].ReceiveAttack(enemies[enemiesI].AttackValue);
                    if (heroes[heroesI].Health <= 0)
                    {
                        heroes.RemoveAt(heroesI);
                    }
                    enemiesI++;
                    heroesI++;
                }
                
                enemiesI = 0;
                heroesI = 0;

                while (heroesI < heroes.Count)
                {
                    enemies[enemiesI].ReceiveAttack(heroes[heroesI].AttackValue);
                    if (enemies[enemiesI].Health <= 0)
                    {
                        heroes[heroesI].AddVictoryPoints(enemies[enemiesI].VictoryPoints);
                        if (heroes[heroesI].VictoryPoints >= 5)
                        {
                            heroes[heroesI].Health = heroes[heroesI].MaxHealth;
                            heroes[heroesI].VictoryPoints -= 5;
                        }
                        enemies.RemoveAt(enemiesI);
                    }
                    enemiesI++;
                    heroesI++;
                }
            }
        }
    }
}