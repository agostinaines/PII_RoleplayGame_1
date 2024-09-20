using Library.Interfaces;
namespace Library;

public class Armadura: IItemDefense
{
    public string Name { get;  set; }
    public int Defense { get; set; }

    public bool IsDefense()
    {
        return true;
    }
    
    public Armadura(string name, int defense)
    {
        this.Name = name;
        this.Defense = defense;
    }
    
    public bool IsMagic()
    {
        return false;
    }
}