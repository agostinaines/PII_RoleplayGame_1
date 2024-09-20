namespace Library.Interfaces;

public interface IItemDefense
{
    string Name { get; set; }
    int Defense { get; set; }
    bool IsDefense();
}