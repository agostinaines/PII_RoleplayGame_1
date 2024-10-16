using Library.Interfaces;

namespace Library.Items;

public class Axe: BaseItem, IIsMagic
{
    public Axe(string name, int attack) : base(name, attack, 0)
    {
    }

    public override bool IsDefense()
    {
        return false;
    }
    
    public override bool IsAttack()
    {
        return true;
    }
}