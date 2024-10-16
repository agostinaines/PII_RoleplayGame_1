using Library.Interfaces;

namespace Library.Items;

public class Escudo: ItemBase, IIsMagic
{
    public Escudo(string name, int defense) : base(name, 0, defense)
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