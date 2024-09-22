using Library.Interfaces;
namespace Library;

public class Escudo: IItem
{
    public string Name { get;  set; }
    public int Defense { get; set; }
    public int Attack { get; set; } = 0;

    public bool IsDefense()
    {
        return true;
    }
    
    public bool IsAttack()
    {
        return false;  // Indica que no es un objeto de ataque.
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