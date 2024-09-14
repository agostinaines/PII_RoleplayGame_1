using Library;
using NUnit.Framework;
using System.Collections;

//Test de Luis
namespace ProgramTests
{
    public class Tests
    {
        private Enano enano;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Enano antes de cada test con un nombre y 100 de vida
            enano = new Enano("Gimli", 100);
        }

        [Test]
        public void CrearEnano_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.AreEqual("Gimli", enano.Name);
            Assert.AreEqual(100, enano.Life);
            Assert.AreEqual(100, enano.MaxLife);
            Assert.AreEqual(0, enano.ValorAtaque);
            Assert.AreEqual(30, enano.Armadura); // Verificamos que la armadura se inicializa correctamente
            Assert.AreEqual(0, enano.Items.Count);
        }

        [Test]
        public void RecibirAtaque_ReduceVidaConArmadura()
        {
            // Daño es reducido por la armadura, se aplica un 30% de reducción
            enano.RecibirAtaque(100);
            // El daño efectivo es 100 - 30% = 70, por lo que la vida debe ser 100 - 70 = 30
            Assert.AreEqual(30, enano.Life);
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            enano.RecibirAtaque(200);
            Assert.AreEqual(0, enano.Life);
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            enano.RecibirAtaque(50);  // Recibe daño
            enano.Curar();  // Curar restaura la vida al máximo
            Assert.AreEqual(100, enano.Life);
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Item hachaDeGuerra = new Item("Hacha de Guerra", 40);
            enano.AddItem(hachaDeGuerra);

            // Verificamos que el valor de ataque aumenta
            Assert.AreEqual(40, enano.ValorAtaque);
            Assert.AreEqual(1, enano.Items.Count);
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            enano.RecibirAtaque(200);
            enano.RecibirAtaque(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.AreEqual(0, enano.Life);
        }
    }
}
