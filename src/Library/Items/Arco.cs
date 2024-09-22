using Library.Interfaces;
namespace Library;

public class Arco: IItem
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    public int Defense { get; set; } = 0;
    
    public Arco(string name, int ataque)
    {
        this.Name = name;
        this.Attack = ataque;
    }

    public bool IsAttack()
    {
        return true;
    }
    
    public bool IsDefense()
    {
        return false;
    }

    public void AddItem()
    {
        
    }
    
    public bool IsMagic()
    {
        return false;
    }
}