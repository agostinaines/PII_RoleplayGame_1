﻿using Library;
using Library.Characters;
using Library.Interfaces;
using Library.Items;

public class Program
{
    public static void Main()
    {
        List<Spell> spellBook = new List<Spell>();
        
        Console.WriteLine("¡Bienvenidos a la Tierra Media! \n");

        // Creación de Items

        // Items de Luis
        IItem martillo = new Sword("Martillo de la Montaña", 50, 10);  
        IItem botas = new Armor("Botas de Hierro", 20); 
        IItem lanzaDardos = new Bow("Lanza de Dardos", 20);
        IItem escudoMagico = new Shield("Escudo Magico", 10); 
        IItem baculo = new Sword("Báculo Mágico", 40, 0);

        // Items de Pilar
        IItem varitaMagica = new Bow("Varita Mágica", 35);  
        IItem anilloBosque = new Armor("Anillo del Bosque", 12);
        IItem manto = new Armor("Manto Protector", 5);

        // Items de Agostina
        IItem sting = new Sword("Sting", 45, 5);          
        IItem anilloUnico = new Armor("Anillo Único", 250); 
        IItem fuegosArtificiales = new Bow("Fuegos Artificiales", 25);
        IItem morgul = new Sword("Morgul", 60, 25);

        // Creación de Spells

        // Spells de Luis
        Spell rayo = new Spell("Rayo eléctrico", 100);
        Spell fuego = new Spell("Bola de fuego", 90);

        // Spells de Pilar
        Spell rafaga = new Spell("Ráfaga de viento", 80);
        Spell absorcion = new Spell("Absorción de vida", 20);
        Spell tsunami = new Spell("Tsunami de agua", 110);

        // Spells de Agostina
        Spell tornado = new Spell("Tornado", 130);
        Spell invisibilidad = new Spell("Invisibilidad", 20);
        Spell velocidad = new Spell("Velocidad", 30);

        // Creación de personajes

        // Personajes de Luis

        // Creación de un enano llamado Poppy con 200 puntos de vida máxima
        Dwarf poppy = new Dwarf("Poppy", 200);
        poppy.AddItem(martillo);
        poppy.AddItem(botas);

        // Creación de un enano llamado Teemo con 150 puntos de vida máxima
        Dwarf teemo = new Dwarf("Teemo", 150);
        teemo.AddItem(lanzaDardos);
        teemo.AddItem(botas);

        // Creación de un elfo llamado Soraka con 120 puntos de vida máxima
        Elf soraka = new Elf("Soraka", 120);
        soraka.AddItem(escudoMagico);

        // Creación de un mago llamado Veigar con 80 puntos de vida máxima
        Magician veigar = new Magician("Veigar", 80);
        veigar.AddItem(baculo);
        veigar.AddSpell(rayo);
        Console.WriteLine($"-------------{veigar.AttackValue}");

        Console.WriteLine($"La vida de Poppy es de {poppy.Health}");
        Console.WriteLine($"El valor de ataque de Teemo es {teemo.AttackValue}");
        Console.WriteLine($"El valor de ataque de Soraka es {soraka.AttackValue}");

        // Teemo ataca a Poppy
        poppy.ReceiveAttack(teemo.AttackValue);
        Console.WriteLine($"La vida de Poppy es de {poppy.Health}");

        // Poppy se cura
        poppy.Cure();
        Console.WriteLine($"La vida de Poppy es de {poppy.Health}");

        // Soraka ataca a Poppy
        poppy.ReceiveAttack(soraka.AttackValue);
        Console.WriteLine($"La vida de Poppy es de {poppy.Health}");

        // Teemo ataca a Soraka
        soraka.ReceiveAttack(teemo.AttackValue);
        Console.WriteLine($"La vida de Soraka es de {soraka.Health}");

        // Veigar usa un spell contra Poppy
        poppy.ReceiveAttack(veigar.UsarSpell(rayo));
        Console.WriteLine($"La vida de Poppy es de {poppy.Health}\n");

        // Personajes de Pilar

        // Creación de un mago llamado Gandalf con 300 puntos de vida máxima
        Magician gandalf = new Magician("Gandalf", 300);
        gandalf.AddItem(varitaMagica);
        gandalf.AddItem(manto);
        gandalf.AddSpell(rayo);
        gandalf.AddSpell(absorcion);

        // Creación de un elfo llamado Elfo Navideño con 80 puntos de vida máxima
        Elf elfNav = new Elf("Elfo Navideño", 80);
        elfNav.AddItem(anilloBosque);
        elfNav.AddItem(botas);
        elfNav.AddItem(lanzaDardos);

        Console.WriteLine($"La vida de Gandalf es de {gandalf.Health}");
        Console.WriteLine($"El valor de ataque de Elfo Navideño es de {elfNav.AttackValue}");

        // Gandalf ataca a Soraka
        soraka.ReceiveAttack(gandalf.AttackValue);
        Console.WriteLine($"La vida de Soraka es de {soraka.Health}");

        // Soraka se cura
        soraka.Cure();
        Console.WriteLine($"La vida de Soraka es de {soraka.Health}");

        // Gandalf usa un spell contra Elfo Navideño
        elfNav.ReceiveAttack(gandalf.UsarSpell(absorcion));
        Console.WriteLine($"La vida del Elfo Navideño es de {elfNav.Health}\n");

        // Personajes de Agostina

        // Creación de un elfo llamado Galadriel con 160 puntos de vida máxima
        Elf galadriel = new Elf("Galadriel", 160);
        galadriel.AddItem(sting);
        galadriel.AddItem(fuegosArtificiales);

        Console.WriteLine($"La vida de Galadriel es de {galadriel.Health}");
        Console.WriteLine($"El valor de ataque de Galadriel es de {galadriel.AttackValue}");

        // Creación de un mago llamado Saruman con 200 puntos de vida máxima
        Magician saruman = new Magician("Saruman", 200);
        saruman.AddItem(anilloUnico);
        saruman.AddItem(morgul);
        saruman.AddSpell(tornado);
        saruman.AddSpell(velocidad);

        Console.WriteLine($"La vida de Saruman es de {saruman.Health}");
        Console.WriteLine($"El valor de ataque de Saruman es de {saruman.AttackValue}");

        // Saruman ataca a Galadriel
        galadriel.ReceiveAttack(saruman.AttackValue);
        Console.WriteLine($"La vida de Galadriel es de {galadriel.Health}");

        // Galadriel se cura
        galadriel.Cure();
        Console.WriteLine($"La vida de Galadriel es de {galadriel.Health}");

        // Saruman usa un hechizo contra Galadriel
        galadriel.ReceiveAttack(saruman.UsarSpell(tornado));
        Console.WriteLine($"La vida de Galadriel es de {galadriel.Health}\n");
        
        // ----------------------------enemigos------------------------------ //
        
        // Creacion de items
        // ----ESPADAS----
        IItem espadaOxidada = new Sword("Espada Oxidada", 15, 0);
        IItem espadaRustica = new Sword("Espada Rustica", 25, 0);
        IItem espadaMadera = new Sword("Espada de Madera", 20, 0);
        IItem espadaLarga = new Sword("Espada Larga", 40, 0);
        //----ARMADURA----
        IItem armaduraCuero = new Armor("Armadura de cuero", 10);
        IItem armaduraVendas = new Armor("Vendaje de Momia", 10);
        IItem armaduraDesgastada = new Armor("Armadura Desgastada", 8);
        //----ESCUDOS----
        IItem escudoPiel = new Shield("Escudo de Piel", 15);
        IItem escudoEscamas = new Shield("Escudo de Escamas", 30);
        IItem escudoHierro = new Shield("Escudo de Hierro", 25);
        //----HACHAS----
        IItem hachaGuerra = new Axe("Hacha de Guerra", 50);
        IItem hachaMadera = new Axe("Hacha de Madera", 20);
        
        // Creacion de personajes + items
        Orc orco1 = new Orc("Gruk", 150,15);
        orco1.AddItem(espadaRustica);
        orco1.AddItem(armaduraCuero);
        
        Momia momia1 = new Momia("Mummy", 100,10);
        momia1.AddItem(espadaOxidada);
        momia1.AddItem(armaduraVendas);
        
        Dragon dragon1 = new Dragon("Draco", 300,30);
        dragon1.AddItem(hachaGuerra);
        dragon1.AddItem(escudoEscamas);
       
        
        
        // Ejemplo de combate 
        Console.WriteLine($"Salud de {orco1.Name} antes del ataque: {orco1.Health}");
        Console.WriteLine($"Valor de ataque de {saruman.Name} es {saruman.AttackValue}");
        //Combat.HeroAttacksEnemy(saruman, orco1);
        Console.WriteLine($"Los puntos de victoria de {saruman.Name}, ahora son {saruman.VictoryPoints}");
        
    }
    
    
}
