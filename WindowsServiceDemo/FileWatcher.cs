using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public class FileWatcher
    {
        private FileSystemWatcher _fileWatcher;

        public FileWatcher()
        {
            _fileWatcher = new FileSystemWatcher(PathLocation());
            _fileWatcher.Created += new FileSystemEventHandler(_fileWatcher_Created);
            _fileWatcher.Deleted += new FileSystemEventHandler(_fileWatcher_Deleted);
            _fileWatcher.Changed += new FileSystemEventHandler(_fileWatcher_Changed);
            _fileWatcher.EnableRaisingEvents = true;
        }

        private string PathLocation()
        {
            string value="";
            try
            {
                value = ConfigurationManager.AppSettings["location"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;

        }
        void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Logger.Log($"File Changed: Path:{e.FullPath}, Name:{e.Name}");
        }
        void _fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Logger.Log($"File Created: Path:{e.FullPath}, Name:{e.Name}");
        }
        void _fileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Logger.Log($"File Deleted: Path:{e.FullPath}, Name:{e.Name}");
        }

    }
}
