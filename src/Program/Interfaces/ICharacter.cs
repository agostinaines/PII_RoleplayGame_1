namespace Library.Interfaces;

public interface ICharacter
{ 
    int health { get; set; }
    string Name { get; set; }
    int DefenseValue { get; }

    void ReceiveAttack(int power);
    void Cure();
}