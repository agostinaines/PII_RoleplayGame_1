using Library.Interfaces;

namespace Library.Items;

public class Espada: IItem, IIsMagic
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    public int Defense { get; set; }
    
    public bool IsMagic { get; set; }

    
    public Espada(string name, int attack, int defense)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
    }
    
    public bool IsAttack()
    {
        return true;
    }

    public bool IsDefense()
    {
        return true;
    }
}