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
    public ArrayList Hechizos { get;  set; }
    
    public Mago(string name, int life, int valorAtaque)
    {
        this.Name = name;
        this.Items = new ArrayList();
        this.Life = life;
        this.Hechizos = new ArrayList();
    }
    
    public void RecibirAtaque(int ataque)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        
        Life -= ataque;
        
        if (Life < 0)
        {
            Life = 0;
        }
    }
    
    public void Curar()
    {
        Life = 100;
        Console.WriteLine("¡Nivel de vida al máximo!");
    }

    public int CalcularAtaque()
    {
        int ataque = 0;
        
        foreach (var item in Items)
        {
            ataque += 0;
        }

        return ataque;
    }
}
