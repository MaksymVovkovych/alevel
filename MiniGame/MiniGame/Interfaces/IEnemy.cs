namespace MiniGame.Interfaces
{
    public interface IEnemy
    {
        bool IsAlive { get; }
        int Health { get; set; }
        int Damage { get; set; }
        void Attack(ICharacter target);
    }
}
