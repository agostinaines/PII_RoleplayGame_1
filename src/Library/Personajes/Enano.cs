using System.Collections;
using Library.Interfaces;

namespace Library;

public class Enano: ICharacter
{
    public string Name { get;  set; }
    public ArrayList Items { get; set; }
    public int Life { get; set; }
    public int MaxLife { get; set; }
    public int ValorAtaque { get;  set; }
    public int Armadura { get;  set; }
    public int DefenseAttack { get; set; }
    
    public Enano(string name, int life)
    {
        this.Name = name;
        this.Items = new ArrayList();
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
            Life -= damage - ((damage * Armadura) / 100);
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
    
    public void AddItem(IItem item)
    {
        this.Items.Add(item);
        ValorAtaque += item.Attack;
        DefenseAttack += item.Defense;
    }
}