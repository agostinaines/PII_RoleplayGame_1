namespace Library.Interfaces;

public interface IItemDefense
{
    public string Name { get; set; }
    public int Defense { get; set; }
    public bool IsDefense();
}