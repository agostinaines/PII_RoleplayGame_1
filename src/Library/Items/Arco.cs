using Library.Interfaces;
namespace Library;

public class Arco: IIItemAttack, IIsMagic
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    public int Defense { get; set; }

    public bool IsAttack()
    {
        return true;
    }
    
    public Arco(string name, int ataque, int defense)
    {
        this.Name = name;
        this.Attack = ataque;
        this.Defense = defense;
    }
    
    public bool IsMagic()
    {
        return false;
    }
}