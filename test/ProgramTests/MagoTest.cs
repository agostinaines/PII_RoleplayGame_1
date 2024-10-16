using Library.Items;
using Library.Personajes;

// Test de Pilar
namespace ProgramTests
{
    public class TestsMago
    {
        private Mago mago;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Mago antes de cada test con un nombre y 100 de vida
            mago = new Mago("Gandalf", 100);
        }

        [Test]
        public void CrearMago_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(mago.Name, Is.EqualTo("Gandalf"));
            Assert.That(mago.Health, Is.EqualTo(100));
            Assert.That(mago.MaxHealth, Is.EqualTo(100));
            Assert.That(mago.AttackValue, Is.EqualTo(0));
            Assert.That(mago.Items.Count, Is.EqualTo(0));
            Assert.That(mago.Spells.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            mago.ReceiveAttack(40);
            Assert.That(mago.Health, Is.EqualTo(60));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            mago.ReceiveAttack(150);
            Assert.That(mago.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            mago.ReceiveAttack(50);  // Recibe daño
            mago.Cure();  // Curar restaura la vida al máximo
            Assert.That(mago.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Espada espadaGlamdring = new Espada("Glamdring", 20, 15);
            mago.AddItem(espadaGlamdring);

            // Verificamos que el valor de ataque aumenta
            Assert.That(mago.AttackValue, Is.EqualTo(20));
            Assert.That(mago.DefenseValue, Is.EqualTo(15));
            Assert.That(mago.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void AgregarSpell_IncrementaListaHechizos()
        {
            
            // Creamos un hechizo de prueba
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            mago.AddSpell(bolaDeFuego);
            Console.WriteLine($"---------{mago.AttackValue}");

            // Verificamos que el hechizo se agregó correctamente y que aumenta el vaor de ataque
            Assert.That(mago.Spells.Count, Is.EqualTo(1));
            Assert.That(mago.AttackValue, Is.EqualTo(50));
        }

        [Test]
        public void UsarSpell_HechizoDisponibleDevuelveAtaque()
        {
            // Creamos y agregamos un hechizo de prueba
            Spell rayo = new Spell("Rayo", 40);
            mago.AddSpell(rayo);

            // Verificamos que el mago puede usar el hechizo "Rayo"
            int ataque = mago.UsarSpell(rayo);
            Assert.That(ataque, Is.EqualTo(40));
        }

        [Test]
        public void UsarSpell_HechizoNoDisponibleDevuelveCero()
        {
            // Creamos un hechizo que no agregamos
            Spell escudoMagico = new Spell("Escudo Mágico", 0);

            // Intentamos usar un hechizo que no está en la lista de hechizos
            int ataque = mago.UsarSpell(escudoMagico);
            Assert.That(ataque, Is.EqualTo(0));
        }

        [Test]
        public void LanzarHechizo_HechizoDisponible_SoloUsaHechizoSiLoTiene()
        {
            // Creamos dos hechizos
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            Spell rayo = new Spell("Rayo", 40);

            // Agregamos solo el hechizo "Bola de Fuego"
            mago.AddSpell(bolaDeFuego);

            // Verificamos que puede lanzar "Bola de Fuego"
            int ataqueBolaDeFuego = mago.UsarSpell(bolaDeFuego);
            Assert.That(ataqueBolaDeFuego, Is.EqualTo(50));

            // Verificamos que no puede lanzar "Rayo" (no lo tiene)
            int ataqueRayo = mago.UsarSpell(rayo);
            Assert.That(ataqueRayo, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            mago.ReceiveAttack(100);
            mago.ReceiveAttack(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.That(mago.Health, Is.EqualTo(0));
        }
    }
}
