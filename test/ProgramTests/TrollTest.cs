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
            // Crear un troll con vida inicial de 200
            var troll = new Troll("Troll", 200, 10);

            // Agregar un ítem de defensa al troll para que tenga un valor de defensa
            IItem armadura = new Armor("Armadura de Piel", 20);
            troll.AddItem(armadura);
            troll.CalculateDefenseValue();

            // Simulamos el ataque con un daño de 30
            troll.ReceiveAttack(30);

            // El daño efectivo será 30 * (1 - 0.20) = 24, entonces la vida restante será 200 - 24 = 176
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
            IItem botas = new Armor("Botas de Hierro", 20);
            troll.AddItem(botas);
            troll.CalculateDefenseValue();

            Console.WriteLine(troll.DefenseValue);

            // Atacamos con un daño de 50, debería reducirse en función del valor de defensa
            troll.ReceiveAttack(50);

            // El daño efectivo será 50 * (1 - 0.20) = 40, entonces la vida restante será 100 - 40 = 60
            Assert.That(troll.Health, Is.EqualTo(60)); 
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