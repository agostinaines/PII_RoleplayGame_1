namespace Library.Interfaces;

public interface IItemDefense : IItem
{
    public string Name { get; set; }
    public int Defense { get; set; }
}