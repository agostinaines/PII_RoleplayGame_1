namespace Library;

public class Spells
{
    public string Name { get;  set; }
    public int Ataque { get;  set; }
    
    public Spells(string name, int Ataque)
    {
        this.Name = name;
        this.Ataque = Ataque;
    }
    
}