using MiniGame.Types;
using Newtonsoft.Json;


namespace MiniGame
{
    public class FileService
    {
        private readonly List<Result> _loggers;
        public FileService(List<Result> loggers)
        {
            _loggers = loggers;
        }

        public void WriteLogsIntoFile(string path)
        {
            string json = JsonConvert.SerializeObject(_loggers);
            File.WriteAllText(path, json);
        }
        public List<Result> ReadLogsFromFile(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                List<Result>? myList = JsonConvert.DeserializeObject<List<Result>>(json);

                if (myList == null)
                {
                    myList = new List<Result>();
                }
                return myList;
            }
            else
            {
                return new List<Result>();
            }
        }

    }
}
