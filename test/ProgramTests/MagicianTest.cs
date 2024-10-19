using Library.Characters;
using Library.Items;

// Test de Pilar
namespace ProgramTests
{
    public class TestsMagician
    {
        private Magician _magician;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Mago antes de cada test con un nombre y 100 de vida
            _magician = new Magician("Gandalf", 100);
        }

        [Test]
        public void CrearMago_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(_magician.Name, Is.EqualTo("Gandalf"));
            Assert.That(_magician.Health, Is.EqualTo(100));
            Assert.That(_magician.MaxHealth, Is.EqualTo(100));
            Assert.That(_magician.AttackValue, Is.EqualTo(0));
            Assert.That(_magician.Items.Count, Is.EqualTo(0));
            Assert.That(_magician.Spells.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            _magician.ReceiveAttack(40);
            Assert.That(_magician.Health, Is.EqualTo(60));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            _magician.ReceiveAttack(150);
            Assert.That(_magician.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            _magician.ReceiveAttack(50);  // Recibe daño
            _magician.Cure();  // Curar restaura la vida al máximo
            Assert.That(_magician.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Sword espadaGlamdring = new Sword("Glamdring", 20, 15);
            _magician.AddItem(espadaGlamdring);

            // Verificamos que el valor de ataque aumenta
            Assert.That(_magician.AttackValue, Is.EqualTo(20));
            Assert.That(_magician.DefenseValue, Is.EqualTo(15));
            Assert.That(_magician.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void AgregarSpell_IncrementaListaHechizos()
        {
            
            // Creamos un hechizo de prueba
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            _magician.AddSpell(bolaDeFuego);
            Console.WriteLine($"---------{_magician.AttackValue}");

            // Verificamos que el hechizo se agregó correctamente y que aumenta el vaor de ataque
            Assert.That(_magician.Spells.Count, Is.EqualTo(1));
            Assert.That(_magician.AttackValue, Is.EqualTo(50));
        }

        [Test]
        public void UsarSpell_HechizoDisponibleDevuelveAtaque()
        {
            // Creamos y agregamos un hechizo de prueba
            Spell rayo = new Spell("Rayo", 40);
            _magician.AddSpell(rayo);

            // Verificamos que el mago puede usar el hechizo "Rayo"
            int ataque = _magician.UsarSpell(rayo);
            Assert.That(ataque, Is.EqualTo(40));
        }

        [Test]
        public void UsarSpell_HechizoNoDisponibleDevuelveCero()
        {
            // Creamos un hechizo que no agregamos
            Spell escudoMagico = new Spell("Escudo Mágico", 0);

            // Intentamos usar un hechizo que no está en la lista de hechizos
            int ataque = _magician.UsarSpell(escudoMagico);
            Assert.That(ataque, Is.EqualTo(0));
        }

        [Test]
        public void LanzarHechizo_HechizoDisponible_SoloUsaHechizoSiLoTiene()
        {
            // Creamos dos hechizos
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            Spell rayo = new Spell("Rayo", 40);

            // Agregamos solo el hechizo "Bola de Fuego"
            _magician.AddSpell(bolaDeFuego);

            // Verificamos que puede lanzar "Bola de Fuego"
            int ataqueBolaDeFuego = _magician.UsarSpell(bolaDeFuego);
            Assert.That(ataqueBolaDeFuego, Is.EqualTo(50));

            // Verificamos que no puede lanzar "Rayo" (no lo tiene)
            int ataqueRayo = _magician.UsarSpell(rayo);
            Assert.That(ataqueRayo, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            _magician.ReceiveAttack(100);
            _magician.ReceiveAttack(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.That(_magician.Health, Is.EqualTo(0));
        }
    }
}
