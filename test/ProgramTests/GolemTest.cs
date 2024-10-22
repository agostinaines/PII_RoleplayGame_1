using Library.Characters;
using Library.Items;
using Library.Interfaces;
namespace ProgramTests;


public class GolemTest
{
    private Golem _golem;

    [SetUp]
    public void Setup()
    {
        // Inicializamos un objeto golem antes de cada test con un nombre, 600 de vida y 6 VP
        _golem = new Golem("Gerardo", 600, 6);
    }

    [Test]
    public void CrearDragon_ValoresInicialesCorrectos()
    {
        // Verificamos que los valores iniciales son los esperados
        Assert.That(_golem.Name, Is.EqualTo("Gerardo"));
        Assert.That(_golem.Health, Is.EqualTo(600));
        Assert.That(_golem.MaxHealth, Is.EqualTo(600));
        Assert.That(_golem.AttackValue, Is.EqualTo(0));
        Assert.That(_golem.Items.Count, Is.EqualTo(0));
        Assert.That(_golem.VictoryPoints, Is.EqualTo(6));
    }

    [Test]
    public void RecibirAtaque_ReduceVida()
    {
        //  Daño reducido ---> 36 - (36 * 60 / 100) = 14,4 ---> 300 - 14,4 = 585,6 => 586

        _golem.ReceiveAttack(36);
        Assert.That(_golem.Health, Is.EqualTo(586));
    }
    
    [Test]
    public void RecibirAtaque_ConDefensa_ReduceDaño()
    {
        // Crear un golem con vida inicial de 100 y 10 puntos de victoria
        var _golem = new Golem("Golem", 100, 10);

        // Simular la defensa
        IItem piedra = new Armor("Piedra Mágica", 20);
        _golem.AddItem(piedra);
        _golem.CalculateDefenseValue();

        Console.WriteLine(_golem.DefenseValue);

        // Atacamos con un daño de 50, debería reducirse un 60%
        _golem.ReceiveAttack(50);

        // El daño efectivo será 50 * (1 - 0.60) * (1 - (DefenseValue / 100.0))
        // Asumiendo que el DefenseValue después de agregar la piedra es, por ejemplo, 20%
        double expectedDamage = 50 * (1 - 0.60) * (1 - (20.0 / 100.0));
        double expectedHealth = 100 - expectedDamage;

        // Comprobar que la salud final es la esperada
        Assert.That(_golem.Health, Is.EqualTo((int)expectedHealth));
    }

    [Test]
    public void RecibirAtaque_NoBajaDeCero()
    {
        _golem.ReceiveAttack(700000);
        Assert.That(_golem.Health, Is.EqualTo(0));
    }

    [Test]
    public void Curar_RestauraVidaAlMaximo()
    {
        _golem.ReceiveAttack(50);
        _golem.Cure(); // Curar restaura la vida al máximo
        Assert.That(_golem.Health, Is.EqualTo(600));
    }

    [Test]
    public void AgregarItem_AumentaValorAtaque()
    {
        // Creamos un item de prueba
        Sword espadaLarga = new Sword("Espada Larga", 40, 0);
        _golem.AddItem(espadaLarga);

        // Verificamos que el valor de ataque aumenta
        _golem.CalculateAttackValue();
        Assert.That(_golem.AttackValue, Is.EqualTo(40));
        Assert.That(_golem.Items.Count, Is.EqualTo(1));
    }

    [Test]
    public void RecibirAtaque_AEnemigoMuerto_NoCambiaVida()
    {
        // Reducimos la vida a cero
        _golem.ReceiveAttack(70000);
        _golem.ReceiveAttack(30);

        // Verificamos que la vida no cambia
        Assert.That(_golem.Health, Is.EqualTo(0));
    }

}
