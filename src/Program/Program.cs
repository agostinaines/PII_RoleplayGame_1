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
        Mago mago = new Mago("Gandalf", 100, 20);
        
        Console.WriteLine(mago.Name);
        
        // Creacion personaje Elfo (Pilar)
        List<string> itemsElfoi = new List<string> { "Arco", "Flechas" };
        Elfo elfoi = new Elfo("Elfinho Jr", itemsElfoi, 100, 15);

        Console.WriteLine(elfoi.Name);
        
        // Creacion personaje Enano (Lui)
        List<string> itemsEnano = new List<string> {"Martillo", "Escudo" };
        Enano enano = new Enano("Poppy", itemsEnano, 200, 10);
        
        Console.WriteLine(enano.Name);
        
        // Creación personaje Elfo (Agostina)
        List<string> itemsElfoii = new List<string> { "Espada", "Escudo" };
        Elfo elfoii = new Elfo("Faustino II", itemsElfoii, 150, 12);
        
        Console.WriteLine(elfoii.Name);
    }
    
}