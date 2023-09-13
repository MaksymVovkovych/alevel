using MiniGame.Characters;
using MiniGame.Enemies;
using MiniGame.Interfaces;
using MiniGame.Exceptions;

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
            try
            {
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
                            throw new InvalidChoiceException("Invalid choice.");
                    }
                }
                else
                {
                    throw new InvalidChoiceException("Invalid choice.");
                }
            }
            catch (InvalidChoiceException)
            {
                Action.ErrorAction();
                Console.WriteLine("Try again");
                return CreateCharacter();
            }
        }

        public IEnemy GenerateEnemy()
        {
            //generate any enemy
            return new GhostKing();
        }
    }
}
