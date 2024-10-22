using Library.Characters;
using Library.Items;

// Test de Agostina
namespace ProgramTests
{
    public class TestsElf
    {
        private Elf elf;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Elfo antes de cada test con un nombre y 100 de vida
            elf = new Elf("Legolas", 100);
        }

        [Test]
        public void CrearElfo_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(elf.Name, Is.EqualTo("Legolas"));
            Assert.That(elf.Health, Is.EqualTo(100));
            Assert.That(elf.MaxHealth, Is.EqualTo(100));
            Assert.That(elf.AttackValue, Is.EqualTo(0));
            Assert.That(elf.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            elf.ReceiveAttack(30);
            Assert.That(elf.Health, Is.EqualTo(70));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            elf.ReceiveAttack(150);
            Assert.That(elf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            elf.ReceiveAttack(50);
            elf.Cure(); // Curar restaura la vida al máximo
            Assert.That(elf.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Bow arcoDeGaladhrim = new Bow("Arco de Galadhrim", 35);
            elf.AddItem(arcoDeGaladhrim);

            // Verificamos que el valor de ataque aumenta
            Assert.That(elf.AttackValue, Is.EqualTo(35));
            Assert.That(elf.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            elf.ReceiveAttack(100);
            elf.ReceiveAttack(30);

            // Verificamos que la vida no cambia
            Assert.That(elf.Health, Is.EqualTo(0));
        }
    }
}
