using MiniGame.Interfaces;

namespace MiniGame.Characters
{
    public class Barbarian : Character
    {

        public override int Health { get; set; } = 100;
        public override int Damage { get; set; } = 50;

        public override void Attack(IEnemy target)
        {
            target.Health -= Damage;
            Console.WriteLine($"Barbarian attacked {target.GetType().Name}");
        }
        public override void Block()
        {
            Console.WriteLine("Barbarian blocked");
        }
        public override void Equip(IEquipment equipment)
        {
            base.Equip(equipment);
        }
    }
}
