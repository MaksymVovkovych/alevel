namespace ContactList
{
    public class Watcher
    {
        private FileSystemWatcher watcher;
        private string fileName;

        public Watcher(string fileName, FileSystemWatcher watcher)
        {
            this.fileName = fileName;
            this.watcher = watcher;
        }

        public void StartWatching()
        {
            if (File.Exists(fileName))
            {
                watcher.Filter = Path.GetFileName(fileName);
                watcher.Changed += (sender, e) =>
                {
                    Console.WriteLine($"{fileName} was changed.");
                };
                watcher.EnableRaisingEvents = true;
            }
            else
            {
                throw new FileNotFoundException("File not found");
            }
        }
        public void StopWatching()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
            }
        }
    }
}
