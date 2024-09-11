using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Library;

public class Program
{
    public static void Main()
    {
        List<string> items = new List<string> { "Bastón", "Libro de Hechizos" };
        List<string> hechizos = new List<string> { "Rayo", "Teletransportación" };
        Mago mago = new Mago("Gandalf", items, 100, hechizos, 20);
        
        Console.WriteLine(mago.Name);
    }
    
}