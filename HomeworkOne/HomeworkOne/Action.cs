using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOne
{
    public static class Action
    {
        public static Result InfoAction()
        {
            var logger = Logger.Instance();
            var result = new Result() 
            { dateTime = DateTime.Now,
                Status= Exeption.Info,
                Message="You received Info Message"
            };
            logger.SetLog(result);
            return result;
        }
        public static Result WarningAction()
        {
            var logger = Logger.Instance();
            var result = new Result()
            {
                dateTime = DateTime.Now,
                Status = Exeption.Warnning,
                Message = "You received Warning Message"
            };
            logger.SetLog(result);
            return result;
        }
        public static Result ErrorAction()
        {
            var logger = Logger.Instance();
            var result = new Result()
            {
                dateTime = DateTime.Now,
                Status = Exeption.Error,
                Message = "You received Error Message"
            };
            logger.SetLog(result);
            return result;
        }
    }
}
