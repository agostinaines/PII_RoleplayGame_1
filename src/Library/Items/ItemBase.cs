using Library.Interfaces;

namespace Library.Items;

public abstract class ItemBase : IItem
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public bool IsMagic { get; set; }

    protected ItemBase(string name, int attack, int defense)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
    }

    public abstract bool IsAttack();
    public abstract bool IsDefense();
}