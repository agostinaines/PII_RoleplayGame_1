using Library;
using Library.Interfaces;

public class Program
{
    public static void Main()
    {
        List<IIsMagic> SpellBook = new List<IIsMagic>();
        
        Console.WriteLine("¡Bienvenidos a la Tierra Media! \n");
        // Items

        // Items Luis
        /*
        Item martillo = new Item("martillo", 20);
        Item botas = new Item("botas", 5);
        Item lanzaDardos = new Item("lanza dardos", 45);
        Item bastonCurativo = new Item("Baston curativo", 20);
        Item baculo = new Item("Baculo", 55);

        // Items Pilar
        Item varitaMagica = new Item("Varita Magica", 35);
        Item anilloBosque = new Item("Anillo Del bosque", 12);
        Item manto = new Item("Manto Potenciador", 10);

        // Items Agostina
        Item fuegosArtificiales = new Item("Fuegos Artficiales", 0);
        Item morgul = new Item("Morgul", 35);
        Item sting = new Item("Sting", 45);
        Item anilloUnico = new Item("Anillo Único", 250);
        */

        // Spells

        // Spells Luis
        Spell rayo = new Spell("Rayo eléctrico", 100);
        Spell fuego = new Spell("Bola de fuego", 90);

        // Spells Pilar
        Spell rafaga = new Spell("Ráfaga de viento", 80);
        Spell absorcion = new Spell("Absorción de vida", 20);
        Spell tsunami = new Spell("Tsunami de agua", 110);

        // Spells Agostina
        Spell tornado = new Spell("Tornado", 130);
        Spell invisibilidad = new Spell("Invisibilidad", 20);
        Spell velocidad = new Spell("Velocidad", 30);

        // Creación de personajes

        // PERSONAJES LUIS
        /*
        Enano poppy = new Enano("Poppy", 200);
        poppy.AddItem(martillo);
        poppy.AddItem(botas);

        Enano teemo = new Enano("Teemo", 150);
        teemo.AddItem(lanzaDardos);
        teemo.AddItem(botas);

        Elfo soraka = new Elfo("Soraka", 120);
        soraka.AddItem(bastonCurativo);

        Mago veigar = new Mago("Veigar", 80);
        veigar.AddItem(baculo);
        veigar.AddSpell(rayo);
        

        Console.WriteLine("La vida de Poppy es de " + poppy.Life);
        Console.WriteLine("El valor de ataque de Teemo " + teemo.ValorAtaque);
        Console.WriteLine("El valor de ataque de Soraka " + soraka.ValorAtaque);

        // Teemo ataca a Poppy
        poppy.RecibirAtaque(teemo.ValorAtaque);
        Console.WriteLine("La vida de Poppy es de " + poppy.Life);

        // Poppy se cura
        poppy.Curar();
        Console.WriteLine("La vida de Poppy es de " + poppy.Life);

        // Soraka ataca a poppy
        poppy.RecibirAtaque(soraka.ValorAtaque);
        Console.WriteLine("La vida de Poppy es de " + poppy.Life);

        // Teemo ataca a Soraka
        soraka.RecibirAtaque(teemo.ValorAtaque);
        Console.WriteLine("La vida de Soraka es de " + soraka.Life);

        // Veigar usa un spell contra Poppy
        poppy.RecibirAtaque(veigar.UsarSpell(rayo));
        Console.WriteLine("La vida de Poppy es de " + poppy.Life + "\n");


        // PERSONAJES PILAR

        Mago gandalf = new Mago("Gandalf", 300);
        gandalf.AddItem(varitaMagica);
        gandalf.AddItem(manto);
        gandalf.AddSpell(rayo);
        gandalf.AddSpell(absorcion);

        Elfo elfoNav = new Elfo("Elfo Navideño", 80);
        elfoNav.AddItem(anilloBosque);
        elfoNav.AddItem(botas);
        elfoNav.AddItem(lanzaDardos);

        Console.WriteLine("La vida de Gandalf es de " + gandalf.Life);
        Console.WriteLine("El valor de ataque de Elfo Navideño " + elfoNav.ValorAtaque);

        // Gandalf ataca a Soraka
        soraka.RecibirAtaque(gandalf.ValorAtaque);
        Console.WriteLine("El valor de vida de Soraka es de " + soraka.Life);

        // Soraka se cura
        soraka.Curar();
        Console.WriteLine("El valor de vida de Soraka es de " + soraka.Life);

        // Gandalf usa un spell contra Elfo Navideño
        elfoNav.RecibirAtaque(gandalf.UsarSpell(absorcion));
        Console.WriteLine("La vida del Elfo Navideño es de " + elfoNav.Life + "\n");


        // PERSONAJES AGOSTINA
        Elfo galadriel = new Elfo("Galadriel", 160);
        galadriel.AddItem(sting);
        galadriel.AddItem(fuegosArtificiales);

        Console.WriteLine("La vida de Galdriel es de " + galadriel.Life);
        Console.WriteLine("El valor de ataque de Galadriel es de " + galadriel.ValorAtaque);

        Mago saruman = new Mago("Saruman", 200);
        saruman.AddItem(anilloUnico);
        saruman.AddItem(morgul);
        saruman.AddSpell(tornado);
        saruman.AddSpell(velocidad);

        Console.WriteLine("La vida de Saruman es de " + saruman.Life);
        Console.WriteLine("El valor de ataque de Saruman es de " + saruman.ValorAtaque);

        // Saruman ataca a Galadriel
        galadriel.RecibirAtaque(saruman.ValorAtaque);
        Console.WriteLine("La vida de Galdriel es de " + galadriel.Life);

        // Galadriel se cura
        galadriel.Curar();
        Console.WriteLine("La vida de Galdriel es de " + galadriel.Life);

        // Saruman usa un hechizo contra Galadriel
        galadriel.RecibirAtaque(saruman.UsarSpell(tornado));
        Console.WriteLine("La vida de Galdriel es de " + galadriel.Life + "\n");
        */
    }
}