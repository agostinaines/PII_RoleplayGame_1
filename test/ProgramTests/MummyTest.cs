using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Romina
namespace ProgramTests
{
    public class MummyTest
    {
        private Library.Characters.Mummy _momia;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Momia antes de cada test con un nombre, 100 de vida y 10 VP
            _momia = new Library.Characters.Mummy("Mummy", 100, 10);
        }

        [Test]
        public void CrearMomia_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_momia.Name, Is.EqualTo("Mummy"));
            Assert.That(_momia.Health, Is.EqualTo(100));
            Assert.That(_momia.MaxHealth, Is.EqualTo(100));
            Assert.That(_momia.AttackValue, Is.EqualTo(0));
            Assert.That(_momia.Items.Count, Is.EqualTo(0));
            Assert.That(_momia.VictoryPoints, Is.EqualTo(10));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            // Daño reducido ---> 30 - (30 / 20) =  28,5 ---> 100 - 28,5 = 71,5 => 72
            _momia.ReceiveAttack(30);
            _momia.CalculateAttackValue();
            Assert.That(_momia.Health, Is.EqualTo(72));
        }
        
        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear una momia con vida inicial de 100 y 10 puntos de victoria
            var _mummy = new Mummy("Momia", 100, 10);

            // Simular la defensa
            IItem vendas = new Armor("Vendas Mágicas", 20);
            _mummy.AddItem(vendas);
            _mummy.CalculateDefenseValue();

            Console.WriteLine(_mummy.DefenseValue);

            // Atacamos con un daño de 50, debería reducirse un 5%
            _mummy.ReceiveAttack(50);

            // El daño efectivo será 50 * (1 - 0.05) * (1 - (DefenseValue / 100.0))
            // Asumiendo que el DefenseValue después de agregar las vendas es, por ejemplo, 20%
            double expectedDamage = 50 * (1 - 0.05) * (1 - (20.0 / 100.0)); // 20% de DefenseValue
            double expectedHealth = 100 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(_mummy.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _momia.ReceiveAttack(150);
            Assert.That(_momia.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _momia.ReceiveAttack(50);
            _momia.Cure(); // Curar restaura la vida al máximo
            Assert.That(_momia.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Sword espadaOxidada = new Sword("Espada Oxidada", 15, 0);
            _momia.AddItem(espadaOxidada);
            _momia.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(_momia.AttackValue, Is.EqualTo(15));
            Assert.That(_momia.Items.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _momia.ReceiveAttack(100);
            _momia.ReceiveAttack(30);

            // Verificamos que la vida no cambia
            Assert.That(_momia.Health, Is.EqualTo(0));
        }
    }
}
