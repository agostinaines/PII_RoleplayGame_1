using Library.Interfaces;

namespace Library.Items;

public class Armor: BaseItem, IIsMagic
{
    
    public Armor(string name, int defense) : base(name, 0, defense)
    {
    }

    public override bool IsDefense()
    {
        return true;
    }
    
    public override bool IsAttack()
    {
        return false;
    }
}