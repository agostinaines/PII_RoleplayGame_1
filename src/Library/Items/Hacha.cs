using Library.Interfaces;

namespace Library.Items;

public class Hacha: IItem, IIsMagic
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    public int Defense { get; set; } = 0;
    
    public Hacha(string name, int ataque)
    {
        this.Name = name;
        this.Attack = ataque;
    }

    public bool IsAttack()
    {
        return true;
    }
    
    public bool IsDefense()
    {
        return false;
    }
    
    public bool IsMagic()
    {
        return false;
    }

}