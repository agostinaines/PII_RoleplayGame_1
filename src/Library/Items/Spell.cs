using Library.Interfaces;
namespace Library.Items;

public class Spell
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    
    public Spell(string name, int attack)
    {
        this.Name = name;
        this.Attack = attack;
    }
}