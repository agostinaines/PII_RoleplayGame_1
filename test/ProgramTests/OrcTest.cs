using Library.Characters;
using Library.Items;

// Test de Romina
namespace ProgramTests
{
    public class OrcTest
    {
        private Orc _orc;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Orc antes de cada test con un nombre, 150 de vida y 15 VP
            _orc = new Orc("Gruk", 150, 15);
        }

        [Test]
        public void CrearOrc_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_orc.Name, Is.EqualTo("Gruk"));
            Assert.That(_orc.Health, Is.EqualTo(150));
            Assert.That(_orc.MaxHealth, Is.EqualTo(150));
            Assert.That(_orc.AttackValue, Is.EqualTo(0));
            Assert.That(_orc.Items.Count, Is.EqualTo(0));
            Assert.That(_orc.VictoryPoints, Is.EqualTo(15));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            _orc.ReceiveAttack(30);
            Assert.That(_orc.Health, Is.EqualTo(120));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _orc.ReceiveAttack(200);
            Assert.That(_orc.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _orc.ReceiveAttack(50);
            _orc.Cure(); // Curar restaura la vida al máximo
            Assert.That(_orc.Health, Is.EqualTo(150));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Sword espadaRustica = new Sword("Espada Rustica", 25, 0);           
            _orc.AddItem(espadaRustica);

            // Verificamos que el valor de ataque aumenta
            Assert.That(_orc.AttackValue, Is.EqualTo(25));
            Assert.That(_orc.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _orc.ReceiveAttack(200);
            _orc.ReceiveAttack(30);

            // Verificamos que la vida no cambia
            Assert.That(_orc.Health, Is.EqualTo(0));
        }
    }
}
