using MiniGame.Types;

namespace MiniGame
{
    public static class Action
    {
        public static Result InfoAction(string message)
        {
            var logger = Logger.Instance();
            var result = new Result()
            {
                dateTime = DateTime.Now,
                Status = LogType.Info,
                Message = message
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
                Status = LogType.Warnning,
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
                Status = LogType.Error,
                Message = "You received Error Message"
            };
            logger.SetLog(result);
            return result;
        }
    }
}
