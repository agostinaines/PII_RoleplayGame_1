using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Giant
namespace ProgramTests
{
    public class GiantTest
    {
        private Giant giant;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Giant antes de cada test con un nombre, 400 de vida y 40 VP
            giant = new Giant("Goliath", 400, 40);
        }

        [Test]
        public void CrearGiant_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(giant.Name, Is.EqualTo("Goliath"));
            Assert.That(giant.Health, Is.EqualTo(400));
            Assert.That(giant.MaxHealth, Is.EqualTo(400));
            Assert.That(giant.AttackValue, Is.EqualTo(0));
            Assert.That(giant.Items.Count, Is.EqualTo(0));
            Assert.That(giant.VictoryPoints, Is.EqualTo(40));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            //  Daño reducido ---> 50 - (50 * 0.30) = 35 ---> 400 - 35 = 365

            giant.ReceiveAttack(50);
            Assert.That(giant.Health, Is.EqualTo(365));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            giant.CalculateAttackValue();
            giant.CalculateDefenseValue();
            giant.ReceiveAttack(500);
            
            Assert.That(giant.Health, Is.EqualTo(50));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            giant.ReceiveAttack(100);
            giant.Cure(); // Curar restaura la vida al máximo
            Assert.That(giant.Health, Is.EqualTo(400));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Axe hachaGigante = new Axe("Hacha Gigante", 70);
            giant.AddItem(hachaGigante);
            giant.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(giant.AttackValue, Is.EqualTo(70));
            Assert.That(giant.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            giant.ReceiveAttack(600);
            giant.ReceiveAttack(600);
            giant.CalculateDefenseValue();
            giant.CalculateAttackValue();

            // Verificamos que la vida no cambia
            Assert.That(giant.Health, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear un gigante con vida inicial de 200 y 30 puntos de victoria
            var giant = new Giant("Goliath", 200, 30);

            // Simular la defensa
            IItem armadura = new Armor("Armadura de Hierro", 25);
            giant.AddItem(armadura);
            giant.CalculateDefenseValue();

            Console.WriteLine(giant.DefenseValue);

            // Atacamos con un daño de 80, debería reducirse un 30%
            giant.ReceiveAttack(80);

            // El daño efectivo será 80 * (1 - 0.30) * (1 - (DefenseValue / 100.0))
            double expectedDamage = 80 * (1 - 0.30) * (1 - (25.0 / 100.0));
            double expectedHealth = 200 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(giant.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void AgregarItem_AumentaValorDefensa()
        {
            Shield escudoGigante = new Shield("Escudo Gigante", 40);
            giant.AddItem(escudoGigante);
            giant.CalculateDefenseValue();
            // Verificamos que el valor de defensa aumenta
            Assert.That(giant.DefenseValue, Is.EqualTo(40));
        }
    }
}