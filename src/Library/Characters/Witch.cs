using Library.Characters.AncestralClasses;
using Library.Items;

namespace Library.Characters;

public class Witch: EnemyCharacter
{
    public List<Spell> Spells { get; set; }

    public Witch(string name, int life, int victoryPoints) :  base(name, life, victoryPoints)
    {
        this.Spells = new List<Spell>();
    }
    
    public int UseSpell(Spell spell)
    {
        foreach (Spell spells in Spells)
        {
            if (spells == spell)
            {
                return spell.Attack;
            }
        }
        return 0;
    }

    public void AddSpell(Spell spell)
    {
        this.Spells.Add(spell);
        AttackValue += spell.Attack;
    }
}