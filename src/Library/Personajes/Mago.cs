using System.Collections;

namespace Library;

public class Mago
{
    public string Name { get;  set; }
    public ArrayList Items { get; set; }
    public int Life { get; set; }
    public int MaxLife { get; set; }
    public ArrayList Spells { get;  set; }
    public int ValorAtaque { get;  set; }
    
    public Mago(string name, int life)
    {
        this.Name = name;
        this.Items = new ArrayList();
        this.Life = life;
        this.MaxLife = life;
        this.Spells = new ArrayList();
    }

    /*
     public void AddItem(Item item)
     {
         this.Items.Add(item);
         ValorAtaque += item.Ataque;
     }*/

    public void AddSpell(Spell spell)
    {
        this.Spells.Add(spell);
    }
    
    public void RecibirAtaque(int damage)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        else
        {
            Life -= damage;
            if (Life < 0)
            {
                Life = 0;
                Console.WriteLine("Mataste a ese enemigo");
            }
        }
    }
    
    public void Curar()
    {
        Life = MaxLife;
    }

    public int UsarSpell(Spell spell)
    {
        foreach (Spell hechizos in Spells)
        {
            if (hechizos == spell)
            {
                return spell.Ataque;
            }
        }
        return 0;
    }
}