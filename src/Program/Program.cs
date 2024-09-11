using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Library;

public class Program
{
    public static void Main()
    {
        // Creacion personaje Mago (Romina)
        List<string> itemsMago = new List<string> { "Bastón", "Libro de Hechizos" };
        List<string> hechizos = new List<string> { "Rayo", "Teletransportación" };
        Mago mago = new Mago("Gandalf", itemsMago, 100, hechizos, 20);
        
        Console.WriteLine(mago.Name);
        
        // Creacion personaje Elfo (Pilar)
        List<string> itemsElfo = new List<string> { "Arco", "Flechas" };
        Elfo elfo = new Elfo("Elfinho Jr", itemsElfo, 100, 15);

        Console.WriteLine(elfo.Name);
        
        // Creacion personaje Enano (Lui)
        List<string> itemsEnano = new List<string> {"Martillo", "Escudo" };
        Enano enano = new Enano("Poppy", itemsEnano, 200, 10);
        
        Console.WriteLine(enano.Name);
    }
    
}