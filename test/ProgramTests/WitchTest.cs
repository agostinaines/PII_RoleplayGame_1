using Library.Characters;
using Library.Items;
using NUnit.Framework;

public class TestsWitch
{
    private Witch _witch;

    [SetUp]
    public void Setup()
    {
        _witch = new Witch("Circe", 100, 4);
    }

    [Test]
    public void CrearBruja_ValoresInicialesCorrectos()
    {
        Assert.That(_witch.Name, Is.EqualTo("Circe"));
        Assert.That(_witch.Health, Is.EqualTo(100));
        Assert.That(_witch.MaxHealth, Is.EqualTo(100));
        Assert.That(_witch.AttackValue, Is.EqualTo(0));
        Assert.That(_witch.Spells.Count, Is.EqualTo(0));
    }

    [Test]
    public void RecibirAtaque_ReduceVida()
    {
        _witch.ReceiveAttack(30);
        Assert.That(_witch.Health, Is.EqualTo(70));
    }

    [Test]
    public void RecibirAtaque_NoBajaDeCero()
    {
        _witch.ReceiveAttack(200);
        Assert.That(_witch.Health, Is.EqualTo(0));
    }

    [Test]
    public void AgregarSpell_IncrementaListaHechizos()
    {
        // Creamos un hechizo de prueba
        Spell hechizoFuego = new Spell("Hechizo de Fuego", 25);
        _witch.AddSpell(hechizoFuego);

        // Verificamos que el hechizo se agregó correctamente
        Assert.That(_witch.Spells.Count, Is.EqualTo(1));
        Assert.That(_witch.AttackValue, Is.EqualTo(25));
    }

    [Test]
    public void UsarSpell_HechizoDisponibleDevuelveAtaque()
    {
        // Creamos y agregamos un hechizo de prueba
        Spell hechizoHielo = new Spell("Hechizo de Hielo", 40);
        _witch.AddSpell(hechizoHielo);

        // Verificamos que la bruja puede usar el hechizo "Hechizo de Hielo"
        int ataque = _witch.UseSpell(hechizoHielo);
        Assert.That(ataque, Is.EqualTo(40));
    }

    [Test]
    public void UsarSpell_HechizoNoDisponibleDevuelveCero()
    {
        // Creamos un hechizo que no agregamos
        Spell hechizoRayo = new Spell("Hechizo de Rayo", 0);

        // Intentamos usar un hechizo que no está en la lista de hechizos
        int ataque = _witch.UseSpell(hechizoRayo);
        Assert.That(ataque, Is.EqualTo(0));
    }

    [Test]
    public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
    {
        // Reducimos la vida a cero
        _witch.ReceiveAttack(100);
        _witch.ReceiveAttack(50);

        // Verificamos que la vida no cambia
        Assert.That(_witch.Health, Is.EqualTo(0));
    }
}