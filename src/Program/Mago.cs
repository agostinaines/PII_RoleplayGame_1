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
    
    public void RecibirAtaque(int damage)
    {
        if (Life <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        Life -= damage;
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
