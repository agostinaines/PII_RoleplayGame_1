using Library.Interfaces;

namespace Library.Items;

public class Shield: BaseItem, IItemDefense
{
    public Shield(string name, int defense) : base(name, 0, defense)
    {
    }
}