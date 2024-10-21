using Library.Interfaces;

namespace Library.Items;

public class Axe: BaseItem, IItemAttack
{
    public Axe(string name, int attack) : base(name, attack, 0)
    {
    }
}