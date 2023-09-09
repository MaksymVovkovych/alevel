using MiniGame.Interfaces;

namespace MiniGame.Enemies
{
    public class GigantStoneMan : StoneMan
    {
        public override int Damage => 100;
        public override int Health { get; set; } = 150;
        public override void Attack(ICharacter target)
        {
            target.Health -= Damage;
            Console.WriteLine($"GigantStoneMan attacked {target.GetType().Name}");
        }

    }
}
