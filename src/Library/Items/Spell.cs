using Library.Interfaces;

namespace Library.Items;

public class Spell : ItemBase
{
    public Spell(string name, int attack) 
        : base(name, attack, 0) 
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