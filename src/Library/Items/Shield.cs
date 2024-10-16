using Library.Interfaces;

namespace Library.Items;

public class Shield: BaseItem, IIsMagic
{
    public Shield(string name, int defense) : base(name, 0, defense)
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