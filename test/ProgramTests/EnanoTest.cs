using Library.Items;
using Library.Personajes;

// Test de Luis
namespace ProgramTests
{
    public class TestEnano
    {
        private Enano enano;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Enano antes de cada test con un nombre y 100 de vida
            enano = new Enano("Gimli", 100);
        }

        [Test]
        public void CrearEnano_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(enano.Name, Is.EqualTo("Gimli"));
            Assert.That(enano.Health, Is.EqualTo(100));
            Assert.That(enano.MaxHealth, Is.EqualTo(100));
            Assert.That(enano.AttackValue, Is.EqualTo(0));
            Assert.That(enano.DefenseValue, Is.EqualTo(30));
            Assert.That(enano.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVidaConArmadura()
        {
            // Daño es reducido por la armadura, se aplica un 30% de reducción
            enano.ReceiveAttack(100);
            // El daño efectivo es 100 - 30% = 70, por lo que la vida debe ser 100 - 70 = 30
            Assert.That(enano.Health, Is.EqualTo(30));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            enano.ReceiveAttack(200);
            Assert.That(enano.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            enano.ReceiveAttack(50);  // Recibe daño
            enano.Cure();  // Curar restaura la vida al máximo
            Assert.That(enano.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Hacha hachaDeGuerra = new Hacha("Hacha de Guerra", 40);
            enano.AddItem(hachaDeGuerra);

            // Verificamos que el valor de ataque aumenta
            Assert.That(enano.AttackValue, Is.EqualTo(40));
            Assert.That(enano.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            enano.ReceiveAttack(200);
            enano.ReceiveAttack(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.That(enano.Health, Is.EqualTo(0));
        }
    }
}
