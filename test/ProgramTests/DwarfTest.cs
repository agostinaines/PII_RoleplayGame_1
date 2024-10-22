using Library.Characters;
using Library.Items;
using Library.Interfaces;

// Test de Luis
namespace ProgramTests
{
    public class TestDwarf
    {
        private Dwarf _dwarf;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Enano antes de cada test con un nombre y 100 de vida
            _dwarf = new Dwarf("Gimli", 100);
        }

        [Test]
        public void CrearEnano_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_dwarf.Name, Is.EqualTo("Gimli"));
            Assert.That(_dwarf.Health, Is.EqualTo(100));
            Assert.That(_dwarf.MaxHealth, Is.EqualTo(100));
            Assert.That(_dwarf.AttackValue, Is.EqualTo(0));
            Assert.That(_dwarf.DefenseValue, Is.EqualTo(0));
            Assert.That(_dwarf.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVidaConArmadura()
        {
            // Daño es reducido por la armadura, se aplica un 30% de reducción
            _dwarf.ReceiveAttack(100);
            // El daño efectivo es 100 - 30% = 70, por lo que la vida debe ser 100 - 70 = 30
            Assert.That(_dwarf.Health, Is.EqualTo(30));
        }
        
        [Test]
        public void RecibirAtaque_ConDefensa_ReduceDaño()
        {
            // Crear un enano con vida inicial de 100
            var _dwarf = new Dwarf("Enano", 100);

            // Simular la defensa
            IItem botas = new Armor("Botas de Hierro", 20);
            _dwarf.AddItem(botas);
            _dwarf.CalculateDefenseValue();

            Console.WriteLine(_dwarf.DefenseValue);

            // Atacamos con un daño de 50, debería reducirse un 30%
            _dwarf.ReceiveAttack(50);

            // El daño efectivo será 50 * (1 - 0.30) * (1 - (DefenseValue / 100.0))
            double expectedDamage = 50 * (1 - 0.30) * (1 - (20.0 / 100.0));
            double expectedHealth = 100 - expectedDamage;

            // Comprobar que la salud final es la esperada
            Assert.That(_dwarf.Health, Is.EqualTo((int)expectedHealth));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _dwarf.ReceiveAttack(200);
            Assert.That(_dwarf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _dwarf.ReceiveAttack(50);  // Recibe daño
            _dwarf.Cure();  // Curar restaura la vida al máximo
            Assert.That(_dwarf.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Axe hachaDeGuerra = new Axe("Hacha de Guerra", 40);
            _dwarf.AddItem(hachaDeGuerra);

            // Verificamos que el valor de ataque aumenta
            _dwarf.CalculateAttackValue();
            Assert.That(_dwarf.AttackValue, Is.EqualTo(40));
            Assert.That(_dwarf.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _dwarf.ReceiveAttack(200);
            _dwarf.ReceiveAttack(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.That(_dwarf.Health, Is.EqualTo(0));
        }
    }
}
