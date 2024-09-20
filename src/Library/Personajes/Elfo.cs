﻿using System.Collections;
using Library.Interfaces;

namespace Library;

public class Elfo: ICharacter
{
    public string Name { get;  set; }
    public List<IItem> Items { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int AttackValue { get;  set; }
    public int DefenseAttack { get; set; }
    
    public Elfo(string name, int life)
    {
        this.Name = name;
        this.Items = new List<IItem>();
        this.Health = life;
        this.MaxHealth = life;
        this.AttackValue = 0;
    }
    
    public void Cure()
    {
        Health = MaxHealth;
    }
    
    public void AddItem(IItem item)
    {
        this.Items.Add(item);
        AttackValue += item.Attack;
        DefenseAttack += item.Defense;
    }

    public void RecibirAtaque(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto");
        }
        else
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("¡Mataste a tu enemigo!");
            }
        }
    }
}