namespace Library.Interfaces;

public interface IItem: IIItemAttack, IItemDefense, IIsMagic
{
    public void AddItem();
}