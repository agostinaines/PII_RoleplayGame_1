using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Library;

public class Program
{
    public static void Main()
    {
        // Items
        
        Item martillo = new Item("martillo", 20);
        Item botas = new Item("botas", 5);
        Item lanzaDardos = new Item("lanza dardos", 45);
        Item bastonCurativo = new Item("Baston curativo", 20);
        Item Baculo = new Item("Baculo", 55);
        
        // Spells

        Spell rayo = new Spell("Rayo electrico", 100);
        Spell fuego = new Spell("Bola de fuego", 90);

        
        // Creacion de personajes

        Enano poppy = new Enano("Poppy", 200);
        poppy.AddItem(martillo);
        poppy.AddItem(botas);

        Enano teemo = new Enano("Teemo", 150);
        teemo.AddItem(lanzaDardos);
        teemo.AddItem(botas);

        Elfo soraka = new Elfo("Soraka", 120);
        soraka.AddItem(bastonCurativo);

        Mago veigar = new Mago("Veigar", 80);
        veigar.AddItem(Baculo);
        veigar.AddSpell(rayo);
        
        
        Console.WriteLine("Vida de Poppy " + poppy.Life);
        Console.WriteLine("Valor de ataque de teemo " + teemo.ValorAtaque);
        Console.WriteLine("Valor de ataque de soraka " + soraka.ValorAtaque);
        
        // Teemo ataca a Poppy
        poppy.RecibirAtaque(teemo.ValorAtaque);
        Console.WriteLine(poppy.Life);
        
        // Poppy se cura
        poppy.Curar();
        Console.WriteLine(poppy.Life);
        
        // Soraka ataca a poppy
        poppy.RecibirAtaque(soraka.ValorAtaque);
        Console.WriteLine(poppy.Life);
        
        // Teemo ataca a soraka
        soraka.RecibirAtaque(teemo.ValorAtaque);
        Console.WriteLine(soraka.Life);
        
        // Veigar usa un spell contra Poppy
        poppy.RecibirAtaque(veigar.UsarSpell(rayo));
        Console.WriteLine(poppy.Life);

    }
    
}