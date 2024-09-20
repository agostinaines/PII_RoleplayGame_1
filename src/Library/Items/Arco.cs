using Library.Interfaces;
namespace Library;

public class Arco: IItemAttack
{
    public string Name { get;  set; }
    public int Attack { get;  set; }
    
    public Arco(string name, int ataque)
    {
        this.Name = name;
        this.Attack = ataque;
    }

    public bool IsAttack()
    {
        return true;
    }

    public void AddItem()
    {
        
    }
    
    public bool IsMagic()
    {
        return false;
    }
}