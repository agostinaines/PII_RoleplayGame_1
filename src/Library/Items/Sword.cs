using Library.Interfaces;

namespace Library.Items;

public class Sword: BaseItem, IIsMagic
{
    public Sword(string name, int attack, int defense) : base(name, attack, defense)
    {
    }
    
    public override bool IsDefense()
    {
        return true;
    }
    
    public override bool IsAttack()
    {
        return true;
    }
}