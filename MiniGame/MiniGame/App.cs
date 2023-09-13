using MiniGame.Equipments;
using MiniGame.Interfaces;
using MiniGame.Exceptions;

namespace MiniGame
{
    public class App
    {
        private readonly PlayerService _playerService;
        public App(PlayerService playerService)
        {
            _playerService = playerService;
        }


        public void Start()
        {
            ICharacter player = _playerService.CreateCharacter();
            IEnemy enemy = _playerService.GenerateEnemy();
            Console.WriteLine($"You already with {enemy.GetType().Name}!");

            try
            {
                while (player.IsAlive && enemy.IsAlive)
                {
                    Console.WriteLine($"{player.GetType().Name}: HP = {player.Health}");
                    Console.WriteLine($"{enemy.GetType().Name}: HP = {enemy.Health}");

                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Block");
                    Console.WriteLine("3. Equip your player");

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                player.Attack(enemy);
                                break;
                            case 2:
                                player.Block();
                                break;
                            case 3:
                                //you can set equip
                                player.Equip(new Shield());
                                break;
                            default:
                                throw new InvalidChoiceException("Invalid choice. Repeat.");

                        }
                        enemy.Attack(player);
                        if (player.Health <= 50)
                            throw new LifeException("Warning.You have to equip!");
                    }
                    else
                    { 
                        throw new InvalidChoiceException("Invalid choice. Repeat.");
                    }
                }
            }
            catch (LifeException)
            {
                Action.WarningAction();
                Console.WriteLine("Be carrefull");
            }
            catch (InvalidChoiceException)
            {
                Console.WriteLine("Choice again");
                Action.ErrorAction();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Failed run.");
                Action.ErrorAction();
            }
            if (player.IsAlive)
            {
                Console.WriteLine(Action.InfoAction($"Ви перемогли {enemy.GetType().Name}!"));
            }
            else
            {
                Console.WriteLine(Action.InfoAction($"Вас переміг {enemy.GetType().Name}..."));
               
            }
        }
    }
}
