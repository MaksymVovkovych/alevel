using MiniGame.Equipments;
using MiniGame.Interfaces;

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
                            Console.WriteLine("Invalid choice. Repeat.");
                            break;
                    }

                    enemy.Attack(player);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Repeat.");
                }
            }

            if (player.IsAlive)
            {
                Console.WriteLine($"Ви перемогли {enemy.GetType().Name}!");
            }
            else
            {
                Console.WriteLine($"Вас переміг {enemy.GetType().Name}...");
            }
        }


    }
}
