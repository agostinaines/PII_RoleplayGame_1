namespace Library;

public class Spell
{
    public string Name { get;  set; }
    public int Ataque { get;  set; }
    
    public Spell(string name, int Ataque)
    {
        this.Name = name;
        this.Ataque = Ataque;
    }
}