using Library.Characters;
using Library.Items;

// Test de Agostina
namespace ProgramTests
{
    public class TestsElf
    {
        private Elf _elf;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Elfo antes de cada test con un nombre y 100 de vida
            _elf = new Elf("Legolas", 100);
        }

        [Test]
        public void CrearElfo_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_elf.Name, Is.EqualTo("Legolas"));
            Assert.That(_elf.Health, Is.EqualTo(100));
            Assert.That(_elf.MaxHealth, Is.EqualTo(100));
            Assert.That(_elf.AttackValue, Is.EqualTo(0));
            Assert.That(_elf.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            _elf.ReceiveAttack(30);
            Assert.That(_elf.Health, Is.EqualTo(70));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _elf.ReceiveAttack(150);
            Assert.That(_elf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _elf.ReceiveAttack(50);
            _elf.Cure(); // Curar restaura la vida al máximo
            Assert.That(_elf.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Bow arcoDeGaladhrim = new Bow("Arco de Galadhrim", 35);
            _elf.AddItem(arcoDeGaladhrim);

            // Verificamos que el valor de ataque aumenta
            _elf.CalculateAttackValue();
            Assert.That(_elf.AttackValue, Is.EqualTo(35));
            Assert.That(_elf.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _elf.ReceiveAttack(100);
            _elf.ReceiveAttack(30);

            // Verificamos que la vida no cambia
            Assert.That(_elf.Health, Is.EqualTo(0));
        }
    }
}
