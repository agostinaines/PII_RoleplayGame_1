using System.Collections;

namespace Library;

public class Item
{
    public string Name { get;  set; }
    public int Ataque { get;  set; }
    
    public Item(string name, int Ataque)
    {
        this.Name = name;
        this.Ataque = Ataque;
    }
    
}