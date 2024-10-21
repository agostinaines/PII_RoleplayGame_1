using Library.Interfaces;

namespace Library.Items;

public class Sword: BaseItem, IItemAttack, IItemDefense
{
    public Sword(string name, int attack, int defense) : base(name, attack, defense)
    {
    }
}