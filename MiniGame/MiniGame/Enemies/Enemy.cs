using MiniGame.Interfaces;

namespace MiniGame.Enemies
{
    public abstract class Enemy : IEnemy
    {
        public bool IsAlive => Health > 0;

        public virtual int Health { get; set; }
        public virtual int Damage { get; set; }

        public abstract void Attack(ICharacter target);


    }
}
