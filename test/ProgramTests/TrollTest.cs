using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Troll
namespace ProgramTests
{
    public partial class TrollTest
    {
        private Troll troll;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Troll antes de cada test con un nombre, 200 de vida y 20 VP
            troll = new Troll("Grom", 200, 20);
        }

        [Test]
        public void CrearTroll_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(troll.Name, Is.EqualTo("Grom"));
            Assert.That(troll.Health, Is.EqualTo(200));
            Assert.That(troll.MaxHealth, Is.EqualTo(200));
            Assert.That(troll.AttackValue, Is.EqualTo(0));
            Assert.That(troll.Items.Count, Is.EqualTo(0));
            Assert.That(troll.VictoryPoints, Is.EqualTo(20));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            //  Daño reducido ---> 30 - (30 / 5) = 24 ---> 200 - 24 = 176

            troll.ReceiveAttack(30);
            Assert.That(troll.Health, Is.EqualTo(176));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            troll.CalculateAttackValue();
            troll.CalculateDefenseValue();
            troll.ReceiveAttack(400);
            
            Assert.That(troll.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            troll.ReceiveAttack(50);
            troll.Cure(); // Curar restaura la vida al máximo
            Assert.That(troll.Health, Is.EqualTo(200));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Axe hachaDeBatalla = new Axe("Hacha de Batalla", 40);
            troll.AddItem(hachaDeBatalla);
            troll.CalculateAttackValue();

            // Verificamos que el valor de ataque aumenta
            Assert.That(troll.AttackValue, Is.EqualTo(40));
            Assert.That(troll.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            troll.ReceiveAttack(500);
            troll.ReceiveAttack(30);
            troll.CalculateDefenseValue();
            troll.CalculateAttackValue();

            // Verificamos que la vida no cambia
            Assert.That(troll.Health, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear un troll con vida inicial de 100 y 10 puntos de victoria
            var troll = new Troll("Troll", 100, 10);

            // Simular la defensa
            IItem armadura = new Armor("Armadura de Piel", 20);
            troll.AddItem(armadura);
            troll.CalculateDefenseValue();

            Console.WriteLine(troll.DefenseValue);

            // Atacamos con un daño de 50, debería reducirse un 20% (asumiendo un 20% DefenseValue)
            troll.ReceiveAttack(50);

            // El daño efectivo será 50 * (1 - 0.20) * (1 - (DefenseValue / 100.0))
            double expectedDamage = 50 * (1 - 0.20) * (1 - (20.0 / 100.0));
            double expectedHealth = 100 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(troll.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void AgregarItem_AumentaValorDefensa()
        {
            Shield escudoDeHierro = new Shield("Escudo de Hierro", 30);
            troll.AddItem(escudoDeHierro);
            troll.CalculateDefenseValue();
            // Verificamos que el valor de defensa aumenta
            Assert.That(troll.DefenseValue, Is.EqualTo(30));
        }
    }
}