using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Romina
namespace ProgramTests
{
    public partial class DragonTest
    {
        private Dragon _dragon;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Orc antes de cada test con un nombre, 150 de vida y 15 VP
            _dragon = new Dragon("Draco", 300, 30);
        }

        [Test]
        public void CrearDragon_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_dragon.Name, Is.EqualTo("Draco"));
            Assert.That(_dragon.Health, Is.EqualTo(300));
            Assert.That(_dragon.MaxHealth, Is.EqualTo(300));
            Assert.That(_dragon.AttackValue, Is.EqualTo(0));
            Assert.That(_dragon.Items.Count, Is.EqualTo(0));
            Assert.That(_dragon.VictoryPoints, Is.EqualTo(30));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            //  Daño reducido ---> 30 - (30 / 5) = 24 ---> 300 - 24 = 276

            _dragon.ReceiveAttack(30);
            Assert.That(_dragon.Health, Is.EqualTo(276));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _dragon.CalculateAttackValue();
            _dragon.CalculateDefenseValue();
            _dragon.ReceiveAttack(400);
            
            Assert.That(_dragon.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _dragon.ReceiveAttack(50);
            _dragon.Cure(); // Curar restaura la vida al máximo
            Assert.That(_dragon.Health, Is.EqualTo(300));
        }
    
        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Axe hachaGuerra = new Axe("Hacha de Guerra", 50);
            _dragon.AddItem(hachaGuerra);
            _dragon.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(_dragon.AttackValue, Is.EqualTo(50));
            Assert.That(_dragon.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _dragon.ReceiveAttack(500);
            _dragon.ReceiveAttack(30);
            _dragon.CalculateDefenseValue();
            _dragon.CalculateAttackValue();

            // Verificamos que la vida no cambia
            Assert.That(_dragon.Health, Is.EqualTo(0));
        }
        
        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear un dragón con vida inicial de 100 y 10 puntos de victoria
            var _dragon = new Dragon("Dragón", 100, 10);

            // Simular la defensa
            IItem escamas = new Armor("Escamas Resistentes", 20);
            _dragon.AddItem(escamas);
            _dragon.CalculateDefenseValue();

            Console.WriteLine(_dragon.DefenseValue);

            // Atacamos con un daño de 50, debería reducirse un 20%
            _dragon.ReceiveAttack(50);

            // El daño efectivo será 50 * (1 - 0.20) * (1 - (DefenseValue / 100.0))
            // Asumiendo que el DefenseValue después de agregar las escamas es, por ejemplo, 20%
            double expectedDamage = 50 * (1 - 0.20) * (1 - (20.0 / 100.0));
            double expectedHealth = 100 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(_dragon.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void AgregarItem_AumentaValorDefensa()
        {
            Shield escudoEscamas = new Shield("Escudo de Escamas", 30);
            _dragon.AddItem(escudoEscamas);
            _dragon.CalculateDefenseValue();
            //Verificamos que el valor de defensa aumenta
            Assert.That(_dragon.DefenseValue, Is.EqualTo(30));
        }

    }
}

