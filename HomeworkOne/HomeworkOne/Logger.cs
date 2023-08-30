using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeworkOne
{
    public sealed class Logger
    {
        public List<Result> logs = new List<Result>();
        private static  Logger? _instance;
        public Exeption LogLevel { get; set; }
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
            if (result.Status == LogLevel)
            {
                logs.Add(result);
                Console.WriteLine($"{result.dateTime}: {result.Status}: {result.Message}");
            }
        }

    }
}
