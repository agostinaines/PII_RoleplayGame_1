using Library.Interfaces;
namespace Library;

public class Spell
{
    public string Name { get;  set; }
    public int Ataque { get;  set; }
    
    public bool IsAttack()
    {
        return true;
    }
    
    public Spell(string name, int Ataque)
    {
        this.Name = name;
        this.Ataque = Ataque;
    }
    
    public bool IsMagic()
    {
        return true;
    }
}