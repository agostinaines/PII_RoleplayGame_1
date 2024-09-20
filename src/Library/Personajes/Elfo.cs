using System.Collections;
using Library.Interfaces;

namespace Library;

public class Elfo : IAddArco 
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
    
    
    public void AddArco(Arco arco)
    {
        this.Items.Add(arco);
        ValorAtaque += arco.Attack;
    }
    
    public void AddEs(Arco arco)
    {
        this.Items.Add(arco);
        ValorAtaque += arco.Attack;
    }
}