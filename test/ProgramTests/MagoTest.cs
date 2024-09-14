using Library;
using NUnit.Framework;
using System.Collections;

namespace ProgramTests
{
    public class Tests
    {
        private Mago mago;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Mago antes de cada test con un nombre y 100 de vida
            mago = new Mago("Gandalf", 100);
        }

        [Test]
        public void CrearMago_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.AreEqual("Gandalf", mago.Name);
            Assert.AreEqual(100, mago.Life);
            Assert.AreEqual(100, mago.MaxLife);
            Assert.AreEqual(0, mago.ValorAtaque);
            Assert.AreEqual(0, mago.Items.Count);
            Assert.AreEqual(0, mago.Spells.Count);
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            mago.RecibirAtaque(40);
            Assert.AreEqual(60, mago.Life);
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            mago.RecibirAtaque(150);
            Assert.AreEqual(0, mago.Life);
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            mago.RecibirAtaque(50);  // Recibe daño
            mago.Curar();  // Curar restaura la vida al máximo
            Assert.AreEqual(100, mago.Life);
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Item varitaMagica = new Item("Varita Mágica", 20);
            mago.AddItem(varitaMagica);

            // Verificamos que el valor de ataque aumenta
            Assert.AreEqual(20, mago.ValorAtaque);
            Assert.AreEqual(1, mago.Items.Count);
        }

        [Test]
        public void AgregarSpell_IncrementaListaHechizos()
        {
            // Creamos un hechizo de prueba
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            mago.AddSpell(bolaDeFuego);

            // Verificamos que el hechizo se agregó correctamente
            Assert.AreEqual(1, mago.Spells.Count);
        }

        [Test]
        public void UsarSpell_HechizoDisponibleDevuelveAtaque()
        {
            // Creamos y agregamos un hechizo de prueba
            Spell rayo = new Spell("Rayo", 40);
            mago.AddSpell(rayo);

            // Verificamos que el mago puede usar el hechizo "Rayo"
            int ataque = mago.UsarSpell(rayo);
            Assert.AreEqual(40, ataque);
        }

        [Test]
        public void UsarSpell_HechizoNoDisponibleDevuelveCero()
        {
            // Creamos un hechizo que no agregamos
            Spell escudoMagico = new Spell("Escudo Mágico", 0);

            // Intentamos usar un hechizo que no está en la lista de hechizos
            int ataque = mago.UsarSpell(escudoMagico);
            Assert.AreEqual(0, ataque);
        }

        [Test]
        public void LanzarHechizo_HechizoDisponible_SoloUsaHechizoSiLoTiene()
        {
            // Creamos dos hechizos
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            Spell rayo = new Spell("Rayo", 40);

            // Agregamos solo el hechizo "Bola de Fuego"
            mago.AddSpell(bolaDeFuego);

            // Verificamos que puede lanzar "Bola de Fuego"
            int ataqueBolaDeFuego = mago.UsarSpell(bolaDeFuego);
            Assert.AreEqual(50, ataqueBolaDeFuego);

            // Verificamos que no puede lanzar "Rayo" (no lo tiene)
            int ataqueRayo = mago.UsarSpell(rayo);
            Assert.AreEqual(0, ataqueRayo);
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            mago.RecibirAtaque(100);
            mago.RecibirAtaque(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.AreEqual(0, mago.Life);
        }
    }
}
