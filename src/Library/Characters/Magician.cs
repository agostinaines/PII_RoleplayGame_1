using Library.Characters.AncestralClasses;
using Library.Items;

namespace Library.Characters;

public class Magician : BaseCharacter
{
    public List<Spell> Spells { get; set; }

    public Magician(string name, int life) : base(name,  life)
    {
        this.Spells = new List<Spell>();
    }
    
    public int UsarSpell(Spell spell)
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

    public override void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} ya está muerto.");
        }
        else
        {
            // Daño directo sin modificaciones
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} ha sido derrotado.");
            }
        }
    }
}
