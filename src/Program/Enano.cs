using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library;

public class Enano
{
    public string Name { get;  set; }
    public List<Item> Items { get; set; }
    public int Life { get; set; }
    public int MaxLife { get; set; }
    public int ValorAtaque { get;  set; }
    
    public int Armadura { get;  set; }
    
    public Enano(string name, int life)
    {
        this.Name = name;
        this.Items = new List<Item>();
        this.Life = life;
        this.MaxLife = life;
        this.ValorAtaque = 0;
        this.Armadura = 30;
    }
    
    public void RecibirAtaque(int damage)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        else
        {
            Life -= (damage * Armadura) / 100;
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