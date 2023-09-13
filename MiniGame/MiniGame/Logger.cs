using MiniGame.Types;


namespace MiniGame
{
    public sealed class Logger
    {
        public List<Result> logs = new List<Result>();
        private static Logger? _instance;
        public LogType LogLevel { get; set; } = LogType.Error;
        private Logger() { }
        public static Logger Instance()
        {
            if (_instance == null)
            { _instance = new Logger(); }
            return _instance;
        }
        public void GetLogs()
        {
            foreach (var log in logs)
            {
                Console.WriteLine($"{log.dateTime}: {log.Status}: {log.Message}");
            }
        }
        public void SetLog(Result result)
        {
            logs.Add(result);
            Console.WriteLine($"{result.dateTime}: {result.Status}: {result.Message}");
        }

    }
}
