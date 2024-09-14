using System.Collections;

namespace Library;

public class Elfo
{
    public string Name { get;  set; }
    public ArrayList Items { get; set; }
    public int Life { get; set; }
    public int MaxLife { get; set; }
    public int ValorAtaque { get;  set; }
    
    public Elfo(string name, int life)
    {
        this.Name = name;
        this.Items = new ArrayList();
        this.Life = life;
        this.MaxLife = life;
        this.ValorAtaque = 0;
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
    
    public void AddItem(Item item)
    {
        this.Items.Add(item);
        ValorAtaque += item.Ataque;
    }
}