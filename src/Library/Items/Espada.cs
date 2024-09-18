using Library.Interfaces;
namespace Library;

public class Espada: IIItemAttack, IItemDefense
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    public int Defense { get; set; }
    
    public bool IsAttack()
    {
        return true;
    }

    public bool IsDefense()
    {
        return true;
    }
    
    public Espada(string name, int ataque, int defense)
    {
        this.Name = name;
        this.Attack = ataque;
        this.Defense = defense;
    }
    
    
}