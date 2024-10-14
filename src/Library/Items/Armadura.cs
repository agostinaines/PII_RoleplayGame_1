using Library.Interfaces;

namespace Library.Items;

public class Armadura: ItemBase, IIsMagic
{
    
    public Armadura(string name, int defense) : base(name, 0, defense)
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