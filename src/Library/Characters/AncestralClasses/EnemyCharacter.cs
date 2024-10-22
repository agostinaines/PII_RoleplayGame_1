namespace Library.Characters.AncestralClasses;

public class EnemyCharacter : BaseCharacter
{
    public int VictoryPoints { get; set; }
    
    public EnemyCharacter(string name, int life, int victoryPoints): base(name, life)
    {
        this.VictoryPoints = victoryPoints;
    }
}