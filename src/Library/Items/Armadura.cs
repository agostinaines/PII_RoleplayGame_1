namespace Library;

public class Armadura
{
    public string Name { get;  set; }
    public int Defensa { get; set; }
    
    public Armadura(string name, int Defensa)
    {
        this.Name = name;
        this.Defensa = Defensa;
    }
}