using Library.Interfaces;
namespace Library.Personajes;

public abstract class PersonajeBase : ICharacter
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public List<IItem> Items { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }

    protected PersonajeBase(string name, int life)
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
    
    public abstract void ReceiveAttack(int damage);
}