namespace Library.Interfaces;

public interface ICharacter
{ 
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public List<IItem> Items { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public void Cure();
    public void AddItem(IItem item);
}