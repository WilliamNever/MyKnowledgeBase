using System;
using System.IO;

namespace ProCure.MVCTests.Utilities
{
    public class FileStringWriter:IDisposable
    {
        private FileStream fs;
        private StreamWriter sw;
        private string Path;
        public FileStringWriter(string FilePath)
        {
            Path = FilePath;
       }
        public void Open()
        {
            fs = new FileStream(Path, FileMode.Create);
            sw = new StreamWriter(fs);
        }
        public void WriteFlushed(string str)
        {
            sw.Write(str);
            Flush();
        }
        public void Flush()
        {
            sw.Flush();
        }
        public void Close()
        {
            sw.Close();
            fs.Close();
        }

        public void Dispose()
        {
            Close();
            sw.Dispose();
            fs.Dispose();
        }
    }
}
