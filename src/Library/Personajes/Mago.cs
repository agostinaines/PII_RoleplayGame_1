using System.Collections;
using Library.Interfaces;

namespace Library;

public class Mago: ICharacter
{
    public string Name { get;  set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public List<IItem> Items { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public List<Spell> Spells { get;  set; }
    
    public Mago(string name, int life)
    {
        this.Name = name;
        this.MaxHealth = life;
        this.Health = life;
        this.Items = new List<IItem>();
        this.Spells = new List<Spell>();
    }

    public void Cure()
    {
        Health = MaxHealth;
    }
    
     public void AddItem(IItem item)
     {
         this.Items.Add(item);
         AttackValue += item.Attack;
         DefenseValue += item.Defense;
     }

    public void AddSpell(Spell spell)
    {
        this.Spells.Add(spell);
    }
    
    public void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        else
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("Mataste a ese enemigo");
            }
        }
    }

    public int UsarSpell(Spell spell)
    {
        foreach (Spell spells in Spells)
        {
            if (spells == spell)
            {
                return spell.Ataque;
            }
        }
        return 0;
    }
}
