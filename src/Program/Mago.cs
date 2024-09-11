using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library;

public class Mago
{
    public string Name { get;  set; }
    public List<string> Items { get; set; }
    public int Life { get; set; }
    public List<string> Hechizos { get;  set; }
    public int ValorAtaque { get;  set; }
    
    public Mago(string name, List<string> items, int life, List<string> hechizos, int valorAtaque)
    {
        this.Name = name;
        this.Items = new List<string>(items);
        this.Life = life;
        this.Hechizos = new List<string>(hechizos);
        this.ValorAtaque = valorAtaque;
    }
    
    public void RecibirAtaque(int damage)
    {
        Life = Life - damage;
        if (Life < 0)
        {
            Life = 0;
        }
    }

    public void Curar(int cantidad)
    {
        Life += cantidad;
        if (Life > 100)
        {
            Life = 100;
        }
    }

}
