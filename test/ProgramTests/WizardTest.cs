using Library.Characters;
using Library.Items;

// Test de Pilar
namespace ProgramTests
{
    public class TestsWizard
    {
        private Wizard wizard;

        [SetUp]
        public void Setup()
        {
            // Inicializamos un objeto Mago antes de cada test con un nombre y 100 de vida
            wizard = new Wizard("Gandalf", 100);
        }

        [Test]
        public void CrearMago_ValoresInicialesCorrectos()
        {
            // Verificamos que los valores iniciales son los esperados
            Assert.That(wizard.Name, Is.EqualTo("Gandalf"));
            Assert.That(wizard.Health, Is.EqualTo(100));
            Assert.That(wizard.MaxHealth, Is.EqualTo(100));
            Assert.That(wizard.AttackValue, Is.EqualTo(0));
            Assert.That(wizard.Items.Count, Is.EqualTo(0));
            Assert.That(wizard.Spells.Count, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_ReduceVida()
        {
            wizard.ReceiveAttack(40);
            Assert.That(wizard.Health, Is.EqualTo(60));
        }

        [Test]
        public void RecibirAtaque_NoBajaDeCero()
        {
            wizard.ReceiveAttack(150);
            Assert.That(wizard.Health, Is.EqualTo(0));
        }

        [Test]
        public void Curar_RestauraVidaAlMaximo()
        {
            wizard.ReceiveAttack(50);  // Recibe daño
            wizard.Cure();  // Curar restaura la vida al máximo
            Assert.That(wizard.Health, Is.EqualTo(100));
        }

        [Test]
        public void AgregarItem_AumentaValorAtaque()
        {
            // Creamos un item de prueba
            Sword espadaGlamdring = new Sword("Glamdring", 20, 15);
            wizard.AddItem(espadaGlamdring);
            

            // Verificamos que el valor de ataque aumenta
            wizard.CalculateAttackValue();
            wizard.CalculateDefenseValue();
            Assert.That(wizard.AttackValue, Is.EqualTo(20));
            Assert.That(wizard.DefenseValue, Is.EqualTo(15));
            Assert.That(wizard.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void AgregarSpell_IncrementaListaHechizos()
        {
            
            // Creamos un hechizo de prueba
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            wizard.AddSpell(bolaDeFuego);
            Console.WriteLine($"---------{wizard.AttackValue}");

            // Verificamos que el hechizo se agregó correctamente y que aumenta el vaor de ataque
            Assert.That(wizard.Spells.Count, Is.EqualTo(1));
            Assert.That(wizard.AttackValue, Is.EqualTo(50));
        }

        [Test]
        public void UsarSpell_HechizoDisponibleDevuelveAtaque()
        {
            // Creamos y agregamos un hechizo de prueba
            Spell rayo = new Spell("Rayo", 40);
            wizard.AddSpell(rayo);

            // Verificamos que el mago puede usar el hechizo "Rayo"
            int ataque = wizard.UseSpell(rayo);
            Assert.That(ataque, Is.EqualTo(40));
        }

        [Test]
        public void UsarSpell_HechizoNoDisponibleDevuelveCero()
        {
            // Creamos un hechizo que no agregamos
            Spell escudoMagico = new Spell("Escudo Mágico", 0);

            // Intentamos usar un hechizo que no está en la lista de hechizos
            int ataque = wizard.UseSpell(escudoMagico);
            Assert.That(ataque, Is.EqualTo(0));
        }

        [Test]
        public void LanzarHechizo_HechizoDisponible_SoloUsaHechizoSiLoTiene()
        {
            // Creamos dos hechizos
            Spell bolaDeFuego = new Spell("Bola de Fuego", 50);
            Spell rayo = new Spell("Rayo", 40);

            // Agregamos solo el hechizo "Bola de Fuego"
            wizard.AddSpell(bolaDeFuego);

            // Verificamos que puede lanzar "Bola de Fuego"
            int ataqueBolaDeFuego = wizard.UseSpell(bolaDeFuego);
            Assert.That(ataqueBolaDeFuego, Is.EqualTo(50));

            // Verificamos que no puede lanzar "Rayo" (no lo tiene)
            int ataqueRayo = wizard.UseSpell(rayo);
            Assert.That(ataqueRayo, Is.EqualTo(0));
        }

        [Test]
        public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
        {
            // Reducimos la vida a cero
            wizard.ReceiveAttack(100);
            wizard.ReceiveAttack(30);  // Intentamos atacarlo nuevamente

            // Verificamos que la vida no cambia
            Assert.That(wizard.Health, Is.EqualTo(0));
        }
    }
}
