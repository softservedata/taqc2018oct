using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1.Utils
{
    public abstract class ExternalReader
    {
        public const int PATH_PREFIX = 6;
        public const string PATH_SEPARATOR = "\\";
        protected const string FOLDER_DATA = "Resources";
        protected const string FOLDER_BIN = "bin";
        //
        public static Logger log = LogManager.GetCurrentClassLogger(); // for NLog

        public string Filename { get; private set; }
        public string Path { get; protected set; }

        //protected ExternalReader(string filename)
        public ExternalReader(string filename)
        {
            Filename = filename;
            Path = AppDomain.CurrentDomain.BaseDirectory;
            Path = Path.Remove(Path.IndexOf(FOLDER_BIN)) + FOLDER_DATA + PATH_SEPARATOR + filename;
        }

        public IList<IList<string>> GetAllCells()
        {
            return GetAllCells(Path);
        }

        public abstract IList<IList<string>> GetAllCells(string path);

    }
}
