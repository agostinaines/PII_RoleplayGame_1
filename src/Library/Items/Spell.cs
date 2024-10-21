using Library.Interfaces;

namespace Library.Items;

public class Spell : BaseItem, IItemAttack, IItemDefense
{
    public Spell(string name, int attack) : base(name, attack, 0)
    {
        this.IsMagic = true;
    }
}