using MiniGame.Interfaces;

namespace MiniGame.Enemies
{
    public class GhostKing : Ghost
    {
        public override int Damage => 40;
        public override int Health { get; set; } = 200;
        public override void Attack(ICharacter target)
        {
            target.Health -= Damage;
            Console.WriteLine($"GhostKing attacked {target.GetType().Name}");
        }

    }
}
