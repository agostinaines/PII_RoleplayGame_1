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
    public int ValorAtaque { get;  set; }
    
    public Mago(string name, int life)
    {
        this.Name = name;
        this.Items = new ArrayList();
        this.Life = life;
        this.Hechizos = new ArrayList();
    }
    
    public void RecibirAtaque(Elfo elfo)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        Life -= elfo.ValorAtaque;
        if (Life < 0)
        {
            Life = 0;

        }

    }
    public void RecibirAtaque(Mago mago)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        Life -= mago.ValorAtaque;
        if (Life < 0)
        {
            Life = 0;

        }

    }
    public void RecibirAtaque(Enano enano)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        Life -= enano.ValorAtaque;
        if (Life < 0)
        {
            Life = 0;
            Console.WriteLine("El mago ha muerto.");

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
