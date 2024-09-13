using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library;

public class Mago
{
    public string Name { get;  set; }
    public ArrayList Items { get; set; }
    public int Life { get; set; }
    
    public ArrayList Spells { get;  set; }
    
    public int ValorAtaque { get;  set; }
    
    public Mago(string name, int life)
    {
        this.Name = name;
        this.Items = new ArrayList();
        this.Life = life;
        this.Spells = new ArrayList();
    }

    public void AddItem(Item item)
    {
        this.Items.Add(item);
        ValorAtaque += item.Ataque;
    }

    /*public void AddSpell(Spell spell)
    {
        this.Spell.Add(spell);
    }*/
    
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
        Life = 100;
    }
}
