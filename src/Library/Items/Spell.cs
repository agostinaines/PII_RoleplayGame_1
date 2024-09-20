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
    
    public Spell(string name, int ataque)
    {
        this.Name = name;
        this.Ataque = ataque;
    }
}