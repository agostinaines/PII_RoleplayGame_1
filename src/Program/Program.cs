using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Library;

public class Program
{
    public static void Main()
    {
        // Items

        //Items Luis
        Item martillo = new Item("martillo", 20);
        Item botas = new Item("botas", 5);
        Item lanzaDardos = new Item("lanza dardos", 45);
        Item bastonCurativo = new Item("Baston curativo", 20);
        Item Baculo = new Item("Baculo", 55);
        //Item Pilar
        Item varitaMagica = new Item("Varita Magica", 35);
        Item anilloBosque = new Item("Anillo Del bosque", 12);
        Item manto = new Item("Manto Potenciador", 10);
        //Agostina
        
        // Spells

        //Spells Luis
        Spell rayo = new Spell("Rayo electrico", 100);
        Spell fuego = new Spell("Bola de fuego", 90);
        //Spells Pilar
        Spell rafaga = new Spell("Rafaga de Viento", 80);
        Spell absorcion = new Spell("Absorcion de vida", 20);
        Spell tsunami = new Spell("Tsunami de agua", 110);
        //Spells Agostina
        
        // Creacion de personajes

        //PERSONAJES LUIS
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

        //PERSONAJES PILAR

        Mago gandalf = new Mago("Gandalf", 300);
        gandalf.AddItem(varitaMagica);
        gandalf.AddItem(manto);
        gandalf.AddSpell(rayo);
        gandalf.AddSpell(absorcion);

        Elfo elfoNav = new Enano("Elfo Navideño", 80);
        elfoNav.AddItem(anilloBosque);
        elfoNav.AddItem(botas);
        elfoNav.AddItem(lanzaDardos);

        Console.WriteLine("Vida de Gandalf " + gandalf.Life);
        Console.WriteLine("Valor de ataque de Elfo Navideño" + elfoNav.ValorAtaque);

        // Gandalf ataca a Soraka
        soraka.RecibirAtaque(gandalf.ValorAtaque);
        Console.WriteLine(poppy.Life);
        
        // Soraka se cura
        soraka.Curar();
        Console.WriteLine(soraka.Life);

        // Gandalf usa un spell contra Elfo Navideño
        elfoNav.RecibirAtaque(gandalf.UsarSpell(absorcion));
        Console.WriteLine(elfoNav.Life);

        //PERSONAJES AGOSTINA

    }
    
}