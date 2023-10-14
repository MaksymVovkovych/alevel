using MiniGame.Interfaces;

namespace MiniGame.Characters
{
    public class WarriorBarbarian : Barbarian
    {

        public override int Health { get; set; } = 150;
        public override int Damage { get; set; } = 100;

        public override void Attack(IEnemy target)
        {
            target.Health -= Damage;
            Console.WriteLine($" WarriorBarbarian attacked {target.GetType().Name}");
        }
        public override void Block()
        {
            Console.WriteLine("WarriorBarbarian blocked");
        }
        public override void Equip(IEquipment equipment)
        {
            base.Equip(equipment);
        }
    }
}
