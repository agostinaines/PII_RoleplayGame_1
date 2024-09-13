using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Library;

namespace LibraryTests
{
    public class Tests
    {
        private Elfo elfo;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Elfo antes de cada test
            List<string> items = new List<string> { "Espada", "Escudo" };
            elfo = new Elfo("Legolas", items, 100, 50);
        }

        [Test]
        public void CrearElfo_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.AreEqual("Legolas", elfo.Name);
            Assert.AreEqual(100, elfo.Life);
            Assert.AreEqual(50, elfo.ValorAtaque);
            Assert.AreEqual(2, elfo.Items.Count);
            Assert.Contains("Espada", elfo.Items);
            Assert.Contains("Escudo", elfo.Items);
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            elfo.RecibirAtaque(30);
            Assert.AreEqual(70, elfo.Life);
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            elfo.RecibirAtaque(150);
            Assert.AreEqual(0, elfo.Life);
        }

        [Test]
        public void Curar_AumentaVida()
        {
            elfo.RecibirAtaque(50);
            elfo.Curar(20);     
            Assert.AreEqual(70, elfo.Life);
        }

        [Test]
        public void Curar_NoSuperaMaximoDeVida()
        {
            elfo.RecibirAtaque(10);  
            elfo.Curar(50);    
            Assert.AreEqual(100, elfo.Life);
        }
    }
}