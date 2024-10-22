using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Giant
namespace ProgramTests
{
    public partial class GiantTest
    {
        private Giant _giant;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Giant antes de cada test con un nombre, 400 de vida y 40 VP
            _giant = new Giant("Goliath", 400, 40);
        }

        [Test]
        public void CrearGiant_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_giant.Name, Is.EqualTo("Goliath"));
            Assert.That(_giant.Health, Is.EqualTo(400));
            Assert.That(_giant.MaxHealth, Is.EqualTo(400));
            Assert.That(_giant.AttackValue, Is.EqualTo(0));
            Assert.That(_giant.Items.Count, Is.EqualTo(0));
            Assert.That(_giant.VictoryPoints, Is.EqualTo(40));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            //  Daño reducido ---> 50 - (50 * 0.30) = 35 ---> 400 - 35 = 365

            _giant.ReceiveAttack(50);
            Assert.That(_giant.Health, Is.EqualTo(365));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _giant.CalculateAttackValue();
            _giant.CalculateDefenseValue();
            _giant.ReceiveAttack(500);
            
            Assert.That(_giant.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _giant.ReceiveAttack(100);
            _giant.Cure(); // Curar restaura la vida al máximo
            Assert.That(_giant.Health, Is.EqualTo(400));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Axe hachaGigante = new Axe("Hacha Gigante", 70);
            _giant.AddItem(hachaGigante);
            _giant.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(_giant.AttackValue, Is.EqualTo(70));
            Assert.That(_giant.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _giant.ReceiveAttack(500);
            _giant.ReceiveAttack(30);
            _giant.CalculateDefenseValue();
            _giant.CalculateAttackValue();

            // Verificamos que la vida no cambia
            Assert.That(_giant.Health, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear un gigante con vida inicial de 200 y 30 puntos de victoria
            var _giant = new Giant("Goliath", 200, 30);

            // Simular la defensa
            IItem armadura = new Armor("Armadura de Hierro", 25);
            _giant.AddItem(armadura);
            _giant.CalculateDefenseValue();

            Console.WriteLine(_giant.DefenseValue);

            // Atacamos con un daño de 80, debería reducirse un 30%
            _giant.ReceiveAttack(80);

            // El daño efectivo será 80 * (1 - 0.30) * (1 - (DefenseValue / 100.0))
            double expectedDamage = 80 * (1 - 0.30) * (1 - (25.0 / 100.0));
            double expectedHealth = 200 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(_giant.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void AgregarItem_AumentaValorDefensa()
        {
            Shield escudoGigante = new Shield("Escudo Gigante", 40);
            _giant.AddItem(escudoGigante);
            _giant.CalculateDefenseValue();
            // Verificamos que el valor de defensa aumenta
            Assert.That(_giant.DefenseValue, Is.EqualTo(40));
        }
    }
}