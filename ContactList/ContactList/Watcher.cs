using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    public class Watcher
    {
        private FileSystemWatcher watcher;
        private string fileName;

        public Watcher(string fileName)
        {
            this.fileName = fileName;
        }

        public void StartWatching()
        {
            watcher = new FileSystemWatcher(Path.GetDirectoryName(fileName));
            watcher.Filter = Path.GetFileName(fileName);
            watcher.Changed += (sender, e) =>
            {
                Console.WriteLine($"File {fileName} was changed at {e.ChangeType}.");
            };
            watcher.EnableRaisingEvents = true;
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
