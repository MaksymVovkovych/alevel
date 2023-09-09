using MiniGame.Interfaces;

namespace MiniGame.Enemies
{
    public class Ghost : Enemy
    {
        public override int Damage => 15;
        public override int Health { get; set; } = 130;
        public override void Attack(ICharacter target)
        {
            target.Health -= Damage;
            Console.WriteLine($"Ghost attacked {target.GetType().Name}");
        }

    }
}
