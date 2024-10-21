namespace Library.Interfaces;

public interface IItemAttack : IItem
{
    public string Name { get; set; }
    public int Attack { get; set; }
}