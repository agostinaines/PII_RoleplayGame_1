namespace Library;

public class Escudo
{
    public string Name { get;  set; }
    public int Defensa { get; set; }
    
    public Escudo(string name, int Defensa)
    {
        this.Name = name;
        this.Defensa = Defensa;
    }
}