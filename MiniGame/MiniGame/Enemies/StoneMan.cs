using MiniGame.Interfaces;

namespace MiniGame.Enemies
{
    public class StoneMan : Enemy
    {
        public override int Damage => 85;
        public override int Health { get; set; } = 100;
        public override void Attack(ICharacter target)
        {
            target.Health -= Damage;
            Console.WriteLine($"StoneMan attacked {target.GetType().Name}");
        }
    }
}
