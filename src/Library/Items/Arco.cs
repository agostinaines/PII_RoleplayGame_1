using Library.Interfaces;

namespace Library.Items;

public class Arco: ItemBase, IIsMagic
{
    
    public Arco(string name, int attack) : base(name, attack, 0)
    {
    }

    public override bool IsAttack()
    {
        return true;
    }
    
    public override bool IsDefense()
    {
        return false;
    }
}