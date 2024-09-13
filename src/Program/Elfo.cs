using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library;

public class Elfo
{
    public string Name { get;  set; }
    public List<Item> Items { get; set; }
    public int Life { get; set; }
    public int MaxLife { get; set; }
    public int ValorAtaque { get;  set; }
    
    public Elfo(string name, int life)
    {
        this.Name = name;
        this.Items = new List<Item>();
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

}