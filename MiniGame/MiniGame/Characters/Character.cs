using MiniGame.Interfaces;

namespace MiniGame.Characters
{
    public abstract class Character : ICharacter
    {
        public bool IsAlive => Health > 0;
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }

        public virtual void Attack(IEnemy target) { }
        public virtual void Block() { }
        public virtual void Equip(IEquipment equipment)
        {
            this.Health += equipment.Protection;
            this.Damage += equipment.Damage;
        }
    }
}
