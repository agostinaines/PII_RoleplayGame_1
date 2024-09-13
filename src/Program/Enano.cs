using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library;

public class Enano
{
    public string Name { get;  set; }
    public List<Item> Items { get; set; }
    public int Life { get; set; }
    public int ValorAtaque { get;  set; }
    
    public Enano(string name, int life)
    {
        this.Name = name;
        this.Items = new List<Item>();
        this.Life = life;
        this.ValorAtaque = 0;
    }
    
    public void RecibirAtaque(int damage)
    {
        Life = Life - damage;
        if (Life < 0)
        {
            Life = 0;
        }
    }

    public void Curar()
    {
        Life = 100;
    }
    
    public void AddItem(Item item)
    {
        this.Items.Add(item);
        ValorAtaque += item.Ataque;
    }

}