using Library.Characters;
using Library.Items;

// Test de Romina
namespace ProgramTests
{
    public class OrcTest
    {
        private Orc orc;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Orc antes de cada test con un nombre, 150 de vida y 15 VP
            orc = new Orc("Gruk", 150, 15);
        }

        [Test]
        public void CrearOrc_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(orc.Name, Is.EqualTo("Gruk"));
            Assert.That(orc.Health, Is.EqualTo(150));
            Assert.That(orc.MaxHealth, Is.EqualTo(150));
            Assert.That(orc.AttackValue, Is.EqualTo(0));
            Assert.That(orc.Items.Count, Is.EqualTo(0));
            Assert.That(orc.VictoryPoints, Is.EqualTo(15));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            orc.ReceiveAttack(30);
            Assert.That(orc.Health, Is.EqualTo(120));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            orc.ReceiveAttack(200);
            Assert.That(orc.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            orc.ReceiveAttack(50);
            orc.Cure(); // Curar restaura la vida al máximo
            Assert.That(orc.Health, Is.EqualTo(150));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Sword espadaRustica = new Sword("Espada Rustica", 25, 0);
            orc.AddItem(espadaRustica);
            orc.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(orc.AttackValue, Is.EqualTo(25));
            Assert.That(orc.Items.Count, Is.EqualTo(1));

            [Test]
            private void RecibirAtaqueAEnemigoMuertoNoCambiaVida()
            {
                // Reducimos la vida a cero
                orc.ReceiveAttack(200);
                orc.ReceiveAttack(30);

                // Verificamos que la vida no cambia
                Assert.That(orc.Health, Is.EqualTo(0));
            }
        }
    }
}
