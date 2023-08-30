
public enum Exeption
{
    Info,
    Warnning,
    Error,
}

public struct Result
{
    public  Exeption Status { get; set; }
    public string Message { get; set; }
    public DateTime dateTime { get; set; }
}

namespace HomeworkOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = Logger.Instance();
            logger.LogLevel = Exeption.Error;

            Starter.Run(); 

            logger.GetLogs();
        }
    }
}