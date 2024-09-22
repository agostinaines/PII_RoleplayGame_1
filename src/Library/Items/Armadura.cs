using Library.Interfaces;

namespace Library.Items;

public class Armadura: IItem, IIsMagic
{
    public string Name { get;  set; }
    public int Defense { get; set; }
    public int Attack { get; set; } = 0;
    
    public bool IsMagic { get; set; }
    
    public Armadura(string name, int defense)
    {
        this.Name = name;
        this.Defense = defense;
    }

    public bool IsDefense()
    {
        return true;
    }
    
    public bool IsAttack()
    {
        return false;
    }
}