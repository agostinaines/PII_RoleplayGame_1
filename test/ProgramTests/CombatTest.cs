using NUnit.Framework;
using System.Collections.Generic;
using Library.Characters;
using Library.Characters.AncestralClasses;
using Library.Funcionalidades;

namespace CombatTests
{
    [TestFixture]
    public class CombatTests
    {
        private Combat _combat;

        [SetUp]
        public void Setup()
        {
            _combat = new Combat();
        }

        [Test]
        public void DoEncounter_HeroesWin_EnemiesDefeated()
        {
            // Crear héroes con valores de vida y ataque
            var hero1 = new HeroCharacter("Héroe 1", 100) { AttackValue = 40 };
            var hero2 = new HeroCharacter("Héroe 2", 100) { AttackValue = 30 };
            var heroes = new List<HeroCharacter> { hero1, hero2 };

            // Crear enemigos con valores de vida, ataque y puntos de victoria
            var enemy1 = new Orc("Orco 1", 50, 3) { AttackValue = 10 };
            var enemy2 = new Troll("Troll 1", 50, 2) { AttackValue = 15 };
            var enemies = new List<EnemyCharacter> { enemy1, enemy2 };

            // Ejecutar el encuentro
            _combat.DoEncounter(heroes, enemies);

            // Verificar que los héroes hayan ganado (los enemigos son eliminados)
            Assert.IsEmpty(enemies);

            // Verificar que los héroes sigan vivos
            Assert.That(heroes.Count, Is.EqualTo(2));
            Assert.That(hero1.Health, Is.GreaterThan(0));
            Assert.That(hero2.Health, Is.GreaterThan(0));

            // Verificar que los héroes hayan ganado puntos de victoria
            Assert.That(hero1.VictoryPoints, Is.GreaterThanOrEqualTo(0));
            Assert.That(hero2.VictoryPoints, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void DoEncounter_EnemiesWin_HeroesDefeated()
        {
            // Crear héroes con valores de vida y ataque (débil)
            var hero1 = new HeroCharacter("Héroe 1", 30) { AttackValue = 10 };
            var hero2 = new HeroCharacter("Héroe 2", 30) { AttackValue = 5 };
            var heroes = new List<HeroCharacter> { hero1, hero2 };

            // Crear enemigos con valores de vida, ataque y puntos de victoria (fuertes)
            var enemy1 = new Orc("Orco 1", 100, 3) { AttackValue = 30 };
            var enemy2 = new Troll("Troll 1", 100, 2) { AttackValue = 40 };
            var enemies = new List<EnemyCharacter> { enemy1, enemy2 };

            // Ejecutar el encuentro
            _combat.DoEncounter(heroes, enemies);

            // Verificar que los héroes hayan sido derrotados (todos los héroes son eliminados)
            Assert.IsEmpty(heroes);

            // Verificar que los enemigos sigan vivos
            Assert.That(enemies.Count, Is.EqualTo(2));
            Assert.That(enemy1.Health, Is.GreaterThan(0));
            Assert.That(enemy2.Health, Is.GreaterThan(0));
        }
        
        [Test]
        public void DoEncounter_HeroRevives_AfterGainingVictoryPoints()
        {
            // Crear héroe con vida baja y valores de ataque
            var hero1 = new HeroCharacter("Héroe 1", 10) { AttackValue = 50, VictoryPoints = 4 };
            var heroes = new List<HeroCharacter> { hero1 };

            // Crear un enemigo que otorga suficientes puntos de victoria para que el héroe reviva
            var enemy1 = new Orc("Orco 1", 30, 1) { AttackValue = 10 };
            var enemies = new List<EnemyCharacter> { enemy1 };

            // Guardar el valor de la vida máxima del héroe antes del encuentro
            var heroMaxHealth = hero1.MaxHealth;

            // Ejecutar el encuentro
            _combat.DoEncounter(heroes, enemies);

            // Verificar que el héroe haya ganado suficientes puntos de victoria y revivido
            Assert.That(hero1.VictoryPoints, Is.EqualTo(0));
            Assert.That(hero1.Health, Is.EqualTo(heroMaxHealth));

            // Verificar que el enemigo haya sido derrotado
            Assert.IsEmpty(enemies);

            // Verificar que el héroe sigue en la lista de héroes
            Assert.That(heroes.Count, Is.EqualTo(1));
        }

    }
}
