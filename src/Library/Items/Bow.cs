using Library.Interfaces;

namespace Library.Items;

public class Bow: BaseItem, IItemAttack
{
    public Bow(string name, int attack) : base(name, attack, 0)
    {
    }
}