using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne
{
    public static class Starter
    {
        public static void Run()
        {
            Random random = new Random();
            int n = random.Next(5,15);
            //оскільки в завданні було сказано ,що метод Run не повинен нічого приймати
            //я взяв за кількість ітерацій рандомне чило від 5 до 15

            for(int i = 0; i < n; i++)
            {
                int action = random.Next(3);
                switch(action)
                {
                    case 0:
                        Action.InfoAction();
                        break;
                    case 1:
                
                        Action.WarningAction();
                        break;
                    case 2:
                
                        Action.ErrorAction();
                        break;
                }
            }
        }
    }
}
