using Library.Characters;
using Library.Items;

// Test de Romina
namespace ProgramTests
{
    public class DragonTest
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

            // Verificamos que la vida no cambia
            Assert.That(_dragon.Health, Is.EqualTo(0));
        }

        [Test]
        public void AgregarItem_AumentaValorDefensa()
        {
            Shield escudoEscamas = new Shield("Escudo de Escamas", 30);
            _dragon.AddItem(escudoEscamas);
            
            //Verificamos que el valor de defensa aumenta
            Assert.That(_dragon.DefenseValue, Is.EqualTo(30));
        }

    }
}

