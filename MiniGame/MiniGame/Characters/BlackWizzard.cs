using MiniGame.Interfaces;

namespace MiniGame.Characters
{
    public class BlackWizzard : Wizzard
    {

        public override int Health { get; set; } = 110;
        public override int Damage { get; set; } = 170;

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
