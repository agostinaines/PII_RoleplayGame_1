using Library.Interfaces;

namespace Library.Characters.AncestralClasses;

public abstract class BaseCharacter : ICharacter
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public List<IItem> Items { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    
    protected BaseCharacter(string name, int life)
    {
        this.Name = name;
        this.MaxHealth = life;
        this.Health = life;
        this.Items = new List<IItem>();
    }
    
    public void Cure()
    {
        Health = MaxHealth;
    }

    public void AddItem(IItem item)
    {
        this.Items.Add(item);
    }

    public void CalculateAttackValue()
    {
        this.AttackValue = 0;
        foreach (IItem item in Items)
        {
            if (item is IItemAttack)
            {
                IItemAttack itemAttack = (IItemAttack)item;
                AttackValue += itemAttack.Attack;
            }
        }
    }

    public void CalculateDefenseValue()
    {
        this.DefenseValue = 0;
        foreach (IItem item in Items)
        {
            if (item is IItemDefense)
            {
                IItemDefense itemDefense = (IItemDefense)item;
                DefenseValue += itemDefense.Defense;
            }
        }
    }
    
    public virtual void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto");
        }
        else
        {
            double effectiveDamage = damage * (1 - (DefenseValue / 100.0));
            
            Health -= (int)effectiveDamage;
            
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("¡Mataste a tu enemigo!");
            }
        }
    }
}