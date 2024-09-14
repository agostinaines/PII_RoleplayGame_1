using Library;

//Test de Agostina
namespace ProgramTests
{
    public class Tests
    {
        private Elfo elfo;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Elfo antes de cada test con un nombre y 100 de vida
            elfo = new Elfo("Legolas", 100);
        }

        [Test]
        public void CrearElfo_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.AreEqual("Legolas", elfo.Name);
            Assert.AreEqual(100, elfo.Life);
            Assert.AreEqual(100, elfo.MaxLife);
            Assert.AreEqual(0, elfo.ValorAtaque);
            Assert.AreEqual(0, elfo.Items.Count);
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
        public void Curar_RestauraVidaAlMaximo()
        {
            elfo.RecibirAtaque(50);
            elfo.Curar(); // Curar sin parámetro, restaura la vida al máximo
            Assert.AreEqual(100, elfo.Life);
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Item revolverRemington = new Item("Revolver Remington", 35);
            elfo.AddItem(revolverRemington);

            // Verificamos que el valor de ataque aumenta
            Assert.AreEqual(35, elfo.ValorAtaque);
            Assert.AreEqual(1, elfo.Items.Count);
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            elfo.RecibirAtaque(100);
            elfo.RecibirAtaque(30);

            // Verificamos que la vida no cambia
            Assert.AreEqual(0, elfo.Life);
        }
    }
}
