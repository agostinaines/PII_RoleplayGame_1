namespace Library.Characters.AncestralClasses;

public class HeroCharacter : BaseCharacter
{
    public int VictoryPoints { get; set; }

    public HeroCharacter(string name, int life) : base(name, life)
    {
        this.VictoryPoints = 0;
    }

    public void AddVictoryPoints(int points)
    {
        VictoryPoints += points;
    }
}