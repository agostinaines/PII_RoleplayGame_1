using Library.Items;
namespace Library.Personajes;

public class Mago : PersonajeBase
{
    public List<Spell> Spells { get; set; }

    public Mago(string name, int life) : base(name, life)
    {
        this.Spells = new List<Spell>();
    }
    
    public int UsarSpell(Spell spell)
    {
        foreach (Spell spells in Spells)
        {
            if (spells == spell)
            {
                return spell.Attack;
            }
        }
        return 0;
    }


    public void AddSpell(Spell spell)
    {
        this.Spells.Add(spell);
    }

    
    public void ReceiveAttack(int damage)
    {
        if (Health <= 0)
        {
            Console.WriteLine("Atacaste a un muerto :(");
        }
        else
        {
            // Los magos no tienen la reducción de daño del enano
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
                Console.WriteLine("Mataste a ese enemigo");
            }
        }
    }
}
