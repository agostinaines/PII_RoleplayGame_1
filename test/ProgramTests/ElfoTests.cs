using Library.Items;
using Library.Personajes;

// Test de Agostina
namespace ProgramTests
{
    public class TestsElfo
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
            Assert.That(elfo.Name, Is.EqualTo("Legolas"));
            Assert.That(elfo.Health, Is.EqualTo(100));
            Assert.That(elfo.MaxHealth, Is.EqualTo(100));
            Assert.That(elfo.AttackValue, Is.EqualTo(0));
            Assert.That(elfo.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            elfo.ReceiveAttack(30);
            Assert.That(elfo.Health, Is.EqualTo(70));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            elfo.ReceiveAttack(150);
            Assert.That(elfo.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            elfo.ReceiveAttack(50);
            elfo.Cure(); // Curar restaura la vida al máximo
            Assert.That(elfo.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Arco arcoDeGaladhrim = new Arco("Arco de Galadhrim", 35);
            elfo.AddItem(arcoDeGaladhrim);

            // Verificamos que el valor de ataque aumenta
            Assert.That(elfo.AttackValue, Is.EqualTo(35));
            Assert.That(elfo.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            elfo.ReceiveAttack(100);
            elfo.ReceiveAttack(30);

            // Verificamos que la vida no cambia
            Assert.That(elfo.Health, Is.EqualTo(0));
        }
    }
}
