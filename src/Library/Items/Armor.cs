using Library.Interfaces;

namespace Library.Items;

public class Armor: BaseItem, IItemDefense
{
    public Armor(string name, int defense) : base(name, 0, defense)
    {
    }
}