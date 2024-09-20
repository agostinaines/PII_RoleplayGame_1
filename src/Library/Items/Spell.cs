using Library.Interfaces;
namespace Library;

public class Spell: IIsMagic
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    
    public Spell(string name, int attack)
    {
        this.Name = name;
        this.Attack = attack;
    }
    
    public bool IsMagic()
    {
        return true;
    }
}