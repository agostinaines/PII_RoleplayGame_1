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
    public int VictoryPoints { get; set; }
    
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
        AttackValue += item.Attack;
        DefenseValue += item.Defense;
    }
    
    public virtual void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto");
        }
        else
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("¡Mataste a tu enemigo!");
            }
        }
    }

    public void AddVictoryPoints(int points)
    {
        VictoryPoints += points;
    }
}