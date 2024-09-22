using Library.Interfaces;

namespace Library.Items;

public class Escudo: IItem, IIsMagic
{
    public string Name { get;  set; }
    public int Defense { get; set; }
    public int Attack { get; set; } = 0;
    
    public Escudo(string name, int defense)
    {
        this.Name = name;
        this.Defense = defense;
    }

    public bool IsDefense()
    {
        return true;
    }
    
    public bool IsAttack()
    {
        return false;  // Indica que no es un objeto de ataque.
    }
    
    public bool IsMagic()
    {
        return false;
    }
}