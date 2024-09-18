namespace Library.Interfaces;

public interface IIItemAttack
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public bool IsAttack();
}