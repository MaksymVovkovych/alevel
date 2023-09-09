namespace MiniGame.Interfaces
{
    public interface ICharacter
    {

        bool IsAlive { get; }
        int Health { get; set; }
        int Damage { get; set; }
        void Attack(IEnemy target);
        void Block();
        void Equip(IEquipment equipment);
    }
}
