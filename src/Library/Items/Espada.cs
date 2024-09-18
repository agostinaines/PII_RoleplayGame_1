namespace Library;

public class Espada
{
    public string Name { get;  set; }
    public int Ataque { get;  set; }
    
    public int Defensa { get; set; }
    
    public Espada(string name, int Ataque, int Defensa)
    {
        this.Name = name;
        this.Ataque = Ataque;
        this.Defensa = Defensa;
    }
    
    
}