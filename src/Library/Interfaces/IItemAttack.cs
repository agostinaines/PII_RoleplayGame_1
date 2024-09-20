namespace Library.Interfaces;

public interface IItemAttack
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public bool IsAttack();
}