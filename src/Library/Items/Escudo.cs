using Library.Interfaces;
namespace Library;

public class Escudo: IItemDefense
{
    public string Name { get;  set; }
    public int Defense { get; set; }

    public bool IsDefense()
    {
        return true;
    }
    
    public Escudo(string name, int defense)
    {
        this.Name = name;
        this.Defense = defense;
    }
    
    public bool IsMagic()
    {
        return false;
    }
}