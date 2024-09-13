using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Library;
using Item;

public class Program
{
    public static void Main()
    {
        
        Item martillo = new Item("martillo", 20);
        Item botas = new Item("botas", 5);
        Item lanzaDardos = new Item("lanza dardos", 45);
        
        // Creacion personaje Enano (Lui)

        Enano poppy = new Enano("Poppy", 200);
        poppy.AddItem(martillo);
        poppy.AddItem(botas);

        Enano teemo = new Enano("Teemo", 150);
        teemo.AddItem(lanzaDardos);
        teemo.AddItem(botas);
        
        
        Console.WriteLine(poppy.ValorAtaque);
        Console.WriteLine(teemo.ValorAtaque);
        
        poppy.RecibirAtaque(teemo.ValorAtaque);
        Console.WriteLine(poppy.Life);
        poppy.Curar();
        Console.WriteLine(poppy.Life);
    }
    
}