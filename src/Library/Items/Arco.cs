using Library.Interfaces;

namespace Library.Items;

public class Arco: IItem, IIsMagic
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    public int Defense { get; set; } = 0;
    
    public bool IsMagic { get; set; }
    
    public Arco(string name, int attack)
    {
        this.Name = name;
        this.Attack = attack;
    }

    public bool IsAttack()
    {
        return true;
    }
    
    public bool IsDefense()
    {
        return false;
    }
}