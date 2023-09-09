using MiniGame.Characters;
using MiniGame.Enemies;
using MiniGame.Interfaces;

namespace MiniGame
{
    public class PlayerService
    {
        public ICharacter CreateCharacter()
        {

            Console.WriteLine("Input a class:");
            Console.WriteLine("1. Wizzard");
            Console.WriteLine("2. BlackWizzard");
            Console.WriteLine("3. Barbarian");
            Console.WriteLine("4. WarriorBarbarian");

            int classChoice;
            if (int.TryParse(Console.ReadLine(), out classChoice))
            {
                switch (classChoice)
                {
                    case 1:
                        return new Wizzard();
                    case 2:
                        return new BlackWizzard();
                    case 3:
                        return new Barbarian();
                    case 4:
                        return new WarriorBarbarian();
                    default:
                        Console.WriteLine("Invalid choice.");
                        return null;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return null;
            }
        }

        public IEnemy GenerateEnemy()
        {
            //generate any enemy
            return new Ghost();
        }
    }
}
