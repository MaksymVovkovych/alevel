using MiniGame.Interfaces;

namespace MiniGame.Characters
{
    public class Wizzard : Character
    {

        public override int Health { get; set; } = 70;
        public override int Damage { get; set; } = 120;

        public override void Attack(IEnemy target)
        {
            target.Health -= Damage;
            Console.WriteLine($" Wizzard attacked {target.GetType().Name}");
        }
        public override void Block()
        {
            Console.WriteLine("Wizzard blocked");
        }
        public override void Equip(IEquipment equipment)
        {
            base.Equip(equipment);
        }
    }
}
