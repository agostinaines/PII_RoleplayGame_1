using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Troll
namespace ProgramTests
{
    public partial class TrollTest
    {
        private Troll _troll;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Troll antes de cada test con un nombre, 200 de vida y 20 VP
            _troll = new Troll("Grom", 200, 20);
        }

        [Test]
        public void CrearTroll_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_troll.Name, Is.EqualTo("Grom"));
            Assert.That(_troll.Health, Is.EqualTo(200));
            Assert.That(_troll.MaxHealth, Is.EqualTo(200));
            Assert.That(_troll.AttackValue, Is.EqualTo(0));
            Assert.That(_troll.Items.Count, Is.EqualTo(0));
            Assert.That(_troll.VictoryPoints, Is.EqualTo(20));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            //  Daño reducido ---> 30 - (30 / 5) = 24 ---> 200 - 24 = 176

            _troll.ReceiveAttack(30);
            Assert.That(_troll.Health, Is.EqualTo(176));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _troll.CalculateAttackValue();
            _troll.CalculateDefenseValue();
            _troll.ReceiveAttack(400);
            
            Assert.That(_troll.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _troll.ReceiveAttack(50);
            _troll.Cure(); // Curar restaura la vida al máximo
            Assert.That(_troll.Health, Is.EqualTo(200));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Axe hachaDeBatalla = new Axe("Hacha de Batalla", 40);
            _troll.AddItem(hachaDeBatalla);
            _troll.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(_troll.AttackValue, Is.EqualTo(40));
            Assert.That(_troll.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _troll.ReceiveAttack(500);
            _troll.ReceiveAttack(30);
            _troll.CalculateDefenseValue();
            _troll.CalculateAttackValue();

            // Verificamos que la vida no cambia
            Assert.That(_troll.Health, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear un troll con vida inicial de 100 y 10 puntos de victoria
            var _troll = new Troll("Troll", 100, 10);

            // Simular la defensa
            IItem armadura = new Armor("Armadura de Piel", 20);
            _troll.AddItem(armadura);
            _troll.CalculateDefenseValue();

            Console.WriteLine(_troll.DefenseValue);

            // Atacamos con un daño de 50, debería reducirse un 20% (asumiendo un 20% DefenseValue)
            _troll.ReceiveAttack(50);

            // El daño efectivo será 50 * (1 - 0.20) * (1 - (DefenseValue / 100.0))
            double expectedDamage = 50 * (1 - 0.20) * (1 - (20.0 / 100.0));
            double expectedHealth = 100 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(_troll.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void AgregarItem_AumentaValorDefensa()
        {
            Shield escudoDeHierro = new Shield("Escudo de Hierro", 30);
            _troll.AddItem(escudoDeHierro);
            _troll.CalculateDefenseValue();
            // Verificamos que el valor de defensa aumenta
            Assert.That(_troll.DefenseValue, Is.EqualTo(30));
        }
    }
}