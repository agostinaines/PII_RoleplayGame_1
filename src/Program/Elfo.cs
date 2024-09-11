﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library;

public class Elfo
{
    public string Name { get;  set; }
    public ArrayList Items { get; set; }
    public int Life { get; set; }
    public int ValorAtaque { get;  set; }
    
    public Elfo(string name, List<string> items, int life, int valorAtaque)
    {
        this.Name = name;
        this.Items = new ArrayList(items);
        this.Life = life;
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